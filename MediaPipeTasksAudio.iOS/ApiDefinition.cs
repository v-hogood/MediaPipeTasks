using System;
using Foundation;
using MediaPipeTasksAudio;
using ObjCRuntime;

namespace MediaPipeTasksAudio {
	// @interface MPPCategory : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPCategory {
		// @property (readonly, nonatomic) NSInteger index;
		[Export ("index")]
		nint Index { get; }

		// @property (readonly, nonatomic) float score;
		[Export ("score")]
		float Score { get; }

		// @property (readonly, nonatomic) NSString * _Nullable categoryName;
		[NullAllowed, Export ("categoryName")]
		string CategoryName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; }

		// -(instancetype _Nonnull)initWithIndex:(NSInteger)index score:(float)score categoryName:(NSString * _Nullable)categoryName displayName:(NSString * _Nullable)displayName __attribute__((objc_designated_initializer));
		[Export ("initWithIndex:score:categoryName:displayName:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nint index, float score, [NullAllowed] string categoryName, [NullAllowed] string displayName);
	}

	// @interface MPPClassifications : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPClassifications {
		// @property (readonly, nonatomic) NSInteger headIndex;
		[Export ("headIndex")]
		nint HeadIndex { get; }

		// @property (readonly, nonatomic) NSString * _Nullable headName;
		[NullAllowed, Export ("headName")]
		string HeadName { get; }

		// @property (readonly, nonatomic) NSArray<MPPCategory *> * _Nonnull categories;
		[Export ("categories")]
		MPPCategory [] Categories { get; }

		// -(instancetype _Nonnull)initWithHeadIndex:(NSInteger)headIndex categories:(NSArray<MPPCategory *> * _Nonnull)categories;
		[Export ("initWithHeadIndex:categories:")]
		NativeHandle Constructor (nint headIndex, MPPCategory [] categories);

		// -(instancetype _Nonnull)initWithHeadIndex:(NSInteger)headIndex headName:(NSString * _Nullable)headName categories:(NSArray<MPPCategory *> * _Nonnull)categories __attribute__((objc_designated_initializer));
		[Export ("initWithHeadIndex:headName:categories:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nint headIndex, [NullAllowed] string headName, MPPCategory [] categories);
	}

	// @interface MPPClassificationResult : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPClassificationResult {
		// @property (readonly, nonatomic) NSArray<MPPClassifications *> * _Nonnull classifications;
		[Export ("classifications")]
		MPPClassifications [] Classifications { get; }

		// @property (readonly, nonatomic) NSInteger timestampInMilliseconds;
		[Export ("timestampInMilliseconds")]
		nint TimestampInMilliseconds { get; }

		// -(instancetype _Nonnull)initWithClassifications:(NSArray<MPPClassifications *> * _Nonnull)classifications timestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithClassifications:timestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPClassifications [] classifications, nint timestampInMilliseconds);
	}

	// @interface MPPTaskResult : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPTaskResult : INSCopying {
		// @property (readonly, assign, nonatomic) NSInteger timestampInMilliseconds;
		[Export ("timestampInMilliseconds")]
		nint TimestampInMilliseconds { get; }

		// -(instancetype _Nonnull)initWithTimestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithTimestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nint timestampInMilliseconds);
	}

	// @interface MPPAudioClassifierResult : MPPTaskResult
	[BaseType (typeof (MPPTaskResult))]
	interface MPPAudioClassifierResult {
		// @property (readonly, nonatomic) NSArray<MPPClassificationResult *> * _Nonnull classificationResults;
		[Export ("classificationResults")]
		MPPClassificationResult [] ClassificationResults { get; }

		// -(instancetype _Nonnull)initWithClassificationResults:(NSArray<MPPClassificationResult *> * _Nonnull)classificationResults timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithClassificationResults:timestampInMilliseconds:")]
		NativeHandle Constructor (MPPClassificationResult [] classificationResults, nint timestampInMilliseconds);
	}

	// @interface MPPBaseOptions : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface MPPBaseOptions : INSCopying {
		// @property (copy, nonatomic) NSString * _Nonnull modelAssetPath;
		[Export ("modelAssetPath")]
		string ModelAssetPath { get; set; }

		[Wrap ("WeakDelegate")]
		MPPDelegate Delegate { get; set; }

		// @property (nonatomic) MPPDelegate delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		MPPDelegate WeakDelegate { get; set; }
	}

	// @interface MPPTaskOptions : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface MPPTaskOptions : INSCopying {
		// @property (copy, nonatomic) MPPBaseOptions * _Nonnull baseOptions;
		[Export ("baseOptions", ArgumentSemantic.Copy)]
		MPPBaseOptions BaseOptions { get; set; }
	}

	// @protocol MPPAudioClassifierStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPPAudioClassifierStreamDelegate {
		// @optional -(void)audioClassifier:(MPPAudioClassifier * _Nonnull)AudioClassifier didFinishClassificationWithResult:(MPPAudioClassifierResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("audioClassifier(_:didFinishClassification:timestampInMilliseconds:error:)")));
		[Export ("audioClassifier:didFinishClassificationWithResult:timestampInMilliseconds:error:")]
		void DidFinishClassificationWithResult (MPPAudioClassifier AudioClassifier, [NullAllowed] MPPAudioClassifierResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPAudioClassifierOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof (MPPTaskOptions))]
	interface MPPAudioClassifierOptions : INSCopying {
		// @property (nonatomic) MPPAudioRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPAudioRunningMode RunningMode { get; set; }

		[Wrap ("WeakAudioClassifierStreamDelegate")]
		[NullAllowed]
		MPPAudioClassifierStreamDelegate AudioClassifierStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPAudioClassifierStreamDelegate> _Nullable audioClassifierStreamDelegate;
		[NullAllowed, Export ("audioClassifierStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAudioClassifierStreamDelegate { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull displayNamesLocale;
		[Export ("displayNamesLocale")]
		string DisplayNamesLocale { get; set; }

		// @property (nonatomic) NSInteger maxResults;
		[Export ("maxResults")]
		nint MaxResults { get; set; }

		// @property (nonatomic) float scoreThreshold;
		[Export ("scoreThreshold")]
		float ScoreThreshold { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull categoryAllowlist;
		[Export ("categoryAllowlist", ArgumentSemantic.Copy)]
		string [] CategoryAllowlist { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull categoryDenylist;
		[Export ("categoryDenylist", ArgumentSemantic.Copy)]
		string [] CategoryDenylist { get; set; }
	}

	// @interface MPPAudioDataFormat : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPAudioDataFormat {
		// @property (readonly, nonatomic) NSUInteger channelCount;
		[Export ("channelCount")]
		nuint ChannelCount { get; }

		// @property (readonly, nonatomic) double sampleRate;
		[Export ("sampleRate")]
		double SampleRate { get; }

		// -(instancetype _Nonnull)initWithChannelCount:(NSUInteger)channelCount sampleRate:(double)sampleRate;
		[Export ("initWithChannelCount:sampleRate:")]
		NativeHandle Constructor (nuint channelCount, double sampleRate);

		// -(instancetype _Nonnull)initWithSampleRate:(double)sampleRate;
		[Export ("initWithSampleRate:")]
		NativeHandle Constructor (double sampleRate);
	}

	// @interface MPPFloatBuffer : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPFloatBuffer : INSCopying {
		// @property (readonly, nonatomic) NSUInteger length;
		[Export ("length")]
		nuint Length { get; }

		// @property (readonly, nonatomic) float * _Nonnull data;
		[Export ("data")]
		unsafe NativeHandle Data { get; }

		// -(instancetype _Nonnull)initWithData:(const float * _Nullable)data length:(NSUInteger)length;
		[Export ("initWithData:length:")]
		unsafe NativeHandle Constructor ([NullAllowed] NativeHandle data, nuint length);

		// -(instancetype _Nonnull)initWithLength:(NSUInteger)length;
		[Export ("initWithLength:")]
		NativeHandle Constructor (nuint length);

		// -(void)clear;
		[Export ("clear")]
		void Clear ();
	}

	// @interface MPPAudioRecord : NSObject
	[BaseType (typeof (NSObject))]
	interface MPPAudioRecord {
		// @property (readonly, nonatomic) MPPAudioDataFormat * _Nonnull audioDataFormat;
		[Export ("audioDataFormat")]
		MPPAudioDataFormat AudioDataFormat { get; }

		// @property (readonly, nonatomic) NSUInteger bufferLength;
		[Export ("bufferLength")]
		nuint BufferLength { get; }

		// -(instancetype _Nullable)initWithAudioDataFormat:(MPPAudioDataFormat * _Nonnull)format bufferLength:(NSUInteger)bufferSize error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithAudioDataFormat:bufferLength:error:")]
		NativeHandle Constructor (MPPAudioDataFormat format, nuint bufferSize, [NullAllowed] out NSError error);

		// -(BOOL)startRecordingWithError:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("startRecording()")));
		[Export ("startRecordingWithError:")]
		bool StartRecordingWithError ([NullAllowed] out NSError error);

		// -(BOOL)stopWithError:(NSError * _Nullable * _Nullable)error;
		[Export ("stopWithError:")]
		bool StopWithError ([NullAllowed] out NSError error);

		// -(MPPFloatBuffer * _Nullable)readAtOffset:(NSUInteger)offset withLength:(NSUInteger)length error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("read(offset:length:)")));
		[Export ("readAtOffset:withLength:error:")]
		[return: NullAllowed]
		MPPFloatBuffer ReadAtOffset (nuint offset, nuint length, [NullAllowed] out NSError error);
	}

	// @interface MPPAudioData : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPAudioData {
		// @property (readonly, nonatomic) MPPAudioDataFormat * _Nonnull format;
		[Export ("format")]
		MPPAudioDataFormat Format { get; }

		// @property (readonly, nonatomic) MPPFloatBuffer * _Nonnull buffer;
		[Export ("buffer")]
		MPPFloatBuffer Buffer { get; }

		// @property (readonly, nonatomic) NSUInteger bufferLength;
		[Export ("bufferLength")]
		nuint BufferLength { get; }

		// -(instancetype _Nonnull)initWithFormat:(MPPAudioDataFormat * _Nonnull)format sampleCount:(NSUInteger)sampleCount __attribute__((objc_designated_initializer));
		[Export ("initWithFormat:sampleCount:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPAudioDataFormat format, nuint sampleCount);

		// -(BOOL)loadBuffer:(MPPFloatBuffer * _Nonnull)buffer offset:(NSUInteger)offset length:(NSUInteger)length error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("load(buffer:offset:length:)")));
		[Export ("loadBuffer:offset:length:error:")]
		bool LoadBuffer (MPPFloatBuffer buffer, nuint offset, nuint length, [NullAllowed] out NSError error);

		// -(BOOL)loadAudioRecord:(MPPAudioRecord * _Nonnull)audioRecord error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("load(audioRecord:)")));
		[Export ("loadAudioRecord:error:")]
		bool LoadAudioRecord (MPPAudioRecord audioRecord, [NullAllowed] out NSError error);
	}

	// @interface MPPAudioClassifier : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPAudioClassifier {
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPAudioClassifierOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPAudioClassifierOptions options, [NullAllowed] out NSError error);

		// -(MPPAudioClassifierResult * _Nullable)classifyAudioClip:(MPPAudioData * _Nonnull)audioClip error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classify(audioClip:)")));
		[Export ("classifyAudioClip:error:")]
		[return: NullAllowed]
		MPPAudioClassifierResult ClassifyAudioClip (MPPAudioData audioClip, [NullAllowed] out NSError error);

		// -(BOOL)classifyAsyncAudioBlock:(MPPAudioData * _Nonnull)audioBlock timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classifyAsync(audioBlock:timestampInMilliseconds:)")));
		[Export ("classifyAsyncAudioBlock:timestampInMilliseconds:error:")]
		bool ClassifyAsyncAudioBlock (MPPAudioData audioBlock, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)closeWithError:(NSError * _Nullable * _Nullable)error;
		[Export ("closeWithError:")]
		bool CloseWithError ([NullAllowed] out NSError error);

		// +(MPPAudioRecord * _Nonnull)createAudioRecordWithChannelCount:(NSUInteger)channelCount sampleRate:(double)sampleRate bufferLength:(NSUInteger)bufferLength error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("createAudioRecord(channelCount:sampleRate:bufferLength:)")));
		[Static]
		[Export ("createAudioRecordWithChannelCount:sampleRate:bufferLength:error:")]
		MPPAudioRecord CreateAudioRecordWithChannelCount (nuint channelCount, double sampleRate, nuint bufferLength, [NullAllowed] out NSError error);
	}

	// @interface MPPEmbedding : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPEmbedding {
		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable floatEmbedding;
		[NullAllowed, Export ("floatEmbedding")]
		NSNumber [] FloatEmbedding { get; }

		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable quantizedEmbedding;
		[NullAllowed, Export ("quantizedEmbedding")]
		NSNumber [] QuantizedEmbedding { get; }

		// @property (readonly, nonatomic) NSInteger headIndex;
		[Export ("headIndex")]
		nint HeadIndex { get; }

		// @property (readonly, nonatomic) NSString * _Nullable headName;
		[NullAllowed, Export ("headName")]
		string HeadName { get; }

		// -(instancetype _Nonnull)initWithFloatEmbedding:(NSArray<NSNumber *> * _Nullable)floatEmbedding quantizedEmbedding:(NSArray<NSNumber *> * _Nullable)quantizedEmbedding headIndex:(NSInteger)headIndex headName:(NSString * _Nullable)headName __attribute__((objc_designated_initializer));
		[Export ("initWithFloatEmbedding:quantizedEmbedding:headIndex:headName:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSNumber [] floatEmbedding, [NullAllowed] NSNumber [] quantizedEmbedding, nint headIndex, [NullAllowed] string headName);
	}

	// @interface MPPEmbeddingResult : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPEmbeddingResult {
		// @property (readonly, nonatomic) NSArray<MPPEmbedding *> * _Nonnull embeddings;
		[Export ("embeddings")]
		MPPEmbedding [] Embeddings { get; }

		// @property (readonly, nonatomic) NSInteger timestampInMilliseconds;
		[Export ("timestampInMilliseconds")]
		nint TimestampInMilliseconds { get; }

		// -(instancetype _Nonnull)initWithEmbeddings:(NSArray<MPPEmbedding *> * _Nonnull)embeddings timestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithEmbeddings:timestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPEmbedding [] embeddings, nint timestampInMilliseconds);
	}
}
