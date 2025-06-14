using System;
using CoreGraphics;
using Foundation;
using MediaPipeTasksGenAI;
using ObjCRuntime;

namespace MediaPipeTasksGenAI
{
	// @interface MPPLLMInference : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPLLMInference
	{
		// -(instancetype _Nullable)initWithOptions:(MPPLLMInferenceOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPLLMInferenceOptions options, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(NSString * _Nullable)generateResponseWithInputText:(NSString * _Nonnull)inputText error:(NSError * _Nullable * _Nullable)error __attribute__((warn_unused_result("")));
		[Export ("generateResponseWithInputText:error:")]
		[return: NullAllowed]
		string GenerateResponseWithInputText (string inputText, [NullAllowed] out NSError error);

		// -(BOOL)generateResponseAsyncWithInputText:(NSString * _Nonnull)inputText error:(NSError * _Nullable * _Nullable)error progress:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))progress completion:(void (^ _Nonnull)(void))completion;
		[Export ("generateResponseAsyncWithInputText:error:progress:completion:")]
		bool GenerateResponseAsyncWithInputText (string inputText, [NullAllowed] out NSError error, Action<NSString, NSError> progress, Action completion);
	}

	// @interface MediaPipeTasksGenAI_Swift_389 (MPPLLMInference)
	[Category]
	[BaseType (typeof(MPPLLMInference))]
	interface MPPLLMInference_MediaPipeTasksGenAI_Swift_389
	{
	}

	// @interface MPPLLMInferenceSession : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPLLMInferenceSession
	{
		// -(instancetype _Nullable)initWithLlmInference:(MPPLLMInference * _Nonnull)llmInference options:(MPPLLMInferenceSessionOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithLlmInference:options:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPLLMInference llmInference, MPPLLMInferenceSessionOptions options, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithLlmInference:(MPPLLMInference * _Nonnull)llmInference error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithLlmInference:error:")]
		NativeHandle Constructor (MPPLLMInference llmInference, [NullAllowed] out NSError error);

		// -(BOOL)addQueryChunkWithInputText:(NSString * _Nonnull)inputText error:(NSError * _Nullable * _Nullable)error;
		[Export ("addQueryChunkWithInputText:error:")]
		bool AddQueryChunkWithInputText (string inputText, [NullAllowed] out NSError error);

		// -(BOOL)addImageWithImage:(CGImageRef _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export ("addImageWithImage:error:")]
		bool AddImageWithImage (CGImage image, [NullAllowed] out NSError error);

		// -(NSString * _Nullable)generateResponseAndReturnError:(NSError * _Nullable * _Nullable)error __attribute__((warn_unused_result("")));
		[Export ("generateResponseAndReturnError:")]
		[return: NullAllowed]
		string GenerateResponseAndReturnError ([NullAllowed] out NSError error);

		// -(BOOL)generateResponseAsyncAndReturnError:(NSError * _Nullable * _Nullable)error progress:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))progress completion:(void (^ _Nonnull)(void))completion;
		[Export ("generateResponseAsyncAndReturnError:progress:completion:")]
		bool GenerateResponseAsyncAndReturnError ([NullAllowed] out NSError error, Action<NSString, NSError> progress, Action completion);
	}

	// @interface MediaPipeTasksGenAI_Swift_466 (MPPLLMInference)
	[Category]
	[BaseType (typeof(MPPLLMInference))]
	interface MPPLLMInference_MediaPipeTasksGenAI_Swift_466
	{
	}

	// @interface MPPLLMInferenceMetrics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPLLMInferenceMetrics
	{
		// @property (readonly, nonatomic) NSTimeInterval initializationTimeInSeconds;
		[Export ("initializationTimeInSeconds")]
		double InitializationTimeInSeconds { get; }

		// -(instancetype _Nonnull)initWithInitializationTimeInSeconds:(NSTimeInterval)initializationTimeInSeconds __attribute__((objc_designated_initializer));
		[Export ("initWithInitializationTimeInSeconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (double initializationTimeInSeconds);
	}

	// @interface MediaPipeTasksGenAI_Swift_484 (MPPLLMInference)
	[Category]
	[BaseType (typeof(MPPLLMInference))]
	interface MPPLLMInference_MediaPipeTasksGenAI_Swift_484
	{
	}

	// @interface MPPLLMInferenceOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPLLMInferenceOptions
	{
		// @property (copy, nonatomic) NSString * _Nonnull modelPath;
		[Export ("modelPath")]
		string ModelPath { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull visionEncoderPath;
		[Export ("visionEncoderPath")]
		string VisionEncoderPath { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull visionAdapterPath;
		[Export ("visionAdapterPath")]
		string VisionAdapterPath { get; set; }

		// @property (nonatomic) NSInteger maxTokens;
		[Export ("maxTokens")]
		nint MaxTokens { get; set; }

		// @property (nonatomic) NSInteger maxImages;
		[Export ("maxImages")]
		nint MaxImages { get; set; }

		// @property (nonatomic) NSInteger maxTopk;
		[Export ("maxTopk")]
		nint MaxTopk { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull supportedLoraRanks;
		[Export ("supportedLoraRanks", ArgumentSemantic.Copy)]
		NSNumber[] SupportedLoraRanks { get; set; }

		// @property (nonatomic) BOOL waitForWeightUploads;
		[Export ("waitForWeightUploads")]
		bool WaitForWeightUploads { get; set; }

		// @property (nonatomic) BOOL useSubmodel;
		[Export ("useSubmodel")]
		bool UseSubmodel { get; set; }

		// @property (nonatomic) NSInteger sequenceBatchSize;
		[Export ("sequenceBatchSize")]
		nint SequenceBatchSize { get; set; }

		// -(instancetype _Nonnull)initWithModelPath:(NSString * _Nonnull)modelPath __attribute__((objc_designated_initializer));
		[Export ("initWithModelPath:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string modelPath);
	}

	// @interface MediaPipeTasksGenAI_Swift_533 (MPPLLMInferenceSession)
	[Category]
	[BaseType (typeof(MPPLLMInferenceSession))]
	interface MPPLLMInferenceSession_MediaPipeTasksGenAI_Swift_533
	{
	}

	// @interface MPPLLMInferenceSessionMetrics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPLLMInferenceSessionMetrics
	{
		// @property (readonly, nonatomic) NSTimeInterval responseGenerationTimeInSeconds;
		[Export ("responseGenerationTimeInSeconds")]
		double ResponseGenerationTimeInSeconds { get; }

		// -(instancetype _Nonnull)initWithResponseGenerationTimeInSeconds:(NSTimeInterval)responseGenerationTimeInSeconds __attribute__((objc_designated_initializer));
		[Export ("initWithResponseGenerationTimeInSeconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (double responseGenerationTimeInSeconds);
	}

	// @interface MediaPipeTasksGenAI_Swift_549 (MPPLLMInferenceSession)
	[Category]
	[BaseType (typeof(MPPLLMInferenceSession))]
	interface MPPLLMInferenceSession_MediaPipeTasksGenAI_Swift_549
	{
	}

	// @interface MPPLLMInferenceSessionOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface MPPLLMInferenceSessionOptions
	{
		// @property (nonatomic) NSInteger topk;
		[Export ("topk")]
		nint Topk { get; set; }

		// @property (nonatomic) float topp;
		[Export ("topp")]
		float Topp { get; set; }

		// @property (nonatomic) float temperature;
		[Export ("temperature")]
		float Temperature { get; set; }

		// @property (nonatomic) NSInteger randomSeed;
		[Export ("randomSeed")]
		nint RandomSeed { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable loraPath;
		[NullAllowed, Export ("loraPath")]
		string LoraPath { get; set; }

		// @property (nonatomic) BOOL enableVisionModality;
		[Export ("enableVisionModality")]
		bool EnableVisionModality { get; set; }
	}
}
