using System;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using MediaPipeTasksVision;
using ObjCRuntime;
using UIKit;

namespace MediaPipeTasksVision
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
		NSObject WeakDelegate { get; set; }
	}

	// @interface MPPCategory : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPCategory : INativeObject
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

	// @interface MPPClassifierOptions : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface MPPClassifierOptions : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable displayNamesLocale;
		[NullAllowed, Export ("displayNamesLocale")]
		string DisplayNamesLocale { get; set; }

		// @property (nonatomic) NSInteger maxResults;
		[Export ("maxResults")]
		nint MaxResults { get; set; }

		// @property (nonatomic) float scoreThreshold;
		[Export ("scoreThreshold")]
		float ScoreThreshold { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable categoryAllowlist;
		[NullAllowed, Export ("categoryAllowlist", ArgumentSemantic.Copy)]
		string[] CategoryAllowlist { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable categoryDenylist;
		[NullAllowed, Export ("categoryDenylist", ArgumentSemantic.Copy)]
		string[] CategoryDenylist { get; set; }
	}

	// @interface MPPConnection : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPConnection
	{
		// @property (readonly, nonatomic) NSUInteger start;
		[Export ("start")]
		nuint Start { get; }

		// @property (readonly, nonatomic) NSUInteger end;
		[Export ("end")]
		nuint End { get; }

		// -(instancetype _Nonnull)initWithStart:(NSUInteger)start end:(NSUInteger)end __attribute__((objc_designated_initializer));
		[Export ("initWithStart:end:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nuint start, nuint end);
	}

	// @interface MPPNormalizedKeypoint : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPNormalizedKeypoint
	{
		// @property (readonly, nonatomic) CGPoint location;
		[Export ("location")]
		CGPoint Location { get; }

		// @property (readonly, nonatomic) NSString * _Nullable label;
		[NullAllowed, Export ("label")]
		string Label { get; }

		// @property (readonly, nonatomic) float score;
		[Export ("score")]
		float Score { get; }

		// -(instancetype _Nonnull)initWithLocation:(CGPoint)location label:(NSString * _Nullable)label score:(float)score __attribute__((objc_designated_initializer));
		[Export ("initWithLocation:label:score:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CGPoint location, [NullAllowed] string label, float score);
	}

	// @interface MPPDetection : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPDetection
	{
		// @property (readonly, nonatomic) NSArray<MPPCategory *> * _Nonnull categories;
		[Export ("categories")]
		MPPCategory[] Categories { get; }

		// @property (readonly, nonatomic) CGRect boundingBox;
		[Export ("boundingBox")]
		CGRect BoundingBox { get; }

		// @property (readonly, nonatomic) NSArray<MPPNormalizedKeypoint *> * _Nullable keypoints;
		[NullAllowed, Export ("keypoints")]
		MPPNormalizedKeypoint[] Keypoints { get; }

		// -(instancetype _Nonnull)initWithCategories:(NSArray<MPPCategory *> * _Nonnull)categories boundingBox:(CGRect)boundingBox keypoints:(NSArray<MPPNormalizedKeypoint *> * _Nullable)keypoints __attribute__((objc_designated_initializer));
		[Export ("initWithCategories:boundingBox:keypoints:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPCategory[] categories, CGRect boundingBox, [NullAllowed] MPPNormalizedKeypoint[] keypoints);
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

	// @interface MPPImage : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPImage
	{
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

	// @interface MPPTaskOptions : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface MPPTaskOptions : INSCopying
	{
		// @property (copy, nonatomic) MPPBaseOptions * _Nonnull baseOptions;
		[Export ("baseOptions", ArgumentSemantic.Copy)]
		MPPBaseOptions BaseOptions { get; set; }
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

	// @interface MPPFaceDetectorResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPFaceDetectorResult
	{
		// @property (readonly, nonatomic) NSArray<MPPDetection *> * _Nonnull detections;
		[Export ("detections")]
		MPPDetection[] Detections { get; }

		// -(instancetype _Nonnull)initWithDetections:(NSArray<MPPDetection *> * _Nonnull)detections timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithDetections:timestampInMilliseconds:")]
		NativeHandle Constructor (MPPDetection[] detections, nint timestampInMilliseconds);
	}

	// @protocol MPPFaceDetectorLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPFaceDetectorLiveStreamDelegate
	{
		// @optional -(void)faceDetector:(MPPFaceDetector * _Nonnull)faceDetector didFinishDetectionWithResult:(MPPFaceDetectorResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("faceDetector(_:didFinishDetection:timestampInMilliseconds:error:)")));
		[Export ("faceDetector:didFinishDetectionWithResult:timestampInMilliseconds:error:")]
		void DidFinishDetectionWithResult (MPPFaceDetector faceDetector, [NullAllowed] MPPFaceDetectorResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPFaceDetectorOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPFaceDetectorOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakFaceDetectorLiveStreamDelegate")]
		[NullAllowed]
		MPPFaceDetectorLiveStreamDelegate FaceDetectorLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPFaceDetectorLiveStreamDelegate> _Nullable faceDetectorLiveStreamDelegate;
		[NullAllowed, Export ("faceDetectorLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakFaceDetectorLiveStreamDelegate { get; set; }

		// @property (nonatomic) float minDetectionConfidence;
		[Export ("minDetectionConfidence")]
		float MinDetectionConfidence { get; set; }

		// @property (nonatomic) float minSuppressionThreshold;
		[Export ("minSuppressionThreshold")]
		float MinSuppressionThreshold { get; set; }
	}

	// @interface MPPFaceDetector : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPFaceDetector
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPFaceDetectorOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPFaceDetectorOptions options, [NullAllowed] out NSError error);

		// -(MPPFaceDetectorResult * _Nullable)detectImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(image:)")));
		[Export ("detectImage:error:")]
		[return: NullAllowed]
		MPPFaceDetectorResult DetectImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPFaceDetectorResult * _Nullable)detectVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(videoFrame:timestampInMilliseconds:)")));
		[Export ("detectVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPFaceDetectorResult DetectVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)detectAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detectAsync(image:timestampInMilliseconds:)")));
		[Export ("detectAsyncImage:timestampInMilliseconds:error:")]
		bool DetectAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);
	}

	// @interface MPPLandmark : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPLandmark : INativeObject
	{
		// @property (readonly, nonatomic) float x;
		[Export ("x")]
		float X { get; }

		// @property (readonly, nonatomic) float y;
		[Export ("y")]
		float Y { get; }

		// @property (readonly, nonatomic) float z;
		[Export ("z")]
		float Z { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable visibility;
		[NullAllowed, Export ("visibility")]
		NSNumber Visibility { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable presence;
		[NullAllowed, Export ("presence")]
		NSNumber Presence { get; }

		// -(instancetype _Nonnull)initWithX:(float)x y:(float)y z:(float)z visibility:(NSNumber * _Nullable)visibility presence:(NSNumber * _Nullable)presence __attribute__((objc_designated_initializer));
		[Export ("initWithX:y:z:visibility:presence:")]
		[DesignatedInitializer]
		NativeHandle Constructor (float x, float y, float z, [NullAllowed] NSNumber visibility, [NullAllowed] NSNumber presence);
	}

	// @interface MPPNormalizedLandmark : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPNormalizedLandmark : INativeObject
	{
		// @property (readonly, nonatomic) float x;
		[Export ("x")]
		float X { get; }

		// @property (readonly, nonatomic) float y;
		[Export ("y")]
		float Y { get; }

		// @property (readonly, nonatomic) float z;
		[Export ("z")]
		float Z { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable visibility;
		[NullAllowed, Export ("visibility")]
		NSNumber Visibility { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable presence;
		[NullAllowed, Export ("presence")]
		NSNumber Presence { get; }

		// -(instancetype _Nonnull)initWithX:(float)x y:(float)y z:(float)z visibility:(NSNumber * _Nullable)visibility presence:(NSNumber * _Nullable)presence __attribute__((objc_designated_initializer));
		[Export ("initWithX:y:z:visibility:presence:")]
		[DesignatedInitializer]
		NativeHandle Constructor (float x, float y, float z, [NullAllowed] NSNumber visibility, [NullAllowed] NSNumber presence);
	}

	// @interface MPPTransformMatrix : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPTransformMatrix
	{
		// @property (readonly, nonatomic) NSUInteger rows;
		[Export ("rows")]
		nuint Rows { get; }

		// @property (readonly, nonatomic) NSUInteger columns;
		[Export ("columns")]
		nuint Columns { get; }

		// @property (readonly, nonatomic) float * _Nonnull data;
		[Export ("data")]
		unsafe float* Data { get; }

		// -(instancetype _Nonnull)initWithData:(const float * _Nonnull)data rows:(NSInteger)rows columns:(NSInteger)columns __attribute__((objc_designated_initializer));
		[Export ("initWithData:rows:columns:")]
		[DesignatedInitializer]
		unsafe NativeHandle Constructor (float* data, nint rows, nint columns);

		// -(float)valueAtRow:(NSUInteger)row column:(NSUInteger)column;
		[Export ("valueAtRow:column:")]
		float ValueAtRow (nuint row, nuint column);
	}

	// @interface MPPFaceLandmarkerResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	[DisableDefaultCtor]
	interface MPPFaceLandmarkerResult
	{
		// @property (readonly, nonatomic) NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull faceLandmarks;
		[Export ("faceLandmarks")]
		NSArray<MPPNormalizedLandmark>[] FaceLandmarks { get; }

		// @property (readonly, nonatomic) NSArray<MPPClassifications *> * _Nonnull faceBlendshapes;
		[Export ("faceBlendshapes")]
		MPPClassifications[] FaceBlendshapes { get; }

		// @property (readonly, nonatomic) NSArray<MPPTransformMatrix *> * _Nonnull facialTransformationMatrixes;
		[Export ("facialTransformationMatrixes")]
		MPPTransformMatrix[] FacialTransformationMatrixes { get; }

		// -(instancetype _Nonnull)initWithFaceLandmarks:(NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull)faceLandmarks faceBlendshapes:(NSArray<MPPClassifications *> * _Nonnull)faceBlendshapes facialTransformationMatrixes:(NSArray<MPPTransformMatrix *> * _Nonnull)facialTransformationMatrixes timestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithFaceLandmarks:faceBlendshapes:facialTransformationMatrixes:timestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSArray<MPPNormalizedLandmark>[] faceLandmarks, MPPClassifications[] faceBlendshapes, MPPTransformMatrix[] facialTransformationMatrixes, nint timestampInMilliseconds);
	}

	// @protocol MPPFaceLandmarkerLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPFaceLandmarkerLiveStreamDelegate
	{
		// @required -(void)faceLandmarker:(MPPFaceLandmarker * _Nonnull)faceLandmarker didFinishDetectionWithResult:(MPPFaceLandmarkerResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("faceLandmarker(_:didFinishDetection:timestampInMilliseconds:error:)")));
		[Abstract]
		[Export ("faceLandmarker:didFinishDetectionWithResult:timestampInMilliseconds:error:")]
		void DidFinishDetectionWithResult (MPPFaceLandmarker faceLandmarker, [NullAllowed] MPPFaceLandmarkerResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPFaceLandmarkerOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPFaceLandmarkerOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakFaceLandmarkerLiveStreamDelegate")]
		[NullAllowed]
		MPPFaceLandmarkerLiveStreamDelegate FaceLandmarkerLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPFaceLandmarkerLiveStreamDelegate> _Nullable faceLandmarkerLiveStreamDelegate;
		[NullAllowed, Export ("faceLandmarkerLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakFaceLandmarkerLiveStreamDelegate { get; set; }

		// @property (nonatomic) NSInteger numFaces;
		[Export ("numFaces")]
		nint NumFaces { get; set; }

		// @property (nonatomic) float minFaceDetectionConfidence;
		[Export ("minFaceDetectionConfidence")]
		float MinFaceDetectionConfidence { get; set; }

		// @property (nonatomic) float minFacePresenceConfidence;
		[Export ("minFacePresenceConfidence")]
		float MinFacePresenceConfidence { get; set; }

		// @property (nonatomic) float minTrackingConfidence;
		[Export ("minTrackingConfidence")]
		float MinTrackingConfidence { get; set; }

		// @property (nonatomic) BOOL outputFaceBlendshapes;
		[Export ("outputFaceBlendshapes")]
		bool OutputFaceBlendshapes { get; set; }

		// @property (nonatomic) BOOL outputFacialTransformationMatrixes;
		[Export ("outputFacialTransformationMatrixes")]
		bool OutputFacialTransformationMatrixes { get; set; }
	}

	// @interface MPPFaceLandmarker : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPFaceLandmarker
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPFaceLandmarkerOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPFaceLandmarkerOptions options, [NullAllowed] out NSError error);

		// -(MPPFaceLandmarkerResult * _Nullable)detectImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(image:)")));
		[Export ("detectImage:error:")]
		[return: NullAllowed]
		MPPFaceLandmarkerResult DetectImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPFaceLandmarkerResult * _Nullable)detectVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(videoFrame:timestampInMilliseconds:)")));
		[Export ("detectVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPFaceLandmarkerResult DetectVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)detectAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detectAsync(image:timestampInMilliseconds:)")));
		[Export ("detectAsyncImage:timestampInMilliseconds:error:")]
		bool DetectAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// +(NSArray<MPPConnection *> * _Nonnull)lipsConnections;
		[Static]
		[Export ("lipsConnections")]
		MPPConnection[] LipsConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)leftEyeConnections;
		[Static]
		[Export ("leftEyeConnections")]
		MPPConnection[] LeftEyeConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)leftEyebrowConnections;
		[Static]
		[Export ("leftEyebrowConnections")]
		MPPConnection[] LeftEyebrowConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)leftIrisConnections;
		[Static]
		[Export ("leftIrisConnections")]
		MPPConnection[] LeftIrisConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)rightEyeConnections;
		[Static]
		[Export ("rightEyeConnections")]
		MPPConnection[] RightEyeConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)rightEyebrowConnections;
		[Static]
		[Export ("rightEyebrowConnections")]
		MPPConnection[] RightEyebrowConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)rightIrisConnections;
		[Static]
		[Export ("rightIrisConnections")]
		MPPConnection[] RightIrisConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)faceOvalConnections;
		[Static]
		[Export ("faceOvalConnections")]
		MPPConnection[] FaceOvalConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)contoursConnections;
		[Static]
		[Export ("contoursConnections")]
		MPPConnection[] ContoursConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)tesselationConnections;
		[Static]
		[Export ("tesselationConnections")]
		MPPConnection[] TesselationConnections { get; }

		// +(NSArray<MPPConnection *> * _Nonnull)faceConnections;
		[Static]
		[Export ("faceConnections")]
		MPPConnection[] FaceConnections { get; }
	}

	// @interface MPPGestureRecognizerResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPGestureRecognizerResult
	{
		// @property (readonly, nonatomic) NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull landmarks;
		[Export ("landmarks")]
		NSArray<MPPNormalizedLandmark>[] Landmarks { get; }

		// @property (readonly, nonatomic) NSArray<NSArray<MPPLandmark *> *> * _Nonnull worldLandmarks;
		[Export ("worldLandmarks")]
		NSArray<MPPLandmark>[] WorldLandmarks { get; }

		// @property (readonly, nonatomic) NSArray<NSArray<MPPCategory *> *> * _Nonnull handedness;
		[Export ("handedness")]
		NSArray<MPPCategory>[] Handedness { get; }

		// @property (readonly, nonatomic) NSArray<NSArray<MPPCategory *> *> * _Nonnull gestures;
		[Export ("gestures")]
		NSArray<MPPCategory>[] Gestures { get; }

		// -(instancetype _Nonnull)initWithGestures:(NSArray<NSArray<MPPCategory *> *> * _Nonnull)gestures handedness:(NSArray<NSArray<MPPCategory *> *> * _Nonnull)handedness landmarks:(NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull)landmarks worldLandmarks:(NSArray<NSArray<MPPLandmark *> *> * _Nonnull)worldLandmarks timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithGestures:handedness:landmarks:worldLandmarks:timestampInMilliseconds:")]
		NativeHandle Constructor (NSArray<MPPCategory>[] gestures, NSArray<MPPCategory>[] handedness, NSArray<MPPNormalizedLandmark>[] landmarks, NSArray<MPPLandmark>[] worldLandmarks, nint timestampInMilliseconds);
	}

	// @protocol MPPGestureRecognizerLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPGestureRecognizerLiveStreamDelegate
	{
		// @optional -(void)gestureRecognizer:(MPPGestureRecognizer * _Nonnull)gestureRecognizer didFinishRecognitionWithResult:(MPPGestureRecognizerResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("gestureRecognizer(_:didFinishGestureRecognition:timestampInMilliseconds:error:)")));
		[Export ("gestureRecognizer:didFinishRecognitionWithResult:timestampInMilliseconds:error:")]
		void DidFinishRecognitionWithResult (MPPGestureRecognizer gestureRecognizer, [NullAllowed] MPPGestureRecognizerResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPGestureRecognizerOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPGestureRecognizerOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakGestureRecognizerLiveStreamDelegate")]
		[NullAllowed]
		MPPGestureRecognizerLiveStreamDelegate GestureRecognizerLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPGestureRecognizerLiveStreamDelegate> _Nullable gestureRecognizerLiveStreamDelegate;
		[NullAllowed, Export ("gestureRecognizerLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakGestureRecognizerLiveStreamDelegate { get; set; }

		// @property (nonatomic) NSInteger numHands;
		[Export ("numHands")]
		nint NumHands { get; set; }

		// @property (nonatomic) float minHandDetectionConfidence;
		[Export ("minHandDetectionConfidence")]
		float MinHandDetectionConfidence { get; set; }

		// @property (nonatomic) float minHandPresenceConfidence;
		[Export ("minHandPresenceConfidence")]
		float MinHandPresenceConfidence { get; set; }

		// @property (nonatomic) float minTrackingConfidence;
		[Export ("minTrackingConfidence")]
		float MinTrackingConfidence { get; set; }

		// @property (copy, nonatomic) MPPClassifierOptions * _Nullable cannedGesturesClassifierOptions;
		[NullAllowed, Export ("cannedGesturesClassifierOptions", ArgumentSemantic.Copy)]
		MPPClassifierOptions CannedGesturesClassifierOptions { get; set; }

		// @property (copy, nonatomic) MPPClassifierOptions * _Nullable customGesturesClassifierOptions;
		[NullAllowed, Export ("customGesturesClassifierOptions", ArgumentSemantic.Copy)]
		MPPClassifierOptions CustomGesturesClassifierOptions { get; set; }
	}

	// @interface MPPGestureRecognizer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPGestureRecognizer
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPGestureRecognizerOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPGestureRecognizerOptions options, [NullAllowed] out NSError error);

		// -(MPPGestureRecognizerResult * _Nullable)recognizeImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("recognize(image:)")));
		[Export ("recognizeImage:error:")]
		[return: NullAllowed]
		MPPGestureRecognizerResult RecognizeImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPGestureRecognizerResult * _Nullable)recognizeVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("recognize(videoFrame:timestampInMilliseconds:)")));
		[Export ("recognizeVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPGestureRecognizerResult RecognizeVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)recognizeAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("recognizeAsync(image:timestampInMilliseconds:)")));
		[Export ("recognizeAsyncImage:timestampInMilliseconds:error:")]
		bool RecognizeAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);
	}

	// @interface MPPHandLandmarkerResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPHandLandmarkerResult
	{
		// @property (readonly, nonatomic) NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull landmarks;
		[Export ("landmarks")]
		NSArray<MPPNormalizedLandmark>[] Landmarks { get; }

		// @property (readonly, nonatomic) NSArray<NSArray<MPPLandmark *> *> * _Nonnull worldLandmarks;
		[Export ("worldLandmarks")]
		NSArray<MPPLandmark>[] WorldLandmarks { get; }

		// @property (readonly, nonatomic) NSArray<NSArray<MPPCategory *> *> * _Nonnull handedness;
		[Export ("handedness")]
		NSArray<MPPCategory>[] Handedness { get; }

		// -(instancetype _Nonnull)initWithLandmarks:(NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull)landmarks worldLandmarks:(NSArray<NSArray<MPPLandmark *> *> * _Nonnull)worldLandmarks handedness:(NSArray<NSArray<MPPCategory *> *> * _Nonnull)handedness timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithLandmarks:worldLandmarks:handedness:timestampInMilliseconds:")]
		NativeHandle Constructor (NSArray<MPPNormalizedLandmark>[] landmarks, NSArray<MPPLandmark>[] worldLandmarks, NSArray<MPPCategory>[] handedness, nint timestampInMilliseconds);
	}

	// @protocol MPPHandLandmarkerLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPHandLandmarkerLiveStreamDelegate
	{
		// @optional -(void)handLandmarker:(MPPHandLandmarker * _Nonnull)handLandmarker didFinishDetectionWithResult:(MPPHandLandmarkerResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("handLandmarker(_:didFinishDetection:timestampInMilliseconds:error:)")));
		[Export ("handLandmarker:didFinishDetectionWithResult:timestampInMilliseconds:error:")]
		void DidFinishDetectionWithResult (MPPHandLandmarker handLandmarker, [NullAllowed] MPPHandLandmarkerResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPHandLandmarkerOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPHandLandmarkerOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakHandLandmarkerLiveStreamDelegate")]
		[NullAllowed]
		MPPHandLandmarkerLiveStreamDelegate HandLandmarkerLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPHandLandmarkerLiveStreamDelegate> _Nullable handLandmarkerLiveStreamDelegate;
		[NullAllowed, Export ("handLandmarkerLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakHandLandmarkerLiveStreamDelegate { get; set; }

		// @property (nonatomic) NSInteger numHands;
		[Export ("numHands")]
		nint NumHands { get; set; }

		// @property (nonatomic) float minHandDetectionConfidence;
		[Export ("minHandDetectionConfidence")]
		float MinHandDetectionConfidence { get; set; }

		// @property (nonatomic) float minHandPresenceConfidence;
		[Export ("minHandPresenceConfidence")]
		float MinHandPresenceConfidence { get; set; }

		// @property (nonatomic) float minTrackingConfidence;
		[Export ("minTrackingConfidence")]
		float MinTrackingConfidence { get; set; }
	}

	// @interface MPPHandLandmarker : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPHandLandmarker
	{
		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull handPalmConnections;
		[Static]
		[Export ("handPalmConnections")]
		MPPConnection[] HandPalmConnections { get; }

		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull handThumbConnections;
		[Static]
		[Export ("handThumbConnections")]
		MPPConnection[] HandThumbConnections { get; }

		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull handIndexFingerConnections;
		[Static]
		[Export ("handIndexFingerConnections")]
		MPPConnection[] HandIndexFingerConnections { get; }

		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull handMiddleFingerConnections;
		[Static]
		[Export ("handMiddleFingerConnections")]
		MPPConnection[] HandMiddleFingerConnections { get; }

		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull handRingFingerConnections;
		[Static]
		[Export ("handRingFingerConnections")]
		MPPConnection[] HandRingFingerConnections { get; }

		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull handPinkyConnections;
		[Static]
		[Export ("handPinkyConnections")]
		MPPConnection[] HandPinkyConnections { get; }

		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull handConnections;
		[Static]
		[Export ("handConnections")]
		MPPConnection[] HandConnections { get; }

		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPHandLandmarkerOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPHandLandmarkerOptions options, [NullAllowed] out NSError error);

		// -(MPPHandLandmarkerResult * _Nullable)detectImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(image:)")));
		[Export ("detectImage:error:")]
		[return: NullAllowed]
		MPPHandLandmarkerResult DetectImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPHandLandmarkerResult * _Nullable)detectVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(videoFrame:timestampInMilliseconds:)")));
		[Export ("detectVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPHandLandmarkerResult DetectVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)detectAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detectAsync(image:timestampInMilliseconds:)")));
		[Export ("detectAsyncImage:timestampInMilliseconds:error:")]
		bool DetectAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);
	}

	// @interface MPPImageClassifierResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPImageClassifierResult
	{
		// @property (readonly, nonatomic) MPPClassificationResult * _Nonnull classificationResult;
		[Export ("classificationResult")]
		MPPClassificationResult ClassificationResult { get; }

		// -(instancetype _Nonnull)initWithClassificationResult:(MPPClassificationResult * _Nonnull)classificationResult timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithClassificationResult:timestampInMilliseconds:")]
		NativeHandle Constructor (MPPClassificationResult classificationResult, nint timestampInMilliseconds);
	}

	// @protocol MPPImageClassifierLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPImageClassifierLiveStreamDelegate
	{
		// @optional -(void)imageClassifier:(MPPImageClassifier * _Nonnull)imageClassifier didFinishClassificationWithResult:(MPPImageClassifierResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("imageClassifier(_:didFinishClassification:timestampInMilliseconds:error:)")));
		[Export ("imageClassifier:didFinishClassificationWithResult:timestampInMilliseconds:error:")]
		void DidFinishClassificationWithResult (MPPImageClassifier imageClassifier, [NullAllowed] MPPImageClassifierResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPImageClassifierOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPImageClassifierOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakImageClassifierLiveStreamDelegate")]
		[NullAllowed]
		MPPImageClassifierLiveStreamDelegate ImageClassifierLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPImageClassifierLiveStreamDelegate> _Nullable imageClassifierLiveStreamDelegate;
		[NullAllowed, Export ("imageClassifierLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakImageClassifierLiveStreamDelegate { get; set; }

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

	// @interface MPPImageClassifier : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPImageClassifier
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPImageClassifierOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPImageClassifierOptions options, [NullAllowed] out NSError error);

		// -(MPPImageClassifierResult * _Nullable)classifyImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classify(image:)")));
		[Export ("classifyImage:error:")]
		[return: NullAllowed]
		MPPImageClassifierResult ClassifyImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPImageClassifierResult * _Nullable)classifyImage:(MPPImage * _Nonnull)image regionOfInterest:(CGRect)roi error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classify(image:regionOfInterest:)")));
		[Export ("classifyImage:regionOfInterest:error:")]
		[return: NullAllowed]
		MPPImageClassifierResult ClassifyImage (MPPImage image, CGRect roi, [NullAllowed] out NSError error);

		// -(MPPImageClassifierResult * _Nullable)classifyVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classify(videoFrame:timestampInMilliseconds:)")));
		[Export ("classifyVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPImageClassifierResult ClassifyVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(MPPImageClassifierResult * _Nullable)classifyVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds regionOfInterest:(CGRect)roi error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classify(videoFrame:timestampInMilliseconds:regionOfInterest:)")));
		[Export ("classifyVideoFrame:timestampInMilliseconds:regionOfInterest:error:")]
		[return: NullAllowed]
		MPPImageClassifierResult ClassifyVideoFrame (MPPImage image, nint timestampInMilliseconds, CGRect roi, [NullAllowed] out NSError error);

		// -(BOOL)classifyAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classifyAsync(image:timestampInMilliseconds:)")));
		[Export ("classifyAsyncImage:timestampInMilliseconds:error:")]
		bool ClassifyAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)classifyAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds regionOfInterest:(CGRect)roi error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("classifyAsync(image:timestampInMilliseconds:regionOfInterest:)")));
		[Export ("classifyAsyncImage:timestampInMilliseconds:regionOfInterest:error:")]
		bool ClassifyAsyncImage (MPPImage image, nint timestampInMilliseconds, CGRect roi, [NullAllowed] out NSError error);
	}

	// @interface MPPImageEmbedderResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	[DisableDefaultCtor]
	interface MPPImageEmbedderResult
	{
		// @property (readonly, nonatomic) MPPEmbeddingResult * _Nonnull embeddingResult;
		[Export ("embeddingResult")]
		MPPEmbeddingResult EmbeddingResult { get; }

		// -(instancetype _Nonnull)initWithEmbeddingResult:(MPPEmbeddingResult * _Nullable)embeddingResult timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithEmbeddingResult:timestampInMilliseconds:")]
		NativeHandle Constructor ([NullAllowed] MPPEmbeddingResult embeddingResult, nint timestampInMilliseconds);
	}

	// @protocol MPPImageEmbedderLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPImageEmbedderLiveStreamDelegate
	{
		// @optional -(void)imageEmbedder:(MPPImageEmbedder * _Nonnull)imageEmbedder didFinishEmbeddingWithResult:(MPPImageEmbedderResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("imageEmbedder(_:didFinishEmbedding:timestampInMilliseconds:error:)")));
		[Export ("imageEmbedder:didFinishEmbeddingWithResult:timestampInMilliseconds:error:")]
		void DidFinishEmbeddingWithResult (MPPImageEmbedder imageEmbedder, [NullAllowed] MPPImageEmbedderResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPImageEmbedderOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPImageEmbedderOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakImageEmbedderLiveStreamDelegate")]
		[NullAllowed]
		MPPImageEmbedderLiveStreamDelegate ImageEmbedderLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPImageEmbedderLiveStreamDelegate> _Nullable imageEmbedderLiveStreamDelegate;
		[NullAllowed, Export ("imageEmbedderLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakImageEmbedderLiveStreamDelegate { get; set; }

		// @property (nonatomic) BOOL l2Normalize;
		[Export ("l2Normalize")]
		bool L2Normalize { get; set; }

		// @property (nonatomic) BOOL quantize;
		[Export ("quantize")]
		bool Quantize { get; set; }
	}

	// @interface MPPImageEmbedder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPImageEmbedder
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPImageEmbedderOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPImageEmbedderOptions options, [NullAllowed] out NSError error);

		// -(MPPImageEmbedderResult * _Nullable)embedImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(image:)")));
		[Export ("embedImage:error:")]
		[return: NullAllowed]
		MPPImageEmbedderResult EmbedImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPImageEmbedderResult * _Nullable)embedImage:(MPPImage * _Nonnull)image regionOfInterest:(CGRect)roi error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(image:regionOfInterest:)")));
		[Export ("embedImage:regionOfInterest:error:")]
		[return: NullAllowed]
		MPPImageEmbedderResult EmbedImage (MPPImage image, CGRect roi, [NullAllowed] out NSError error);

		// -(MPPImageEmbedderResult * _Nullable)embedVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(videoFrame:timestampInMilliseconds:)")));
		[Export ("embedVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPImageEmbedderResult EmbedVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(MPPImageEmbedderResult * _Nullable)embedVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds regionOfInterest:(CGRect)roi error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embed(videoFrame:timestampInMilliseconds:regionOfInterest:)")));
		[Export ("embedVideoFrame:timestampInMilliseconds:regionOfInterest:error:")]
		[return: NullAllowed]
		MPPImageEmbedderResult EmbedVideoFrame (MPPImage image, nint timestampInMilliseconds, CGRect roi, [NullAllowed] out NSError error);

		// -(BOOL)embedAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embedAsync(image:timestampInMilliseconds:)")));
		[Export ("embedAsyncImage:timestampInMilliseconds:error:")]
		bool EmbedAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)embedAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds regionOfInterest:(CGRect)roi error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("embedAsync(image:timestampInMilliseconds:regionOfInterest:)")));
		[Export ("embedAsyncImage:timestampInMilliseconds:regionOfInterest:error:")]
		bool EmbedAsyncImage (MPPImage image, nint timestampInMilliseconds, CGRect roi, [NullAllowed] out NSError error);

		// +(NSNumber * _Nullable)cosineSimilarityBetweenEmbedding1:(MPPEmbedding * _Nonnull)embedding1 andEmbedding2:(MPPEmbedding * _Nonnull)embedding2 error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("cosineSimilarity(embedding1:embedding2:)")));
		[Static]
		[Export ("cosineSimilarityBetweenEmbedding1:andEmbedding2:error:")]
		[return: NullAllowed]
		NSNumber CosineSimilarityBetweenEmbedding1 (MPPEmbedding embedding1, MPPEmbedding embedding2, [NullAllowed] out NSError error);
	}

	// @interface MPPMask : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPMask : INSCopying
	{
		// @property (readonly, nonatomic) NSInteger width;
		[Export ("width")]
		nint Width { get; }

		// @property (readonly, nonatomic) NSInteger height;
		[Export ("height")]
		nint Height { get; }

		// @property (readonly, nonatomic) MPPMaskDataType dataType;
		[Export ("dataType")]
		MPPMaskDataType DataType { get; }

		// @property (readonly, assign, nonatomic) const UInt8 * _Nonnull uint8Data;
		[Export ("uint8Data", ArgumentSemantic.Assign)]
		unsafe byte* Uint8Data { get; }

		// @property (readonly, assign, nonatomic) const float * _Nonnull float32Data;
		[Export ("float32Data", ArgumentSemantic.Assign)]
		unsafe float* Float32Data { get; }

		// -(instancetype _Nullable)initWithUInt8Data:(const UInt8 * _Nonnull)uint8Data width:(NSInteger)width height:(NSInteger)height shouldCopy:(BOOL)shouldCopy __attribute__((objc_designated_initializer));
		[Export ("initWithUInt8Data:width:height:shouldCopy:")]
		[DesignatedInitializer]
		unsafe NativeHandle Constructor (byte* uint8Data, nint width, nint height, bool shouldCopy);

		// -(instancetype _Nullable)initWithFloat32Data:(const float * _Nonnull)float32Data width:(NSInteger)width height:(NSInteger)height shouldCopy:(BOOL)shouldCopy __attribute__((objc_designated_initializer));
		[Export ("initWithFloat32Data:width:height:shouldCopy:")]
		[DesignatedInitializer]
		unsafe NativeHandle Constructor (float* float32Data, nint width, nint height, bool shouldCopy);
	}

	// @interface MPPImageSegmenterResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPImageSegmenterResult
	{
		// @property (readonly, nonatomic) NSArray<MPPMask *> * _Nullable confidenceMasks;
		[NullAllowed, Export ("confidenceMasks")]
		MPPMask[] ConfidenceMasks { get; }

		// @property (readonly, nonatomic) MPPMask * _Nullable categoryMask;
		[NullAllowed, Export ("categoryMask")]
		MPPMask CategoryMask { get; }

		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable qualityScores;
		[NullAllowed, Export ("qualityScores")]
		NSNumber[] QualityScores { get; }

		// -(instancetype _Nonnull)initWithConfidenceMasks:(NSArray<MPPMask *> * _Nullable)confidenceMasks categoryMask:(MPPMask * _Nullable)categoryMask qualityScores:(NSArray<NSNumber *> * _Nullable)qualityScores timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithConfidenceMasks:categoryMask:qualityScores:timestampInMilliseconds:")]
		NativeHandle Constructor ([NullAllowed] MPPMask[] confidenceMasks, [NullAllowed] MPPMask categoryMask, [NullAllowed] NSNumber[] qualityScores, nint timestampInMilliseconds);
	}

	// @protocol MPPImageSegmenterLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPImageSegmenterLiveStreamDelegate
	{
		// @optional -(void)imageSegmenter:(MPPImageSegmenter * _Nonnull)imageSegmenter didFinishSegmentationWithResult:(MPPImageSegmenterResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("imageSegmenter(_:didFinishSegmentation:timestampInMilliseconds:error:)")));
		[Export ("imageSegmenter:didFinishSegmentationWithResult:timestampInMilliseconds:error:")]
		void DidFinishSegmentationWithResult (MPPImageSegmenter imageSegmenter, [NullAllowed] MPPImageSegmenterResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPImageSegmenterOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPImageSegmenterOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakImageSegmenterLiveStreamDelegate")]
		[NullAllowed]
		MPPImageSegmenterLiveStreamDelegate ImageSegmenterLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPImageSegmenterLiveStreamDelegate> _Nullable imageSegmenterLiveStreamDelegate;
		[NullAllowed, Export ("imageSegmenterLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakImageSegmenterLiveStreamDelegate { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull displayNamesLocale;
		[Export ("displayNamesLocale")]
		string DisplayNamesLocale { get; set; }

		// @property (nonatomic) BOOL shouldOutputConfidenceMasks;
		[Export ("shouldOutputConfidenceMasks")]
		bool ShouldOutputConfidenceMasks { get; set; }

		// @property (nonatomic) BOOL shouldOutputCategoryMask;
		[Export ("shouldOutputCategoryMask")]
		bool ShouldOutputCategoryMask { get; set; }
	}

	// @interface MPPImageSegmenter : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPImageSegmenter
	{
		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull labels;
		[Export ("labels")]
		string[] Labels { get; }

		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPImageSegmenterOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPImageSegmenterOptions options, [NullAllowed] out NSError error);

		// -(MPPImageSegmenterResult * _Nullable)segmentImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("segment(image:)")));
		[Export ("segmentImage:error:")]
		[return: NullAllowed]
		MPPImageSegmenterResult SegmentImage (MPPImage image, [NullAllowed] out NSError error);

		// -(void)segmentImage:(MPPImage * _Nonnull)image withCompletionHandler:(void (^ _Nonnull)(MPPImageSegmenterResult * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("segment(image:completion:)")));
		[Export ("segmentImage:withCompletionHandler:")]
		void SegmentImage (MPPImage image, Action<MPPImageSegmenterResult, NSError> completionHandler);

		// -(MPPImageSegmenterResult * _Nullable)segmentVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("segment(videoFrame:timestampInMilliseconds:)")));
		[Export ("segmentVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPImageSegmenterResult SegmentVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(void)segmentVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds withCompletionHandler:(void (^ _Nonnull)(MPPImageSegmenterResult * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("segment(videoFrame:timestampInMilliseconds:completion:)")));
		[Export ("segmentVideoFrame:timestampInMilliseconds:withCompletionHandler:")]
		void SegmentVideoFrame (MPPImage image, nint timestampInMilliseconds, Action<MPPImageSegmenterResult, NSError> completionHandler);

		// -(BOOL)segmentAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("segmentAsync(image:timestampInMilliseconds:)")));
		[Export ("segmentAsyncImage:timestampInMilliseconds:error:")]
		bool SegmentAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);
	}

	// @interface MPPRegionOfInterest : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPRegionOfInterest
	{
		// @property (readonly, nonatomic) MPPNormalizedKeypoint * _Nullable keypoint;
		[NullAllowed, Export ("keypoint")]
		MPPNormalizedKeypoint Keypoint { get; }

		// @property (readonly, nonatomic) NSArray<MPPNormalizedKeypoint *> * _Nullable scribbles;
		[NullAllowed, Export ("scribbles")]
		MPPNormalizedKeypoint[] Scribbles { get; }

		// -(instancetype _Nonnull)initWithNormalizedKeyPoint:(MPPNormalizedKeypoint * _Nonnull)normalizedKeypoint __attribute__((objc_designated_initializer));
		[Export ("initWithNormalizedKeyPoint:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPNormalizedKeypoint normalizedKeypoint);

		// -(instancetype _Nonnull)initWithScribbles:(NSArray<MPPNormalizedKeypoint *> * _Nonnull)scribbles __attribute__((objc_designated_initializer));
		[Export ("initWithScribbles:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPNormalizedKeypoint[] scribbles);
	}

	// @interface MPPInteractiveSegmenterOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPInteractiveSegmenterOptions : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nonnull displayNamesLocale;
		[Export ("displayNamesLocale")]
		string DisplayNamesLocale { get; set; }

		// @property (nonatomic) BOOL shouldOutputConfidenceMasks;
		[Export ("shouldOutputConfidenceMasks")]
		bool ShouldOutputConfidenceMasks { get; set; }

		// @property (nonatomic) BOOL shouldOutputCategoryMask;
		[Export ("shouldOutputCategoryMask")]
		bool ShouldOutputCategoryMask { get; set; }
	}

	// @interface MPPInteractiveSegmenterResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPInteractiveSegmenterResult
	{
		// @property (readonly, nonatomic) NSArray<MPPMask *> * _Nullable confidenceMasks;
		[NullAllowed, Export ("confidenceMasks")]
		MPPMask[] ConfidenceMasks { get; }

		// @property (readonly, nonatomic) MPPMask * _Nullable categoryMask;
		[NullAllowed, Export ("categoryMask")]
		MPPMask CategoryMask { get; }

		// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable qualityScores;
		[NullAllowed, Export ("qualityScores")]
		NSNumber[] QualityScores { get; }

		// -(instancetype _Nonnull)initWithConfidenceMasks:(NSArray<MPPMask *> * _Nullable)confidenceMasks categoryMask:(MPPMask * _Nullable)categoryMask qualityScores:(NSArray<NSNumber *> * _Nullable)qualityScores timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithConfidenceMasks:categoryMask:qualityScores:timestampInMilliseconds:")]
		NativeHandle Constructor ([NullAllowed] MPPMask[] confidenceMasks, [NullAllowed] MPPMask categoryMask, [NullAllowed] NSNumber[] qualityScores, nint timestampInMilliseconds);
	}

	// @interface MPPInteractiveSegmenter : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPInteractiveSegmenter
	{
		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull labels;
		[Export ("labels")]
		string[] Labels { get; }

		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPInteractiveSegmenterOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPInteractiveSegmenterOptions options, [NullAllowed] out NSError error);

		// -(MPPInteractiveSegmenterResult * _Nullable)segmentImage:(MPPImage * _Nonnull)image regionOfInterest:(MPPRegionOfInterest * _Nonnull)regionOfInterest error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("segment(image:regionOfInterest:)")));
		[Export ("segmentImage:regionOfInterest:error:")]
		[return: NullAllowed]
		MPPInteractiveSegmenterResult SegmentImage (MPPImage image, MPPRegionOfInterest regionOfInterest, [NullAllowed] out NSError error);

		// -(void)segmentImage:(MPPImage * _Nonnull)image regionOfInterest:(MPPRegionOfInterest * _Nonnull)regionOfInterest withCompletionHandler:(void (^ _Nonnull)(MPPInteractiveSegmenterResult * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("segment(image:regionOfInterest:completion:)")));
		[Export ("segmentImage:regionOfInterest:withCompletionHandler:")]
		void SegmentImage (MPPImage image, MPPRegionOfInterest regionOfInterest, Action<MPPInteractiveSegmenterResult, NSError> completionHandler);
	}

	// @interface MPPObjectDetectorResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	interface MPPObjectDetectorResult
	{
		// @property (readonly, nonatomic) NSArray<MPPDetection *> * _Nonnull detections;
		[Export ("detections")]
		MPPDetection[] Detections { get; }

		// -(instancetype _Nonnull)initWithDetections:(NSArray<MPPDetection *> * _Nonnull)detections timestampInMilliseconds:(NSInteger)timestampInMilliseconds;
		[Export ("initWithDetections:timestampInMilliseconds:")]
		NativeHandle Constructor (MPPDetection[] detections, nint timestampInMilliseconds);
	}

	// @protocol MPPObjectDetectorLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPObjectDetectorLiveStreamDelegate
	{
		// @optional -(void)objectDetector:(MPPObjectDetector * _Nonnull)objectDetector didFinishDetectionWithResult:(MPPObjectDetectorResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("objectDetector(_:didFinishDetection:timestampInMilliseconds:error:)")));
		[Export ("objectDetector:didFinishDetectionWithResult:timestampInMilliseconds:error:")]
		void DidFinishDetectionWithResult (MPPObjectDetector objectDetector, [NullAllowed] MPPObjectDetectorResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPObjectDetectorOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPObjectDetectorOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakObjectDetectorLiveStreamDelegate")]
		[NullAllowed]
		MPPObjectDetectorLiveStreamDelegate ObjectDetectorLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPObjectDetectorLiveStreamDelegate> _Nullable objectDetectorLiveStreamDelegate;
		[NullAllowed, Export ("objectDetectorLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakObjectDetectorLiveStreamDelegate { get; set; }

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

	// @interface MPPObjectDetector : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPObjectDetector
	{
		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPObjectDetectorOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPObjectDetectorOptions options, [NullAllowed] out NSError error);

		// -(MPPObjectDetectorResult * _Nullable)detectImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(image:)")));
		[Export ("detectImage:error:")]
		[return: NullAllowed]
		MPPObjectDetectorResult DetectImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPObjectDetectorResult * _Nullable)detectVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(videoFrame:timestampInMilliseconds:)")));
		[Export ("detectVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPObjectDetectorResult DetectVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)detectAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detectAsync(image:timestampInMilliseconds:)")));
		[Export ("detectAsyncImage:timestampInMilliseconds:error:")]
		bool DetectAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);
	}

	// @interface MPPPoseLandmarkerResult : MPPTaskResult
	[BaseType (typeof(MPPTaskResult))]
	[DisableDefaultCtor]
	interface MPPPoseLandmarkerResult
	{
		// @property (readonly, nonatomic) NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull landmarks;
		[Export ("landmarks")]
		NSArray<MPPNormalizedLandmark>[] Landmarks { get; }

		// @property (readonly, nonatomic) NSArray<NSArray<MPPLandmark *> *> * _Nonnull worldLandmarks;
		[Export ("worldLandmarks")]
		NSArray<MPPLandmark>[] WorldLandmarks { get; }

		// @property (readonly, nonatomic) NSArray<MPPMask *> * _Nonnull segmentationMasks;
		[Export ("segmentationMasks")]
		MPPMask[] SegmentationMasks { get; }

		// -(instancetype _Nonnull)initWithLandmarks:(NSArray<NSArray<MPPNormalizedLandmark *> *> * _Nonnull)landmarks worldLandmarks:(NSArray<NSArray<MPPLandmark *> *> * _Nonnull)worldLandmarks segmentationMasks:(NSArray<MPPMask *> * _Nullable)segmentationMasks timestampInMilliseconds:(NSInteger)timestampInMilliseconds __attribute__((objc_designated_initializer));
		[Export ("initWithLandmarks:worldLandmarks:segmentationMasks:timestampInMilliseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSArray<MPPNormalizedLandmark>[] landmarks, NSArray<MPPLandmark>[] worldLandmarks, [NullAllowed] MPPMask[] segmentationMasks, nint timestampInMilliseconds);
	}

	// @protocol MPPPoseLandmarkerLiveStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MPPPoseLandmarkerLiveStreamDelegate
	{
		// @required -(void)poseLandmarker:(MPPPoseLandmarker * _Nonnull)poseLandmarker didFinishDetectionWithResult:(MPPPoseLandmarkerResult * _Nullable)result timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable)error __attribute__((swift_name("poseLandmarker(_:didFinishDetection:timestampInMilliseconds:error:)")));
		[Abstract]
		[Export ("poseLandmarker:didFinishDetectionWithResult:timestampInMilliseconds:error:")]
		void DidFinishDetectionWithResult (MPPPoseLandmarker poseLandmarker, [NullAllowed] MPPPoseLandmarkerResult result, nint timestampInMilliseconds, [NullAllowed] NSError error);
	}

	// @interface MPPPoseLandmarkerOptions : MPPTaskOptions <NSCopying>
	[BaseType (typeof(MPPTaskOptions))]
	interface MPPPoseLandmarkerOptions : INSCopying
	{
		// @property (nonatomic) MPPRunningMode runningMode;
		[Export ("runningMode", ArgumentSemantic.Assign)]
		MPPRunningMode RunningMode { get; set; }

		[Wrap ("WeakPoseLandmarkerLiveStreamDelegate")]
		[NullAllowed]
		MPPPoseLandmarkerLiveStreamDelegate PoseLandmarkerLiveStreamDelegate { get; set; }

		// @property (nonatomic, weak) id<MPPPoseLandmarkerLiveStreamDelegate> _Nullable poseLandmarkerLiveStreamDelegate;
		[NullAllowed, Export ("poseLandmarkerLiveStreamDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPoseLandmarkerLiveStreamDelegate { get; set; }

		// @property (nonatomic) NSInteger numPoses;
		[Export ("numPoses")]
		nint NumPoses { get; set; }

		// @property (nonatomic) float minPoseDetectionConfidence;
		[Export ("minPoseDetectionConfidence")]
		float MinPoseDetectionConfidence { get; set; }

		// @property (nonatomic) float minPosePresenceConfidence;
		[Export ("minPosePresenceConfidence")]
		float MinPosePresenceConfidence { get; set; }

		// @property (nonatomic) float minTrackingConfidence;
		[Export ("minTrackingConfidence")]
		float MinTrackingConfidence { get; set; }

		// @property (nonatomic) BOOL shouldOutputSegmentationMasks;
		[Export ("shouldOutputSegmentationMasks")]
		bool ShouldOutputSegmentationMasks { get; set; }
	}

	// @interface MPPPoseLandmarker : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MPPPoseLandmarker
	{
		// @property (readonly, nonatomic, class) NSArray<MPPConnection *> * _Nonnull poseLandmarks;
		[Static]
		[Export ("poseLandmarks")]
		MPPConnection[] PoseLandmarks { get; }

		// -(instancetype _Nullable)initWithModelPath:(NSString * _Nonnull)modelPath error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithModelPath:error:")]
		NativeHandle Constructor (string modelPath, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(MPPPoseLandmarkerOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		NativeHandle Constructor (MPPPoseLandmarkerOptions options, [NullAllowed] out NSError error);

		// -(MPPPoseLandmarkerResult * _Nullable)detectImage:(MPPImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(image:)")));
		[Export ("detectImage:error:")]
		[return: NullAllowed]
		MPPPoseLandmarkerResult DetectImage (MPPImage image, [NullAllowed] out NSError error);

		// -(MPPPoseLandmarkerResult * _Nullable)detectVideoFrame:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detect(videoFrame:timestampInMilliseconds:)")));
		[Export ("detectVideoFrame:timestampInMilliseconds:error:")]
		[return: NullAllowed]
		MPPPoseLandmarkerResult DetectVideoFrame (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);

		// -(BOOL)detectAsyncImage:(MPPImage * _Nonnull)image timestampInMilliseconds:(NSInteger)timestampInMilliseconds error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("detectAsync(image:timestampInMilliseconds:)")));
		[Export ("detectAsyncImage:timestampInMilliseconds:error:")]
		bool DetectAsyncImage (MPPImage image, nint timestampInMilliseconds, [NullAllowed] out NSError error);
	}
}
