using ObjCRuntime;

namespace MediaPipeTasksText {
	[Native]
	public enum MPPDelegate : ulong {
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
	public enum MPPEmbeddingType : ulong {
		RetrievalQuery = 1,
		RetrievalDocument = 2,
		SemanticSimilarity = 3,
		Classification = 4,
		Clustering = 5,
		QuestionAnswering = 6,
		FactChecking = 7,
		CodeRetrieval = 8
	}

	[Native]
	public enum MPPTextRole : ulong {
		Query = 0,
		Document = 1
	}

	[Native]
	public enum MPPCorrectionType : long {
		Same = 0,
		Insertion,
		Deletion
	}

	[Native]
	public enum MPPTextSummarizerMode : long {
		Tldr = 0,
		KeyPoints
	}
}
