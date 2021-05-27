//
//  Cross Platform Replay Kit
//
//  Created by Ayyappa Reddy on 03/06/19.
//  Copyright (c) 2019 Voxel Busters Interactive LLP. All rights reserved.
//

#import <Foundation/Foundation.h>

UIKIT_EXTERN const char* replaykit_getPreviewFilePath ();
UIKIT_EXTERN void replaykit_savePreview (const char* filename);
UIKIT_EXTERN void replaykit_sharePreview (const char* text, const char* subject);
UIKIT_EXTERN void replaykit_startRecording (BOOL microphoneEnabled);
UIKIT_EXTERN void replaykit_stopRecording ();
UIKIT_EXTERN BOOL replaykit_isAPIAvailable();
UIKIT_EXTERN BOOL replaykit_isPreviewAvailable();
UIKIT_EXTERN BOOL replaykit_isRecording();
UIKIT_EXTERN BOOL replaykit_previewRecording();
UIKIT_EXTERN BOOL replaykit_discardRecording();



