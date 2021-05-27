//
//  Cross Platform Replay Kit
//
//  Created by Ayyappa Reddy on 03/06/19.
//  Copyright (c) 2019 Voxel Busters Interactive LLP. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <AVFoundation/AVFoundation.h>
#import <AVKit/AVKit.h>

@interface CrossPlatformReplayKitHandler : NSObject<AVCaptureAudioDataOutputSampleBufferDelegate>

+ (id)sharedInstance;
- (BOOL) isAPIAvailable;
- (NSString*) getPreviewFilePath;
- (BOOL) isPreviewAvailable;
- (BOOL) isCurrentlyRecording;
- (void) startRecording :(BOOL) microphoneEnabled;
- (void) stopRecording;
- (BOOL) previewRecording;
- (BOOL) discardRecording;

-(void) savePreview:(NSString*) path;
-(void) sharePreview;

@property BOOL isRecording;
@property BOOL microphoneEnabled;
@property BOOL initialisedWriter;

@property BOOL videoDataStarted;
@property BOOL audioDataStarted;
@property BOOL micDataStarted;

@property (atomic, retain) AVAssetWriter         *writer;
@property (atomic, retain) AVAssetWriterInput    *video;
@property (atomic, retain) AVAssetWriterInput    *audio;
@property (atomic, retain) AVAssetWriterInput    *mic;

@property NSString* recordingPath;

@property (atomic, retain) AVCaptureSession *session;
@property (atomic, retain) AVCaptureAudioDataOutput *micCaptureOutput;
@property (atomic, retain) AVCaptureDeviceInput *micCaptureInput;

@property(nonatomic, retain)    AVPlayerViewController        *moviePlayerVC;
@property (nonatomic)           dispatch_queue_t              sessionQueue;


@end
