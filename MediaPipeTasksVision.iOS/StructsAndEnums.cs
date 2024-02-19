using System.Runtime.InteropServices;
using Foundation;
using MediaPipeTasksVision;
using ObjCRuntime;

namespace MediaPipeTasksVision
{
	[Native]
	public enum MPPDelegate : ulong
	{
		Cpu,
		Gpu
	}

	[Native]
	public enum MPPTasksErrorCode : ulong
	{
		CancelledError = 1,
		UnknownError = 2,
		InvalidArgumentError = 3,
		DeadlineExceededError = 4,
		NotFoundError = 5,
		AlreadyExistsError = 6,
		PermissionDeniedError = 7,
		ResourceExhaustedError = 8,
		FailedPreconditionError = 9,
		AbortedError = 10,
		OutOfRangeError = 11,
		UnimplementedError = 12,
		InternalError = 13,
		UnavailableError = 14,
		DataLossError = 15,
		UnauthenticatedError = 16,
		First = CancelledError,
		Last = UnauthenticatedError
	}

	[Native]
	public enum MPPRunningMode : ulong
	{
		Image,
		Video,
		LiveStream
	}

	public static class CFunctions
	{
		public static NSString MPPRunningModeDisplayName(MPPRunningMode runningMode) =>
			runningMode switch
			{
				MPPRunningMode.Image => (NSString)"Image",
				MPPRunningMode.Video => (NSString)"Video",
				MPPRunningMode.LiveStream => (NSString)"Live Stream",
				_ => null
			};
	}

	[Native]
	public enum MPPHandLandmark : ulong
	{
		Wrist,
		ThumbCMC,
		ThumbMCP,
		ThumbIP,
		ThumbTIP,
		IndexFingerMCP,
		IndexFingerPIP,
		IndexFingerDIP,
		IndexFingerTIP,
		MiddleFingerMCP,
		MiddleFingerPIP,
		MiddleFingerDIP,
		MiddleFingerTIP,
		RingFingerMCP,
		RingFingerPIP,
		RingFingerDIP,
		RingFingerTIP,
		PinkyMCP,
		PinkyPIP,
		PinkyDIP,
		PinkyTIP
	}

	[Native]
	public enum MPPMaskDataType : ulong
	{
		UInt8,
		Float32
	}
}
