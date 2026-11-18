using ObjCRuntime;

namespace MediaPipeTasksRetrieval {
	[Native]
	public enum MPPDelegate : ulong {
		Default,
		Cpu,
		Gpu
	}

	[Native]
	public enum MPPTasksErrorCode : ulong {
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
		AudioRecordPermissionDeniedError = 17,
		AudioRecordPermissionUndeterminedError = 18,
		AudioRecordWaitingForNewMicInputError = 19,
		AudioRecordNotTappingMicError = 20,
		First = CancelledError,
		Last = AudioRecordNotTappingMicError
	}

	[Native]
	public enum MPPCoreRunningMode : ulong {
		Unspecified,
		Image,
		Video,
		LiveStream,
		AudioClips,
		AudioStream
	}

	[Native]
	public enum MPPChunkingMode : long {
		Character = 0,
		Word = 1
	}

	[Native]
	public enum MPPActivationDataType : ulong {
		Default = 0,
		Float32 = 1,
		Float16 = 2,
		Int16 = 3,
		Int8 = 4
	}

	[Native]
	public enum MPPImageSourceType : long {
		MPPImageSourceTypeImage = 0,
		MPPImageSourceTypePixelBuffer = 1,
		MPPImageSourceTypeSampleBuffer = 2
	}
}
