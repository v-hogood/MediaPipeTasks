using System;
using CoreMedia;
using CoreVideo;
using Foundation;
using MediaPipeTasksRetrieval;
using ObjCRuntime;
using UIKit;

namespace MediaPipeTasksRetrieval {
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

	// @interface MPPAudioLoader : NSObject
	[BaseType (typeof (NSObject))]
	interface MPPAudioLoader {
		// +(MPPAudioData * _Nullable)loadAudioFromFilePath:(NSString * _Nonnull)filePath error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("loadAudio(fromFilePath:)")));
		[Static]
		[Export ("loadAudioFromFilePath:error:")]
		[return: NullAllowed]
		MPPAudioData LoadAudioFromFilePath (string filePath, [NullAllowed] out NSError error);

		// +(MPPAudioData * _Nullable)loadAudioFromData:(NSData * _Nonnull)data error:(NSError * _Nullable * _Nullable)error;
		[Static]
		[Export ("loadAudioFromData:error:")]
		[return: NullAllowed]
		MPPAudioData LoadAudioFromData (NSData data, [NullAllowed] out NSError error);
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

	// @protocol MPPTextChunker <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface MPPTextChunker {
		// @required -(NSArray<NSString *> * _Nullable)chunkText:(NSString * _Nonnull)text error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("chunkText(_:)")));
		[Abstract]
		[Export ("chunkText:error:")]
		[return: NullAllowed]
		string [] Error (string text, [NullAllowed] out NSError error);
	}

	// @interface MPPDefaultTextChunker : NSObject <MPPTextChunker>
	[BaseType (typeof (MPPTextChunker))]
	interface MPPDefaultTextChunker : MPPTextChunker {
		// @property (readonly, nonatomic) NSInteger chunkSize;
		[Export ("chunkSize")]
		nint ChunkSize { get; }

		// @property (readonly, nonatomic) NSInteger chunkOverlap;
		[Export ("chunkOverlap")]
		nint ChunkOverlap { get; }

		// @property (readonly, nonatomic) NSInteger wordThreshold;
		[Export ("wordThreshold")]
		nint WordThreshold { get; }

		// @property (readonly, nonatomic) MPPChunkingMode mode;
		[Export ("mode")]
		MPPChunkingMode Mode { get; }

		// -(instancetype _Nullable)initWithChunkSize:(NSInteger)chunkSize chunkOverlap:(NSInteger)chunkOverlap wordThreshold:(NSInteger)wordThreshold mode:(MPPChunkingMode)mode error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithChunkSize:chunkOverlap:wordThreshold:mode:error:")]
		NativeHandle Constructor (nint chunkSize, nint chunkOverlap, nint wordThreshold, MPPChunkingMode mode, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithChunkSize:(NSInteger)chunkSize chunkOverlap:(NSInteger)chunkOverlap mode:(MPPChunkingMode)mode error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithChunkSize:chunkOverlap:mode:error:")]
		NativeHandle Constructor (nint chunkSize, nint chunkOverlap, MPPChunkingMode mode, [NullAllowed] out NSError error);

		// @required -(NSArray<NSString *> * _Nullable)chunkText:(NSString * _Nonnull)text error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("chunkText(_:)")));
		[Export ("chunkText:error:")]
		[return: NullAllowed]
		[Override]
		new string [] Error (string text, [NullAllowed] out NSError error);
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

	// @interface MPPImage : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPImage {
		// @property (readonly, nonatomic) CGFloat width;
		[Export ("width")]
		nfloat Width { get; }

		// @property (readonly, nonatomic) CGFloat height;
		[Export ("height")]
		nfloat Height { get; }

		// @property (readonly, nonatomic) UIImageOrientation orientation;
		[Export ("orientation")]
		UIImageOrientation Orientation { get; }

		// @property (readonly, nonatomic) MPPImageSourceType imageSourceType;
		[Export ("imageSourceType")]
		nint ImageSourceType { get; }

		// @property (readonly, nonatomic) UIImage * _Nullable image;
		[NullAllowed, Export ("image")]
		UIImage Image { get; }

		// @property (readonly, nonatomic) CVPixelBufferRef _Nullable pixelBuffer;
		[NullAllowed, Export ("pixelBuffer")]
		CVPixelBuffer PixelBuffer { get; }

		// @property (readonly, nonatomic) CMSampleBufferRef _Nullable sampleBuffer;
		[NullAllowed, Export ("sampleBuffer")]
		CMSampleBuffer SampleBuffer { get; }

		// -(instancetype _Nullable)initWithUIImage:(UIImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithUIImage:error:")]
		NativeHandle Constructor (UIImage image, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithUIImage:(UIImage * _Nonnull)image orientation:(UIImageOrientation)orientation error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithUIImage:orientation:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (UIImage image, UIImageOrientation orientation, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithPixelBuffer:(CVPixelBufferRef _Nonnull)pixelBuffer error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithPixelBuffer:error:")]
		NativeHandle Constructor (CVPixelBuffer pixelBuffer, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithPixelBuffer:(CVPixelBufferRef _Nonnull)pixelBuffer orientation:(UIImageOrientation)orientation error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithPixelBuffer:orientation:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CVPixelBuffer pixelBuffer, UIImageOrientation orientation, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithSampleBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithSampleBuffer:error:")]
		NativeHandle Constructor (CMSampleBuffer sampleBuffer, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithSampleBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer orientation:(UIImageOrientation)orientation error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithSampleBuffer:orientation:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CMSampleBuffer sampleBuffer, UIImageOrientation orientation, [NullAllowed] out NSError error);
	}

	// @protocol MPPEmbeddingProvider <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface MPPEmbeddingProvider {
		// @required -(MPPEmbeddingResult * _Nullable)embedContent:(NSArray<id> * _Nonnull)content error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(content:)")));
		[Abstract]
		[Export ("embedContent:error:")]
		[return: NullAllowed]
		MPPEmbeddingResult Error (NSObject [] content, [NullAllowed] out NSError error);
	}

	// @interface MPPTaskPart : NSObject
	[BaseType (typeof (NSObject))]
	interface MPPTaskPart {
	}

	// @interface MPPTextPart : MPPTaskPart
	[BaseType (typeof (MPPTaskPart))]
	[DisableDefaultCtor]
	interface MPPTextPart {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// -(instancetype _Nonnull)initWithText:(NSString * _Nonnull)text;
		[Export ("initWithText:")]
		NativeHandle Constructor (string text);
	}

	// @interface MPPImagePart : MPPTaskPart
	[BaseType (typeof (MPPTaskPart))]
	[DisableDefaultCtor]
	interface MPPImagePart {
		// @property (readonly, copy, nonatomic) NSString * _Nullable filePath;
		[NullAllowed, Export ("filePath")]
		string FilePath { get; }

		// @property (readonly, copy, nonatomic) NSData * _Nullable data;
		[NullAllowed, Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		// -(instancetype _Nonnull)initWithFilePath:(NSString * _Nonnull)filePath;
		[Export ("initWithFilePath:")]
		NativeHandle Constructor (string filePath);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
		[Export ("initWithData:")]
		NativeHandle Constructor (NSData data);

		// -(instancetype _Nonnull)initWithFilePath:(NSString * _Nullable)filePath data:(NSData * _Nullable)data __attribute__((objc_designated_initializer));
		[Export ("initWithFilePath:data:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] string filePath, [NullAllowed] NSData data);
	}

	// @interface MPPAudioPart : MPPTaskPart
	[BaseType (typeof (MPPTaskPart))]
	[DisableDefaultCtor]
	interface MPPAudioPart {
		// @property (readonly, copy, nonatomic) NSString * _Nullable filePath;
		[NullAllowed, Export ("filePath")]
		string FilePath { get; }

		// @property (readonly, copy, nonatomic) NSData * _Nullable data;
		[NullAllowed, Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		// -(instancetype _Nonnull)initWithFilePath:(NSString * _Nonnull)filePath;
		[Export ("initWithFilePath:")]
		NativeHandle Constructor (string filePath);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
		[Export ("initWithData:")]
		NativeHandle Constructor (NSData data);

		// -(instancetype _Nonnull)initWithFilePath:(NSString * _Nullable)filePath data:(NSData * _Nullable)data __attribute__((objc_designated_initializer));
		[Export ("initWithFilePath:data:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] string filePath, [NullAllowed] NSData data);
	}

	// @interface MPPRetrievalRecord : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPRetrievalRecord {
		// @property (readonly, copy, nonatomic) NS_SWIFT_NAME(id) NSString * recordId __attribute__((swift_name("id")));
		[Export ("recordId")]
		string RecordId { get; }

		// @property (readonly, copy, nonatomic) NSArray<MPPTaskPart *> * _Nonnull content;
		[Export ("content", ArgumentSemantic.Copy)]
		MPPTaskPart [] Content { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull embeddings;
		[Export ("embeddings", ArgumentSemantic.Copy)]
		NSNumber [] Embeddings { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable similarityScore;
		[NullAllowed, Export ("similarityScore")]
		NSNumber SimilarityScore { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Metadata { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable parentId;
		[NullAllowed, Export ("parentId")]
		string ParentId { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable childIds;
		[NullAllowed, Export ("childIds", ArgumentSemantic.Copy)]
		string [] ChildIds { get; }

		// -(instancetype _Nonnull)initWithRecordId:(NSString * _Nonnull)recordId content:(NSArray<MPPTaskPart *> * _Nonnull)content embeddings:(NSArray<NSNumber *> * _Nonnull)embeddings similarityScore:(NSNumber * _Nullable)similarityScore metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata parentId:(NSString * _Nullable)parentId childIds:(NSArray<NSString *> * _Nullable)childIds __attribute__((objc_designated_initializer)) __attribute__((swift_name("init(id:content:embeddings:similarityScore:metadata:parentId:childIds:)")));
		[Export ("initWithRecordId:content:embeddings:similarityScore:metadata:parentId:childIds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string recordId, MPPTaskPart [] content, NSNumber [] embeddings, [NullAllowed] NSNumber similarityScore, NSDictionary<NSString, NSString> metadata, [NullAllowed] string parentId, [NullAllowed] string [] childIds);

		// -(instancetype _Nonnull)initWithRecordId:(NSString * _Nonnull)recordId content:(NSArray<MPPTaskPart *> * _Nonnull)content embeddings:(NSArray<NSNumber *> * _Nonnull)embeddings metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata parentId:(NSString * _Nullable)parentId childIds:(NSArray<NSString *> * _Nullable)childIds __attribute__((swift_name("init(id:content:embeddings:metadata:parentId:childIds:)")));
		[Export ("initWithRecordId:content:embeddings:metadata:parentId:childIds:")]
		NativeHandle Constructor (string recordId, MPPTaskPart [] content, NSNumber [] embeddings, NSDictionary<NSString, NSString> metadata, [NullAllowed] string parentId, [NullAllowed] string [] childIds);
	}

	// @interface MPPRetrievalResult : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPRetrievalResult {
		// @property (readonly, copy, nonatomic) NS_SWIFT_NAME(id) NSString * recordId __attribute__((swift_name("id")));
		[Export ("recordId")]
		string RecordId { get; }

		// @property (readonly, copy, nonatomic) NSArray<MPPTaskPart *> * _Nonnull content;
		[Export ("content", ArgumentSemantic.Copy)]
		MPPTaskPart [] Content { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable embeddings;
		[NullAllowed, Export ("embeddings", ArgumentSemantic.Copy)]
		NSNumber [] Embeddings { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Metadata { get; }

		// @property (readonly, nonatomic) double score;
		[Export ("score")]
		double Score { get; }

		// -(instancetype _Nonnull)initWithRecordId:(NSString * _Nonnull)recordId content:(NSArray<MPPTaskPart *> * _Nonnull)content embeddings:(NSArray<NSNumber *> * _Nullable)embeddings metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata score:(double)score __attribute__((objc_designated_initializer)) __attribute__((swift_name("init(id:content:embeddings:metadata:score:)")));
		[Export ("initWithRecordId:content:embeddings:metadata:score:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string recordId, MPPTaskPart [] content, [NullAllowed] NSNumber [] embeddings, NSDictionary<NSString, NSString> metadata, double score);

		// -(instancetype _Nonnull)initWithRecordId:(NSString * _Nonnull)recordId content:(NSArray<MPPTaskPart *> * _Nonnull)content metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata score:(double)score __attribute__((swift_name("init(id:content:metadata:score:)")));
		[Export ("initWithRecordId:content:metadata:score:")]
		NativeHandle Constructor (string recordId, MPPTaskPart [] content, NSDictionary<NSString, NSString> metadata, double score);
	}

	// @protocol MPPVectorStore <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface MPPVectorStore {
		// @required -(BOOL)upsertRecords:(NSArray<MPPRetrievalRecord *> * _Nonnull)records error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("upsertRecords(_:)")));
		[Abstract]
		[Export ("upsertRecords:error:")]
		bool UpsertRecords (MPPRetrievalRecord [] records, [NullAllowed] out NSError error);

		// @required -(BOOL)deleteWithIds:(NSArray<NSString *> * _Nonnull)ids error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("delete(withIds:)")));
		[Abstract]
		[Export ("deleteWithIds:error:")]
		bool DeleteWithIds (string [] ids, [NullAllowed] out NSError error);

		// @required -(BOOL)deleteAllRecords:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("deleteAllRecords()")));
		[Abstract]
		[Export ("deleteAllRecords:")]
		bool DeleteAllRecords ([NullAllowed] out NSError error);

		// @optional -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding limit:(NSInteger)limit error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:limit:)")));
		[Export ("searchWithEmbedding:limit:error:")]
		[return: NullAllowed]
		MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, nint limit, [NullAllowed] out NSError error);

		// @optional -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding limit:(NSInteger)limit metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:limit:metadataFilter:)")));
		[Export ("searchWithEmbedding:limit:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, nint limit, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// @optional -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding topK:(NSInteger)topK error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:topK:)"))) __attribute__((deprecated("Use searchWithEmbedding:limit:error: instead.")));
		[Export ("searchWithEmbedding:topK:error:")]
		[return: NullAllowed]
		MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, uint topK, [NullAllowed] out NSError error);

		// @optional -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding topK:(NSInteger)topK metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:topK:metadataFilter:)"))) __attribute__((deprecated("Use searchWithEmbedding:limit:metadataFilter:error: instead.")));
		[Export ("searchWithEmbedding:topK:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, uint topK, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// @required -(BOOL)deleteWithMetadataFilter:(NSDictionary<NSString *,NSString *> * _Nonnull)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("delete(withMetadataFilter:)")));
		[Abstract]
		[Export ("deleteWithMetadataFilter:error:")]
		bool DeleteWithMetadataFilter (NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// @required -(NSArray<MPPRetrievalRecord *> * _Nullable)getRecordsWithIds:(NSArray<NSString *> * _Nonnull)ids error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("getRecordsWithIds(_:)")));
		[Abstract]
		[Export ("getRecordsWithIds:error:")]
		[return: NullAllowed]
		MPPRetrievalRecord [] GetRecordsWithIds (string [] ids, [NullAllowed] out NSError error);

		// @required -(MPPRetrievalRecord * _Nullable)getRecordWithId:(NSString * _Nonnull)recordId error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("getRecord(withId:)")));
		[Abstract]
		[Export ("getRecordWithId:error:")]
		[return: NullAllowed]
		MPPRetrievalRecord GetRecordWithId (string recordId, [NullAllowed] out NSError error);

		// @required -(NSArray<NSString *> * _Nullable)recordIdentifiers:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("recordIdentifiers()")));
		[Abstract]
		[Export ("recordIdentifiers:")]
		[return: NullAllowed]
		string [] RecordIdentifiers ([NullAllowed] out NSError error);
	}

	// @interface MPPSemanticRetrieverComponents : NSObject
	[BaseType (typeof (NSObject))]
	interface MPPSemanticRetrieverComponents {
		// @property (nonatomic, strong) id<MPPTextChunker> _Nonnull chunker;
		[Export ("chunker", ArgumentSemantic.Strong)]
		MPPTextChunker Chunker { get; set; }

		// @property (nonatomic, strong) id<MPPVectorStore> _Nonnull vectorStore;
		[Export ("vectorStore", ArgumentSemantic.Strong)]
		MPPVectorStore VectorStore { get; set; }

		// @property (copy, nonatomic) NSArray<id<MPPEmbeddingProvider>> * _Nonnull providers;
		[Export ("providers", ArgumentSemantic.Copy)]
		MPPEmbeddingProvider [] Providers { get; set; }

		// -(instancetype _Nullable)initWithVectorStore:(id<MPPVectorStore> _Nonnull)vectorStore chunker:(id<MPPTextChunker> _Nullable)chunker providers:(NSArray<id<MPPEmbeddingProvider>> * _Nonnull)providers error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithVectorStore:chunker:providers:error:")]
		NativeHandle Constructor (MPPVectorStore vectorStore, [NullAllowed] MPPTextChunker chunker, MPPEmbeddingProvider [] providers, [NullAllowed] out NSError error);
	}

	[Static]
	partial interface Constants {
		// extern const NSInteger MPPSemanticRetrieverDefaultEmbeddingDimension;
		[Field ("MPPSemanticRetrieverDefaultEmbeddingDimension", "__Internal")]
		nint MPPSemanticRetrieverDefaultEmbeddingDimension { get; }
	}

	// @interface MPPSemanticRetriever : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPPSemanticRetriever {
		// +(instancetype _Nullable)createFromComponents:(MPPSemanticRetrieverComponents * _Nonnull)components error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("create(fromComponents:)")));
		[Static]
		[Export ("createFromComponents:error:")]
		[return: NullAllowed]
		MPPSemanticRetriever CreateFromComponents (MPPSemanticRetrieverComponents components, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithComponents:(MPPSemanticRetrieverComponents * _Nonnull)components error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithComponents:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPSemanticRetrieverComponents components, [NullAllowed] out NSError error);

		// -(BOOL)insertDocumentWithId:(NSString * _Nonnull)recordId text:(NSString * _Nonnull)text error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertDocument(withId:text:)")));
		[Export ("insertDocumentWithId:text:error:")]
		bool InsertDocumentWithId (string recordId, string text, [NullAllowed] out NSError error);

		// -(BOOL)insertDocumentWithId:(NSString * _Nonnull)recordId text:(NSString * _Nonnull)text metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertDocument(withId:text:metadata:)")));
		[Export ("insertDocumentWithId:text:metadata:error:")]
		bool InsertDocumentWithId (string recordId, string text, NSDictionary<NSString, NSString> metadata, [NullAllowed] out NSError error);

		// -(BOOL)insertImageWithId:(NSString * _Nonnull)recordId filePath:(NSString * _Nonnull)filePath error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertImage(withId:filePath:)")));
		[Export ("insertImageWithId:filePath:error:")]
		bool InsertImageWithId (string recordId, string filePath, [NullAllowed] out NSError error);

		// -(BOOL)insertImageWithId:(NSString * _Nonnull)recordId filePath:(NSString * _Nonnull)filePath metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertImage(withId:filePath:metadata:)")));
		[Export ("insertImageWithId:filePath:metadata:error:")]
		bool InsertImageWithId (string recordId, string filePath, NSDictionary<NSString, NSString> metadata, [NullAllowed] out NSError error);

		// -(BOOL)insertAudioWithId:(NSString * _Nonnull)recordId filePath:(NSString * _Nonnull)filePath error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertAudio(withId:filePath:)")));
		[Export ("insertAudioWithId:filePath:error:")]
		bool InsertAudioWithId (string recordId, string filePath, [NullAllowed] out NSError error);

		// -(BOOL)insertAudioWithId:(NSString * _Nonnull)recordId filePath:(NSString * _Nonnull)filePath metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertAudio(withId:filePath:metadata:)")));
		[Export ("insertAudioWithId:filePath:metadata:error:")]
		bool InsertAudioWithId (string recordId, string filePath, NSDictionary<NSString, NSString> metadata, [NullAllowed] out NSError error);

		// -(BOOL)insertContentWithId:(NSString * _Nonnull)recordId parts:(NSArray<MPPTaskPart *> * _Nonnull)parts error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertContent(withId:parts:)")));
		[Export ("insertContentWithId:parts:error:")]
		bool InsertContentWithId (string recordId, MPPTaskPart [] parts, [NullAllowed] out NSError error);

		// -(BOOL)insertContentWithId:(NSString * _Nonnull)recordId parts:(NSArray<MPPTaskPart *> * _Nonnull)parts metadata:(NSDictionary<NSString *,NSString *> * _Nonnull)metadata error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("insertContent(withId:parts:metadata:)")));
		[Export ("insertContentWithId:parts:metadata:error:")]
		bool InsertContentWithId (string recordId, MPPTaskPart [] parts, NSDictionary<NSString, NSString> metadata, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithText:(NSString * _Nonnull)queryText limit:(NSInteger)limit error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withText:limit:)")));
		[Export ("retrieveWithText:limit:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithText (string queryText, nint limit, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithText:(NSString * _Nonnull)queryText limit:(NSInteger)limit metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withText:limit:metadataFilter:)")));
		[Export ("retrieveWithText:limit:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithText (string queryText, nint limit, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithParts:(NSArray<MPPTaskPart *> * _Nonnull)queryParts limit:(NSInteger)limit error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withParts:limit:)")));
		[Export ("retrieveWithParts:limit:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithParts (MPPTaskPart [] queryParts, nint limit, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithParts:(NSArray<MPPTaskPart *> * _Nonnull)queryParts limit:(NSInteger)limit metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withParts:limit:metadataFilter:)")));
		[Export ("retrieveWithParts:limit:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithParts (MPPTaskPart [] queryParts, nint limit, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding limit:(NSInteger)limit error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withEmbedding:limit:)")));
		[Export ("retrieveWithEmbedding:limit:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithEmbedding (NSNumber [] queryEmbedding, nint limit, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding limit:(NSInteger)limit metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withEmbedding:limit:metadataFilter:)")));
		[Export ("retrieveWithEmbedding:limit:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithEmbedding (NSNumber [] queryEmbedding, nint limit, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithText:(NSString * _Nonnull)queryText topK:(NSInteger)topK error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withText:topK:)"))) __attribute__((deprecated("Use retrieveWithText:limit:error: instead.")));
		[Export ("retrieveWithText:topK:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithText (string queryText, uint topK, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithText:(NSString * _Nonnull)queryText topK:(NSInteger)topK metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withText:topK:metadataFilter:)"))) __attribute__((deprecated("Use retrieveWithText:limit:metadataFilter:error: instead.")));
		[Export ("retrieveWithText:topK:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithText (string queryText, uint topK, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithParts:(NSArray<MPPTaskPart *> * _Nonnull)queryParts topK:(NSInteger)topK error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withParts:topK:)"))) __attribute__((deprecated("Use retrieveWithParts:limit:error: instead.")));
		[Export ("retrieveWithParts:topK:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithParts (MPPTaskPart [] queryParts, uint topK, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithParts:(NSArray<MPPTaskPart *> * _Nonnull)queryParts topK:(NSInteger)topK metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withParts:topK:metadataFilter:)"))) __attribute__((deprecated("Use retrieveWithParts:limit:metadataFilter:error: instead.")));
		[Export ("retrieveWithParts:topK:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithParts (MPPTaskPart [] queryParts, uint topK, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding topK:(NSInteger)topK error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withEmbedding:topK:)"))) __attribute__((deprecated("Use retrieveWithEmbedding:limit:error: instead.")));
		[Export ("retrieveWithEmbedding:topK:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithEmbedding (NSNumber [] queryEmbedding, uint topK, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalResult *> * _Nullable)retrieveWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding topK:(NSInteger)topK metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("retrieve(withEmbedding:topK:metadataFilter:)"))) __attribute__((deprecated("Use retrieveWithEmbedding:limit:metadataFilter:error: instead.")));
		[Export ("retrieveWithEmbedding:topK:metadataFilter:error:")]
		[return: NullAllowed]
		MPPRetrievalResult [] RetrieveWithEmbedding (NSNumber [] queryEmbedding, uint topK, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(BOOL)deleteWithIds:(NSArray<NSString *> * _Nonnull)ids error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("delete(withIds:)")));
		[Export ("deleteWithIds:error:")]
		bool DeleteWithIds (string [] ids, [NullAllowed] out NSError error);

		// -(BOOL)deleteWithMetadataFilter:(NSDictionary<NSString *,NSString *> * _Nonnull)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("delete(withMetadataFilter:)")));
		[Export ("deleteWithMetadataFilter:error:")]
		bool DeleteWithMetadataFilter (NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(BOOL)deleteAllRecordsWithError:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("deleteAllRecords()")));
		[Export ("deleteAllRecordsWithError:")]
		bool DeleteAllRecordsWithError ([NullAllowed] out NSError error);

		// -(NSArray<NSString *> * _Nullable)getAllRecordIdsWithError:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("getAllRecordIds()")));
		[Export ("getAllRecordIdsWithError:")]
		[return: NullAllowed]
		string [] GetAllRecordIdsWithError ([NullAllowed] out NSError error);
	}

	// @interface MPPSqliteVectorStore : NSObject <MPPVectorStore>
	[BaseType (typeof (MPPVectorStore))]
	[DisableDefaultCtor]
	interface MPPSqliteVectorStore : MPPVectorStore {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull databasePath;
		[Export ("databasePath")]
		string DatabasePath { get; }

		// -(instancetype _Nonnull)initWithDatabasePath:(NSString * _Nonnull)databasePath embeddingDimension:(NSInteger)embeddingDimension __attribute__((objc_designated_initializer));
		[Export ("initWithDatabasePath:embeddingDimension:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string databasePath, nint embeddingDimension);

		// -(BOOL)upsertRecords:(NSArray<MPPRetrievalRecord *> * _Nonnull)records error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("upsertRecords(_:)")));
		[Export ("upsertRecords:error:")]
		[Override]
		new bool UpsertRecords (MPPRetrievalRecord [] records, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding limit:(NSInteger)limit error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:limit:)")));
		[Export ("searchWithEmbedding:limit:error:")]
		[return: NullAllowed]
		[Override]
		new MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, nint limit, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding limit:(NSInteger)limit metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:limit:metadataFilter:)")));
		[Export ("searchWithEmbedding:limit:metadataFilter:error:")]
		[return: NullAllowed]
		[Override]
		new MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, nint limit, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding topK:(NSInteger)topK error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:topK:)"))) __attribute__((deprecated("Use searchWithEmbedding:limit:error: instead.")));
		[Export ("searchWithEmbedding:topK:error:")]
		[return: NullAllowed]
		[Override]
		new MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, uint topK, [NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalRecord *> * _Nullable)searchWithEmbedding:(NSArray<NSNumber *> * _Nonnull)queryEmbedding topK:(NSInteger)topK metadataFilter:(NSDictionary<NSString *,NSString *> * _Nullable)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("search(withEmbedding:topK:metadataFilter:)"))) __attribute__((deprecated("Use searchWithEmbedding:limit:metadataFilter:error: instead.")));
		[Export ("searchWithEmbedding:topK:metadataFilter:error:")]
		[return: NullAllowed]
		[Override]
		new MPPRetrievalRecord [] SearchWithEmbedding (NSNumber [] queryEmbedding, uint topK, [NullAllowed] NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(BOOL)deleteWithMetadataFilter:(NSDictionary<NSString *,NSString *> * _Nonnull)metadataFilter error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("delete(withMetadataFilter:)")));
		[Export ("deleteWithMetadataFilter:error:")]
		[Override]
		new bool DeleteWithMetadataFilter (NSDictionary<NSString, NSString> metadataFilter, [NullAllowed] out NSError error);

		// -(BOOL)deleteWithIds:(NSArray<NSString *> * _Nonnull)ids error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("delete(withIds:)")));
		[Export ("deleteWithIds:error:")]
		[Override]
		new bool DeleteWithIds (string [] ids, [NullAllowed] out NSError error);

		// -(BOOL)deleteAllRecords:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("deleteAllRecords()")));
		[Export ("deleteAllRecords:")]
		[Override]
		new bool DeleteAllRecords ([NullAllowed] out NSError error);

		// -(NSArray<MPPRetrievalRecord *> * _Nullable)getRecordsWithIds:(NSArray<NSString *> * _Nonnull)ids error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("getRecordsWithIds(_:)")));
		[Export ("getRecordsWithIds:error:")]
		[return: NullAllowed]
		[Override]
		new MPPRetrievalRecord [] GetRecordsWithIds (string [] ids, [NullAllowed] out NSError error);

		// -(MPPRetrievalRecord * _Nullable)getRecordWithId:(NSString * _Nonnull)recordId error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("getRecord(withId:)")));
		[Export ("getRecordWithId:error:")]
		[return: NullAllowed]
		[Override]
		new MPPRetrievalRecord GetRecordWithId (string recordId, [NullAllowed] out NSError error);

		// -(NSArray<NSString *> * _Nullable)recordIdentifiers:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("recordIdentifiers()")));
		[Export ("recordIdentifiers:")]
		[return: NullAllowed]
		[Override]
		new string [] RecordIdentifiers ([NullAllowed] out NSError error);
	}

	// @interface MPPTaskOptions : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface MPPTaskOptions : INSCopying {
		// @property (copy, nonatomic) MPPBaseOptions * _Nonnull baseOptions;
		[Export ("baseOptions", ArgumentSemantic.Copy)]
		MPPBaseOptions BaseOptions { get; set; }
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

	// @interface MPPUniversalEmbedderOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof (MPPTaskOptions))]
	interface MPPUniversalEmbedderOptions : INSCopying {
		// @property (nonatomic) BOOL l2Normalize;
		[Export ("l2Normalize")]
		bool L2Normalize { get; set; }

		// @property (nonatomic) NSInteger maxInputLength;
		[Export ("maxInputLength")]
		nint MaxInputLength { get; set; }

		// @property (nonatomic) NSInteger visionTokensPerImage;
		[Export ("visionTokensPerImage")]
		nint VisionTokensPerImage { get; set; }

		// @property (nonatomic) MPPActivationDataType activationDataType;
		[Export ("activationDataType", ArgumentSemantic.Assign)]
		MPPActivationDataType ActivationDataType { get; set; }

		// @property (copy, nonatomic) NS_SWIFT_NAME(cacheDirectory) NSString * cacheDir __attribute__((swift_name("cacheDirectory")));
		[Export ("cacheDir")]
		string CacheDir { get; set; }

		[Wrap ("WeakTextDelegate")]
		MPPDelegate TextDelegate { get; set; }

		// @property (nonatomic) MPPDelegate textDelegate;
		[NullAllowed, Export ("textDelegate", ArgumentSemantic.Assign)]
		MPPDelegate WeakTextDelegate { get; set; }

		[Wrap ("WeakVisionDelegate")]
		MPPDelegate VisionDelegate { get; set; }

		// @property (nonatomic) MPPDelegate visionDelegate;
		[NullAllowed, Export ("visionDelegate", ArgumentSemantic.Assign)]
		MPPDelegate WeakVisionDelegate { get; set; }

		[Wrap ("WeakAudioDelegate")]
		MPPDelegate AudioDelegate { get; set; }

		// @property (nonatomic) MPPDelegate audioDelegate;
		[NullAllowed, Export ("audioDelegate", ArgumentSemantic.Assign)]
		MPPDelegate WeakAudioDelegate { get; set; }
	}

	// @interface MPPUniversalEmbedder : NSObject <MPPEmbeddingProvider>
	[BaseType (typeof (MPPEmbeddingProvider))]
	[DisableDefaultCtor]
	interface MPPUniversalEmbedder : MPPEmbeddingProvider {
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPUniversalEmbedderOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPUniversalEmbedderOptions options, [NullAllowed] out NSError error);

		// -(MPPEmbeddingResult * _Nullable)embedText:(NSString * _Nonnull)text error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(text:)")));
		[Export ("embedText:error:")]
		[return: NullAllowed]
		MPPEmbeddingResult EmbedText (string text, [NullAllowed] out NSError error);

		// -(MPPEmbeddingResult * _Nullable)embedImageBytes:(NSData * _Nonnull)imageBytes error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(imageBytes:)")));
		[Export ("embedImageBytes:error:")]
		[return: NullAllowed]
		MPPEmbeddingResult EmbedImageBytes (NSData imageBytes, [NullAllowed] out NSError error);

		// -(MPPEmbeddingResult * _Nullable)embedImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(image:)")));
		[Export ("embedImage:error:")]
		[return: NullAllowed]
		MPPEmbeddingResult EmbedImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPEmbeddingResult * _Nullable)embedAudioFloatBuffer:(MPPFloatBuffer * _Nonnull)audioData error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(audioFloatBuffer:)")));
		[Export ("embedAudioFloatBuffer:error:")]
		[return: NullAllowed]
		MPPEmbeddingResult EmbedAudioFloatBuffer (MPPFloatBuffer audioData, [NullAllowed] out NSError error);

		// -(MPPEmbeddingResult * _Nullable)embedAudio:(MPPAudioData * _Nonnull)audioData error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(audio:)")));
		[Export ("embedAudio:error:")]
		[return: NullAllowed]
		MPPEmbeddingResult EmbedAudio (MPPAudioData audioData, [NullAllowed] out NSError error);

		// -(MPPEmbeddingResult * _Nullable)embedContent:(NSArray<id> * _Nonnull)content error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(content:)")));
		[Export ("embedContent:error:")]
		[return: NullAllowed]
		MPPEmbeddingResult EmbedContent (NSObject [] content, [NullAllowed] out NSError error);

		// +(NSNumber * _Nullable)cosineSimilarityBetweenEmbedding1:(MPPEmbedding * _Nonnull)embedding1 andEmbedding2:(MPPEmbedding * _Nonnull)embedding2 error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("cosineSimilarity(embedding1:embedding2:)")));
		[Static]
		[Export ("cosineSimilarityBetweenEmbedding1:andEmbedding2:error:")]
		[return: NullAllowed]
		NSNumber CosineSimilarityBetweenEmbedding1 (MPPEmbedding embedding1, MPPEmbedding embedding2, [NullAllowed] out NSError error);
	}
}
