using System;
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

	// @interface MediaPipeTasksGenAI_Swift_345 (MPPLLMInference)
	[Category]
	[BaseType (typeof(MPPLLMInference))]
	interface MPPLLMInference_MediaPipeTasksGenAI_Swift_345
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

		// @property (nonatomic) NSInteger maxTokens;
		[Export ("maxTokens")]
		nint MaxTokens { get; set; }

		// @property (nonatomic) NSInteger topk;
		[Export ("topk")]
		nint Topk { get; set; }

		// @property (nonatomic) float temperature;
		[Export ("temperature")]
		float Temperature { get; set; }

		// @property (nonatomic) NSInteger randomSeed;
		[Export ("randomSeed")]
		nint RandomSeed { get; set; }

		// @property (nonatomic) NSInteger numOfSupportedLoraRanks;
		[Export ("numOfSupportedLoraRanks")]
		nint NumOfSupportedLoraRanks { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull supportedLoraRanks;
		[Export ("supportedLoraRanks", ArgumentSemantic.Copy)]
		NSNumber[] SupportedLoraRanks { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable loraPath;
		[NullAllowed, Export ("loraPath")]
		string LoraPath { get; set; }

		// -(instancetype _Nonnull)initWithModelPath:(NSString * _Nonnull)modelPath __attribute__((objc_designated_initializer));
		[Export ("initWithModelPath:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string modelPath);
	}
}
