using UnityEngine;

#if UNITY_ANDROID
namespace VoxelBusters.ReplayKit.Internal
{
	public partial class ReplayKitAndroid : MonoBehaviour, INativeService 
	{
#region Platform Native Info

		private class Native
		{
			// Handler class name
			internal class Class
			{
				internal const string NAME			= "com.voxelbusters.replaykit.ReplayKitHandler";
			}

			// For holding method names
			internal class Methods
			{
				internal const string IS_RECORDING_API_AVAILABLE	= "isRecordingApiAvailable";
				internal const string IS_RECORDING		            = "isRecording";
				internal const string IS_PREVIEW_AVAILABLE			= "isPreviewAvailable";
                internal const string IS_CAMERA_ENABLED             = "isCameraEnabled";
                internal const string INITIALISE                    = "initialise";
                internal const string SET_APP_AUDIO_PRIORITY        = "setIsAppAudioPriorityOverMicrophone";
                internal const string START_RECORDING               = "startRecording";
                internal const string STOP_RECORDING                = "stopRecording";
                internal const string PREVIEW_RECORDING             = "previewRecording";
                internal const string DISCARD_RECORDING             = "discardRecording";
                internal const string PREVIEW_FILE_PATH             = "getRecordingPath";
				internal const string SAVE_PREVIEW             		= "savePreviewRecordingToGallery";
				internal const string SHARE_PREVIEW             	= "sharePreviewRecording";

				internal const string SHOW_MESSAGE					= "showMessage";
            }
		}

#endregion

#region  Native Access Variables

		private AndroidJavaObject  	Plugin
		{
			get;
			set;
		}

#endregion
	}
}
#endif