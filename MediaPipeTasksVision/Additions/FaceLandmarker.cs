using System.Reflection;
using Android.Runtime;
using Java.Interop;

namespace MediaPipe.Tasks.Vision.FaceLandmarker;

public sealed partial class FaceLandmarker
{
    private static class RawFaceLandmarkerJni
    {
        internal static readonly IntPtr DetectMethod = JNIEnv.GetMethodID(
            class_ref,
            "detect",
            "(Lcom/google/mediapipe/framework/image/MPImage;)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;");

        internal static readonly IntPtr DetectWithProcessingOptionsMethod = JNIEnv.GetMethodID(
            class_ref,
            "detect",
            "(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;");

        internal static readonly IntPtr DetectForVideoMethod = JNIEnv.GetMethodID(
            class_ref,
            "detectForVideo",
            "(Lcom/google/mediapipe/framework/image/MPImage;J)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;");

        internal static readonly IntPtr DetectForVideoWithProcessingOptionsMethod = JNIEnv.GetMethodID(
            class_ref,
            "detectForVideo",
            "(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;J)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;");
    }

    [Register("detect", "(Lcom/google/mediapipe/framework/image/MPImage;)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;", "")]
    public FaceLandmarkerResult? Detect(global::MediaPipe.Framework.Image.MPImage? image)
    {
        var args = new[]
        {
            new JValue(image?.Handle ?? IntPtr.Zero),
        };

        IntPtr resultHandle = JNIEnv.CallObjectMethod(Handle, RawFaceLandmarkerJni.DetectMethod, args);

        try
        {
            return JniOwnershipHelper.GetObject<FaceLandmarkerResult>(resultHandle);
        }
        finally
        {
            GC.KeepAlive(image);
            GC.KeepAlive(this);
        }
    }

    [Register("detect", "(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;", "")]
    public FaceLandmarkerResult? Detect(global::MediaPipe.Framework.Image.MPImage? image, global::MediaPipe.Tasks.Vision.Core.ImageProcessingOptions? imageProcessingOptions)
    {
        var args = new[]
        {
            new JValue(image?.Handle ?? IntPtr.Zero),
            new JValue(imageProcessingOptions?.Handle ?? IntPtr.Zero),
        };

        IntPtr resultHandle = JNIEnv.CallObjectMethod(Handle, RawFaceLandmarkerJni.DetectWithProcessingOptionsMethod, args);

        try
        {
            return JniOwnershipHelper.GetObject<FaceLandmarkerResult>(resultHandle);
        }
        finally
        {
            GC.KeepAlive(image);
            GC.KeepAlive(imageProcessingOptions);
            GC.KeepAlive(this);
        }
    }

    [Register("detectForVideo", "(Lcom/google/mediapipe/framework/image/MPImage;J)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;", "")]
    public FaceLandmarkerResult? DetectForVideo(global::MediaPipe.Framework.Image.MPImage? image, long timestampMs)
    {
        var args = new[]
        {
            new JValue(image?.Handle ?? IntPtr.Zero),
            new JValue(timestampMs),
        };

        IntPtr resultHandle = JNIEnv.CallObjectMethod(Handle, RawFaceLandmarkerJni.DetectForVideoMethod, args);

        try
        {
            return JniOwnershipHelper.GetObject<FaceLandmarkerResult>(resultHandle);
        }
        finally
        {
            GC.KeepAlive(image);
            GC.KeepAlive(this);
        }
    }

    [Register("detectForVideo", "(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;J)Lcom/google/mediapipe/tasks/vision/facelandmarker/FaceLandmarkerResult;", "")]
    public FaceLandmarkerResult? DetectForVideo(global::MediaPipe.Framework.Image.MPImage? image, global::MediaPipe.Tasks.Vision.Core.ImageProcessingOptions? imageProcessingOptions, long timestampMs)
    {
        var args = new[]
        {
            new JValue(image?.Handle ?? IntPtr.Zero),
            new JValue(imageProcessingOptions?.Handle ?? IntPtr.Zero),
            new JValue(timestampMs),
        };

        IntPtr resultHandle = JNIEnv.CallObjectMethod(Handle, RawFaceLandmarkerJni.DetectForVideoWithProcessingOptionsMethod, args);

        try
        {
            return JniOwnershipHelper.GetObject<FaceLandmarkerResult>(resultHandle);
        }
        finally
        {
            GC.KeepAlive(image);
            GC.KeepAlive(imageProcessingOptions);
            GC.KeepAlive(this);
        }
    }
}

internal static class JniOwnershipHelper
{
    private delegate JniObjectReferenceType GetObjectRefTypeDelegate(JniObjectReference reference);

    private static readonly GetObjectRefTypeDelegate GetObjectRefType = CreateGetObjectRefTypeDelegate();

    internal static T? GetObject<T>(IntPtr handle)
        where T : Java.Lang.Object
    {
        if (handle == IntPtr.Zero)
            return null;

        return GetRefType(handle) switch
        {
            JniObjectReferenceType.Local => Java.Lang.Object.GetObject<T>(handle, JniHandleOwnership.TransferLocalRef),
            JniObjectReferenceType.Global => Java.Lang.Object.GetObject<T>(handle, JniHandleOwnership.TransferGlobalRef),
            _ => Java.Lang.Object.GetObject<T>(handle, JniHandleOwnership.DoNotTransfer),
        };
    }

    internal static void DeleteReturnedRef(IntPtr handle)
    {
        if (handle == IntPtr.Zero)
            return;

        switch (GetRefType(handle))
        {
            case JniObjectReferenceType.Local:
                JNIEnv.DeleteLocalRef(handle);
                break;

            case JniObjectReferenceType.Global:
                JNIEnv.DeleteGlobalRef(handle);
                break;
        }
    }

    internal static IntPtr RequireClassRef(string className)
    {
        var classRef = JNIEnv.FindClass(className);
        if (classRef == IntPtr.Zero)
            throw new InvalidOperationException($"Unable to resolve JNI class '{className}'.");

        return classRef;
    }

    private static JniObjectReferenceType GetRefType(IntPtr handle)
    {
        return GetObjectRefType(new JniObjectReference(handle));
    }

    private static GetObjectRefTypeDelegate CreateGetObjectRefTypeDelegate()
    {
        var referencesType = typeof(JniEnvironment).GetNestedType("References", BindingFlags.Public | BindingFlags.NonPublic)
            ?? throw new InvalidOperationException("Java.Interop did not expose JniEnvironment.References.");

        var method = referencesType.GetMethod("GetObjectRefType", BindingFlags.Static | BindingFlags.NonPublic)
            ?? throw new InvalidOperationException("Java.Interop did not expose JniEnvironment.References.GetObjectRefType.");

        return (GetObjectRefTypeDelegate)method.CreateDelegate(typeof(GetObjectRefTypeDelegate));
    }
}