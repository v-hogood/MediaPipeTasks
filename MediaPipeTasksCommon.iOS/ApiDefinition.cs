using System;
using Foundation;
using ObjCRuntime;

namespace MediaPipeTasksCommon {
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
}
