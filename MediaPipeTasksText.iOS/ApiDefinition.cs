using System;
using Foundation;
using MediaPipeTasksText;
using ObjCRuntime;

namespace MediaPipeTasksText
{
	// @interface MPPBaseOptions : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface MPPBaseOptions : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nonnull modelAssetPath;
		[Export ("modelAssetPath")]
		string ModelAssetPath { get; set; }

		[Wrap ("WeakDelegate")]
		MPPDelegate Delegate { get; set; }

		// @property (nonatomic) MPPDelegate delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		MPPDelegate WeakDelegate { get; set; }
	}

	// @interface MPPCategory : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPCategory
	{
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
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPClassifications
	{
		// @property (readonly, nonatomic) NSInteger headIndex;
		[Export ("headIndex")]
		nint HeadIndex { get; }

		// @property (readonly, nonatomic) NSString * _Nullable headName;
		[NullAllowed, Export ("headName")]
		string HeadName { get; }

		// @property (readonly, nonatomic) NSArray<MPPCategory *> * _Nonnull categories;
		[Export ("categories")]
		MPPCategory[] Categories { get; }

		// -(instancetype _Nonnull)initWithHeadIndex:(NSInteger)headIndex categories:(NSArray<MPPCategory *> * _Nonnull)categories;
		[Export ("initWithHeadIndex:categories:")]
		NativeHandle Constructor (nint headIndex, MPPCategory[] categories);

		// -(instancetype _Nonnull)initWithHeadIndex:(NSInteger)headIndex headName:(NSString * _Nullable)headName categories:(NSArray<MPPCategory *> * _Nonnull)categories __attribute__((objc_designated_initializer));
		[Export ("initWithHeadIndex:headName:categories:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nint headIndex, [NullAllowed] string headName, MPPCategory[] categories);
	}

	// @interface MPPClassificationResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPClassificationResult
	{
		// @property (readonly, nonatomic) NSArray<MPPClassifications *> * _Nonnull classifications;
		[Export ("classifications")]
		MPPClassifications[] Classifications { get; }

		// @property (readonly, nonatomic) NSInteger timestampInMilliseconds;
		[Export ("timestampInMilliseconds")]
		nint TimestampInMilliseconds { get; }

		// -(instancetype _Nonnull)initWithClassifications:(NSArray<MPPClassifications *> * _Nonnull)classifications timestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithClassifications:timestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPClassifications[] classifications, nint timestampInMilliseconds);
	}

	// @interface MPPEmbedding : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPEmbedding
	{
		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable floatEmbedding;
		[NullAllowed, Export ("floatEmbedding")]
		NSNumber[] FloatEmbedding { get; }

		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable quantizedEmbedding;
		[NullAllowed, Export ("quantizedEmbedding")]
		NSNumber[] QuantizedEmbedding { get; }

		// @property (readonly, nonatomic) NSInteger headIndex;
		[Export ("headIndex")]
		nint HeadIndex { get; }

		// @property (readonly, nonatomic) NSString * _Nullable headName;
		[NullAllowed, Export ("headName")]
		string HeadName { get; }

		// -(instancetype _Nonnull)initWithFloatEmbedding:(NSArray<NSNumber *> * _Nullable)floatEmbedding quantizedEmbedding:(NSArray<NSNumber *> * _Nullable)quantizedEmbedding headIndex:(NSInteger)headIndex headName:(NSString * _Nullable)headName __attribute__((objc_designated_initializer));
		[Export ("initWithFloatEmbedding:quantizedEmbedding:headIndex:headName:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSNumber[] floatEmbedding, [NullAllowed] NSNumber[] quantizedEmbedding, nint headIndex, [NullAllowed] string headName);
	}

	// @interface MPPEmbeddingResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPEmbeddingResult
	{
		// @property (readonly, nonatomic) NSArray<MPPEmbedding *> * _Nonnull embeddings;
		[Export ("embeddings")]
		MPPEmbedding[] Embeddings { get; }

		// @property (readonly, nonatomic) NSInteger timestampInMilliseconds;
		[Export ("timestampInMilliseconds")]
		nint TimestampInMilliseconds { get; }

		// -(instancetype _Nonnull)initWithEmbeddings:(NSArray<MPPEmbedding *> * _Nonnull)embeddings timestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithEmbeddings:timestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPEmbedding[] embeddings, nint timestampInMilliseconds);
	}

	// @interface MPPTaskOptions : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface MPPTaskOptions : INSCopying
	{
		// @property (copy, nonatomic) MPPBaseOptions * _Nonnull baseOptions;
		[Export ("baseOptions", ArgumentSemantic.Copy)]
		MPPBaseOptions BaseOptions { get; set; }
	}

	// @interface MPPLanguageDetectorOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPLanguageDetectorOptions : INSCopying
	{
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
		string[] CategoryAllowlist { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull categoryDenylist;
		[Export ("categoryDenylist", ArgumentSemantic.Copy)]
		string[] CategoryDenylist { get; set; }
	}

	// @interface MPPTaskResult : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPTaskResult : INSCopying
	{
		// @property (readonly, assign, nonatomic) NSInteger timestampInMilliseconds;
		[Export ("timestampInMilliseconds")]
		nint TimestampInMilliseconds { get; }

		// -(instancetype _Nonnull)initWithTimestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithTimestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nint timestampInMilliseconds);
	}

	// @interface MPPLanguagePrediction : NSObject
	[BaseType (typeof(NSObject))]
	interface MPPLanguagePrediction
	{
		// @property (readonly, nonatomic) NSString * _Nonnull languageCode;
		[Export ("languageCode")]
		string LanguageCode { get; }

		// @property (readonly, nonatomic) float probability;
		[Export ("probability")]
		float Probability { get; }

		// -(instancetype _Nonnull)initWithLanguageCode:(NSString * _Nonnull)languageCode probability:(float)probability;
		[Export ("initWithLanguageCode:probability:")]
		NativeHandle Constructor (string languageCode, float probability);
	}

	// @interface MPPLanguageDetectorResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	[DisableDefaultCtor]
	interface MPPLanguageDetectorResult
	{
		// @property (readonly, nonatomic) NSArray<MPPLanguagePrediction *> * _Nonnull languagePredictions;
		[Export ("languagePredictions")]
		MPPLanguagePrediction[] LanguagePredictions { get; }

		// -(instancetype _Nonnull)initWithLanguagePredictions:(NSArray<MPPLanguagePrediction *> * _Nonnull)languagePredictions timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithLanguagePredictions:timestampInMilliseconds:")]
		NativeHandle Constructor (MPPLanguagePrediction[] languagePredictions, nint timestampInMilliseconds);
	}

	// @interface MPPLanguageDetector : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPLanguageDetector
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPLanguageDetectorOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPLanguageDetectorOptions options, [NullAllowed] out NSError error);

		// -(MPPLanguageDetectorResult * _Nullable)detectText:(NSString * _Nonnull)text error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(text:)")));
		[Export ("detectText:error:")]
		[return: NullAllowed]
		MPPLanguageDetectorResult DetectText (string text, [NullAllowed] out NSError error);
	}

	// @interface MPPTextClassifierOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPTextClassifierOptions : INSCopying
	{
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
		string[] CategoryAllowlist { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull categoryDenylist;
		[Export ("categoryDenylist", ArgumentSemantic.Copy)]
		string[] CategoryDenylist { get; set; }
	}

	// @interface MPPTextClassifierResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPTextClassifierResult
	{
		// @property (readonly, nonatomic) MPPClassificationResult * _Nonnull classificationResult;
		[Export ("classificationResult")]
		MPPClassificationResult ClassificationResult { get; }

		// -(instancetype _Nonnull)initWithClassificationResult:(MPPClassificationResult * _Nonnull)classificationResult timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithClassificationResult:timestampInMilliseconds:")]
		NativeHandle Constructor (MPPClassificationResult classificationResult, nint timestampInMilliseconds);
	}

	// @interface MPPTextClassifier : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPTextClassifier
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPTextClassifierOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPTextClassifierOptions options, [NullAllowed] out NSError error);

		// -(MPPTextClassifierResult * _Nullable)classifyText:(NSString * _Nonnull)text error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classify(text:)")));
		[Export ("classifyText:error:")]
		[return: NullAllowed]
		MPPTextClassifierResult ClassifyText (string text, [NullAllowed] out NSError error);
	}

	// @interface MPPTextEmbedderOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPTextEmbedderOptions : INSCopying
	{
		// @property (nonatomic) BOOL l2Normalize;
		[Export ("l2Normalize")]
		bool L2Normalize { get; set; }

		// @property (nonatomic) BOOL quantize;
		[Export ("quantize")]
		bool Quantize { get; set; }
	}

	// @interface MPPTextEmbedderResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	[DisableDefaultCtor]
	interface MPPTextEmbedderResult
	{
		// @property (readonly, nonatomic) MPPEmbeddingResult * _Nonnull embeddingResult;
		[Export ("embeddingResult")]
		MPPEmbeddingResult EmbeddingResult { get; }

		// -(instancetype _Nonnull)initWithEmbeddingResult:(MPPEmbeddingResult * _Nonnull)embeddingResult timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithEmbeddingResult:timestampInMilliseconds:")]
		NativeHandle Constructor (MPPEmbeddingResult embeddingResult, nint timestampInMilliseconds);
	}

	// @interface MPPTextEmbedder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPTextEmbedder
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPTextEmbedderOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPTextEmbedderOptions options, [NullAllowed] out NSError error);

		// -(MPPTextEmbedderResult * _Nullable)embedText:(NSString * _Nonnull)text error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(text:)")));
		[Export ("embedText:error:")]
		[return: NullAllowed]
		MPPTextEmbedderResult EmbedText (string text, [NullAllowed] out NSError error);

		// +(NSNumber * _Nullable)cosineSimilarityBetweenEmbedding1:(MPPEmbedding * _Nonnull)embedding1 andEmbedding2:(MPPEmbedding * _Nonnull)embedding2 error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("cosineSimilarity(embedding1:embedding2:)")));
		[Static]
		[Export ("cosineSimilarityBetweenEmbedding1:andEmbedding2:error:")]
		[return: NullAllowed]
		NSNumber CosineSimilarityBetweenEmbedding1 (MPPEmbedding embedding1, MPPEmbedding embedding2, [NullAllowed] out NSError error);
	}
}
