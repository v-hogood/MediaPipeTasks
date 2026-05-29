using Android.Runtime;
using Java.Interop;

namespace MediaPipe.Tasks.Vision.FaceLandmarker;

/// <summary>
/// Holds packed landmark data for one detected face while avoiding the wrapper-heavy
/// <c>NormalizedLandmark</c> object graph.
/// </summary>
public sealed class DetailedFaceLandmarks
{
    /// <summary>
    /// Initializes a new packed landmark payload for one face.
    /// </summary>
    /// <param name="xyzCoordinates">Packed coordinates in <c>x0, y0, z0, x1, y1, z1, ...</c> order.</param>
    /// <param name="visibility">Visibility values aligned to landmark index.</param>
    /// <param name="hasVisibility">Flags that indicate whether each visibility entry is present.</param>
    /// <param name="presence">Presence values aligned to landmark index.</param>
    /// <param name="hasPresence">Flags that indicate whether each presence entry is present.</param>
    public DetailedFaceLandmarks(float[] xyzCoordinates, float[] visibility, bool[] hasVisibility, float[] presence, bool[] hasPresence)
    {
        XYZCoordinates = xyzCoordinates;
        Visibility = visibility;
        HasVisibility = hasVisibility;
        Presence = presence;
        HasPresence = hasPresence;
    }

    /// <summary>
    /// Gets packed coordinates in <c>x, y, z</c> triplets.
    /// </summary>
    public float[] XYZCoordinates { get; }

    /// <summary>
    /// Gets visibility values aligned to landmark index.
    /// Entries whose corresponding <see cref="HasVisibility"/> value is <see langword="false"/> are unspecified.
    /// </summary>
    public float[] Visibility { get; }

    /// <summary>
    /// Gets flags that indicate whether each visibility value is present.
    /// </summary>
    public bool[] HasVisibility { get; }

    /// <summary>
    /// Gets presence values aligned to landmark index.
    /// Entries whose corresponding <see cref="HasPresence"/> value is <see langword="false"/> are unspecified.
    /// </summary>
    public float[] Presence { get; }

    /// <summary>
    /// Gets flags that indicate whether each presence value is present.
    /// </summary>
    public bool[] HasPresence { get; }

    /// <summary>
    /// Gets the number of landmarks stored for this face.
    /// </summary>
    public int LandmarkCount => XYZCoordinates.Length / 3;
}

/// <summary>
/// Provides Android-specific helper APIs for extracting face landmark data with minimal
/// managed interop overhead.
/// </summary>
public partial class FaceLandmarkerResult
{
    private static class RawFaceLandmarkJni
    {
        internal static readonly IntPtr FaceLandmarksMethod = JNIEnv.GetMethodID(class_ref, "faceLandmarks", "()Ljava/util/List;");
        private static readonly IntPtr JavaListClass = JniOwnershipHelper.RequireClassRef("java/util/List");
        private static readonly IntPtr JavaOptionalClass = JniOwnershipHelper.RequireClassRef("java/util/Optional");
        private static readonly IntPtr JavaFloatClass = JniOwnershipHelper.RequireClassRef("java/lang/Float");
        private static readonly IntPtr NormalizedLandmarkClass = JniOwnershipHelper.RequireClassRef("com/google/mediapipe/tasks/components/containers/NormalizedLandmark");
        internal static readonly IntPtr ListSizeMethod = JNIEnv.GetMethodID(JavaListClass, "size", "()I");
        internal static readonly IntPtr ListGetMethod = JNIEnv.GetMethodID(JavaListClass, "get", "(I)Ljava/lang/Object;");
        internal static readonly IntPtr OptionalIsPresentMethod = JNIEnv.GetMethodID(JavaOptionalClass, "isPresent", "()Z");
        internal static readonly IntPtr OptionalGetMethod = JNIEnv.GetMethodID(JavaOptionalClass, "get", "()Ljava/lang/Object;");
        internal static readonly IntPtr FloatValueMethod = JNIEnv.GetMethodID(JavaFloatClass, "floatValue", "()F");
        internal static readonly IntPtr LandmarkXMethod = JNIEnv.GetMethodID(NormalizedLandmarkClass, "x", "()F");
        internal static readonly IntPtr LandmarkYMethod = JNIEnv.GetMethodID(NormalizedLandmarkClass, "y", "()F");
        internal static readonly IntPtr LandmarkZMethod = JNIEnv.GetMethodID(NormalizedLandmarkClass, "z", "()F");
        internal static readonly IntPtr LandmarkVisibilityMethod = JNIEnv.GetMethodID(NormalizedLandmarkClass, "visibility", "()Ljava/util/Optional;");
        internal static readonly IntPtr LandmarkPresenceMethod = JNIEnv.GetMethodID(NormalizedLandmarkClass, "presence", "()Ljava/util/Optional;");
    }

    [Register("faceLandmarks", "()Ljava/util/List;", "")]
    public List<IList<MediaPipe.Tasks.Components.Containers.NormalizedLandmark>> FaceLandmarks()
    {
        var outerListHandle = JNIEnv.CallObjectMethod(Handle, RawFaceLandmarkJni.FaceLandmarksMethod);
        if (outerListHandle == IntPtr.Zero)
            return [];

        try
        {
            int faceCount = JNIEnv.CallIntMethod(outerListHandle, RawFaceLandmarkJni.ListSizeMethod);
            if (faceCount <= 0)
                return [];

            var faces = new List<IList<MediaPipe.Tasks.Components.Containers.NormalizedLandmark>>(faceCount);
            var indexArgs = new JValue[1];

            for (int faceIndex = 0; faceIndex < faceCount; faceIndex++)
            {
                var landmarkListHandle = GetListItem(outerListHandle, indexArgs, faceIndex);
                if (landmarkListHandle == IntPtr.Zero)
                {
                    faces.Add([]);
                    continue;
                }

                try
                {
                    int landmarkCount = JNIEnv.CallIntMethod(landmarkListHandle, RawFaceLandmarkJni.ListSizeMethod);
                    var landmarks = new List<MediaPipe.Tasks.Components.Containers.NormalizedLandmark>(landmarkCount);

                    for (int landmarkIndex = 0; landmarkIndex < landmarkCount; landmarkIndex++)
                    {
                        var landmarkHandle = GetListItem(landmarkListHandle, indexArgs, landmarkIndex);
                        var landmark = JniOwnershipHelper.GetObject<MediaPipe.Tasks.Components.Containers.NormalizedLandmark>(landmarkHandle);
                        if (landmark is not null)
                        {
                            landmarks.Add(landmark);
                        }
                    }

                    faces.Add(landmarks);
                }
                finally
                {
                    JniOwnershipHelper.DeleteReturnedRef(landmarkListHandle);
                }
            }

            return faces;
        }
        finally
        {
            JniOwnershipHelper.DeleteReturnedRef(outerListHandle);
        }
    }

    /// <summary>
    /// Extracts detected face landmarks into packed interleaved <c>x, y</c> coordinate arrays for fast access.
    /// </summary>
    /// <returns>
    /// One array per detected face. Each inner array is laid out as
    /// <c>x0, y0, x1, y1, ...</c> for that face's landmark sequence.
    /// </returns>
    /// <remarks>
    /// This method exists to avoid the heavy wrapper and JNI cost of traversing the
    /// generated <c>IList&lt;IList&lt;NormalizedLandmark&gt;&gt;</c> result shape in real-time paths.
    /// The underlying implementation uses a stack-allocated <c>JValue</c> scratch buffer
    /// to avoid per-call argument array allocations in the hot path.
    /// </remarks>
    public float[][] FaceLandmarksXY()
    {
        return ExtractPackedCoordinates(includeZ: false);
    }

    /// <summary>
    /// Extracts detected face landmarks into packed interleaved <c>x, y, z</c> coordinate arrays for fast access.
    /// </summary>
    /// <returns>
    /// One array per detected face. Each inner array is laid out as
    /// <c>x0, y0, z0, x1, y1, z1, ...</c> for that face's landmark sequence.
    /// </returns>
    /// <remarks>
    /// This provides the same low-overhead traversal pattern as <see cref="FaceLandmarksXY"/>,
    /// but retains depth values for consumers that need the full coordinate triplet.
    /// </remarks>
    public float[][] FaceLandmarksXYZ()
    {
        return ExtractPackedCoordinates(includeZ: true);
    }

    /// <summary>
    /// Extracts detected face landmarks into packed coordinates plus optional visibility and presence values.
    /// </summary>
    /// <returns>
    /// One packed face payload per detected face. Each payload contains <c>x, y, z</c> coordinates for every landmark,
    /// along with aligned presence and visibility arrays plus per-entry presence flags.
    /// </returns>
    /// <remarks>
    /// This method is intended for performance-sensitive consumers that need more metadata than
    /// <see cref="FaceLandmarksXY"/> or <see cref="FaceLandmarksXYZ"/>, but still want to avoid
    /// materializing the generated nested landmark wrapper graph.
    /// </remarks>
    public DetailedFaceLandmarks[] FaceLandmarksDetailed()
    {
        var outerListHandle = JNIEnv.CallObjectMethod(Handle, RawFaceLandmarkJni.FaceLandmarksMethod);
        if (outerListHandle == IntPtr.Zero)
            return [];

        try
        {
            int faceCount = JNIEnv.CallIntMethod(outerListHandle, RawFaceLandmarkJni.ListSizeMethod);
            if (faceCount <= 0)
                return [];

            var faces = new DetailedFaceLandmarks[faceCount];
            var indexArgs = new JValue[1];

            for (int faceIndex = 0; faceIndex < faceCount; faceIndex++)
            {
                var landmarkListHandle = GetListItem(outerListHandle, indexArgs, faceIndex);
                if (landmarkListHandle == IntPtr.Zero)
                {
                    faces[faceIndex] = new DetailedFaceLandmarks([], [], [], [], []);
                    continue;
                }

                try
                {
                    int landmarkCount = JNIEnv.CallIntMethod(landmarkListHandle, RawFaceLandmarkJni.ListSizeMethod);
                    var xyzCoordinates = new float[landmarkCount * 3];
                    var visibility = new float[landmarkCount];
                    var hasVisibility = new bool[landmarkCount];
                    var presence = new float[landmarkCount];
                    var hasPresence = new bool[landmarkCount];

                    for (int landmarkIndex = 0; landmarkIndex < landmarkCount; landmarkIndex++)
                    {
                        var landmarkHandle = GetListItem(landmarkListHandle, indexArgs, landmarkIndex);
                        if (landmarkHandle == IntPtr.Zero)
                            continue;

                        try
                        {
                            int coordinateIndex = landmarkIndex * 3;
                            xyzCoordinates[coordinateIndex] = JNIEnv.CallFloatMethod(landmarkHandle, RawFaceLandmarkJni.LandmarkXMethod);
                            xyzCoordinates[coordinateIndex + 1] = JNIEnv.CallFloatMethod(landmarkHandle, RawFaceLandmarkJni.LandmarkYMethod);
                            xyzCoordinates[coordinateIndex + 2] = JNIEnv.CallFloatMethod(landmarkHandle, RawFaceLandmarkJni.LandmarkZMethod);

                            if (TryReadOptionalFloat(landmarkHandle, RawFaceLandmarkJni.LandmarkVisibilityMethod, out float visibilityValue))
                            {
                                visibility[landmarkIndex] = visibilityValue;
                                hasVisibility[landmarkIndex] = true;
                            }

                            if (TryReadOptionalFloat(landmarkHandle, RawFaceLandmarkJni.LandmarkPresenceMethod, out float presenceValue))
                            {
                                presence[landmarkIndex] = presenceValue;
                                hasPresence[landmarkIndex] = true;
                            }
                        }
                        finally
                        {
                            JniOwnershipHelper.DeleteReturnedRef(landmarkHandle);
                        }
                    }

                    faces[faceIndex] = new DetailedFaceLandmarks(xyzCoordinates, visibility, hasVisibility, presence, hasPresence);
                }
                finally
                {
                    JniOwnershipHelper.DeleteReturnedRef(landmarkListHandle);
                }
            }

            return faces;
        }
        finally
        {
            JniOwnershipHelper.DeleteReturnedRef(outerListHandle);
        }
    }

    private float[][] ExtractPackedCoordinates(bool includeZ)
    {
        var outerListHandle = JNIEnv.CallObjectMethod(Handle, RawFaceLandmarkJni.FaceLandmarksMethod);
        if (outerListHandle == IntPtr.Zero)
            return [];

        try
        {
            int faceCount = JNIEnv.CallIntMethod(outerListHandle, RawFaceLandmarkJni.ListSizeMethod);
            if (faceCount <= 0)
                return [];

            int coordinateStride = includeZ ? 3 : 2;
            var faces = new float[faceCount][];
            var indexArgs = new JValue[1];

            for (int faceIndex = 0; faceIndex < faceCount; faceIndex++)
            {
                var landmarkListHandle = GetListItem(outerListHandle, indexArgs, faceIndex);
                if (landmarkListHandle == IntPtr.Zero)
                {
                    faces[faceIndex] = [];
                    continue;
                }

                try
                {
                    int landmarkCount = JNIEnv.CallIntMethod(landmarkListHandle, RawFaceLandmarkJni.ListSizeMethod);
                    var coordinates = new float[landmarkCount * coordinateStride];

                    for (int landmarkIndex = 0; landmarkIndex < landmarkCount; landmarkIndex++)
                    {
                        var landmarkHandle = GetListItem(landmarkListHandle, indexArgs, landmarkIndex);
                        if (landmarkHandle == IntPtr.Zero)
                            continue;

                        try
                        {
                            int coordinateIndex = landmarkIndex * coordinateStride;
                            coordinates[coordinateIndex] = JNIEnv.CallFloatMethod(landmarkHandle, RawFaceLandmarkJni.LandmarkXMethod);
                            coordinates[coordinateIndex + 1] = JNIEnv.CallFloatMethod(landmarkHandle, RawFaceLandmarkJni.LandmarkYMethod);
                            if (includeZ)
                            {
                                coordinates[coordinateIndex + 2] = JNIEnv.CallFloatMethod(landmarkHandle, RawFaceLandmarkJni.LandmarkZMethod);
                            }
                        }
                        finally
                        {
                            JniOwnershipHelper.DeleteReturnedRef(landmarkHandle);
                        }
                    }

                    faces[faceIndex] = coordinates;
                }
                finally
                {
                    JniOwnershipHelper.DeleteReturnedRef(landmarkListHandle);
                }
            }

            return faces;
        }
        finally
        {
            JniOwnershipHelper.DeleteReturnedRef(outerListHandle);
        }
    }

    private static IntPtr GetListItem(IntPtr listHandle, JValue[] indexArgs, int index)
    {
        indexArgs[0] = new JValue(index);
        return JNIEnv.CallObjectMethod(listHandle, RawFaceLandmarkJni.ListGetMethod, indexArgs);
    }

    private static bool TryReadOptionalFloat(IntPtr landmarkHandle, IntPtr optionalMethod, out float value)
    {
        value = default;

        var optionalHandle = JNIEnv.CallObjectMethod(landmarkHandle, optionalMethod);
        if (optionalHandle == IntPtr.Zero)
            return false;

        try
        {
            if (!JNIEnv.CallBooleanMethod(optionalHandle, RawFaceLandmarkJni.OptionalIsPresentMethod))
                return false;

            var boxedFloatHandle = JNIEnv.CallObjectMethod(optionalHandle, RawFaceLandmarkJni.OptionalGetMethod);
            if (boxedFloatHandle == IntPtr.Zero)
                return false;

            try
            {
                value = JNIEnv.CallFloatMethod(boxedFloatHandle, RawFaceLandmarkJni.FloatValueMethod);
                return true;
            }
            finally
            {
                JniOwnershipHelper.DeleteReturnedRef(boxedFloatHandle);
            }
        }
        finally
        {
            JniOwnershipHelper.DeleteReturnedRef(optionalHandle);
        }
    }
}
