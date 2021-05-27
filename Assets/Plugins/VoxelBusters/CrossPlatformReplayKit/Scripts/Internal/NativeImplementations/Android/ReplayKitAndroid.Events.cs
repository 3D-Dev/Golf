using UnityEngine;
using System.Collections;
using VoxelBusters.ReplayKit.Common.Utility;

#if UNITY_ANDROID
namespace VoxelBusters.ReplayKit.Internal
{
	public partial class ReplayKitAndroid : MonoBehaviour, INativeService
	{

        public void OnReplayKitInitialiseSuccess(string message)
        {
            m_listener.OnInitialiseSuccess();
        }

        public void OnReplayKitInitialiseFailed(string message)
        {
            m_listener.OnInitialiseFailed(message);
        }

        public void OnReplayKitRecordingStarted(string message)
        {
            if (m_allowControllingAudio)
                ResumeAudio();

            m_listener.OnRecordingStarted();
        }

        public void OnReplayKitRecordingStopped(string message)
        {
            if (m_allowControllingAudio)
                ResumeAudio();

            m_listener.OnRecordingStopped();
        }

        public void OnReplayKitRecordingAvailable(string message)
        {
            // This is required as in future we may have some video processing (Audio+Video Mux)
            m_listener.OnRecordingAvailable();
        }

        public void OnReplayKitRecordingFailed(string message)
        {
            if (m_allowControllingAudio)
                ResumeAudio();

            m_listener.OnRecordingFailed(message);
        }

        public void OnReplayKitPreviewOpened(string message)
        {
            m_listener.OnPreviewOpened();
        }

        public void OnReplayKitPreviewClosed(string message)
        {
            m_listener.OnPreviewClosed();
        }

        public void OnReplayKitPreviewShared(string message)
        {
            m_listener.OnPreviewShared();
        }

        public void OnReplayKitPreviewSaveSuccess(string message)
        {
            m_listener.OnPreviewSaved(null);
        }

        public void OnReplayKitPreviewSaveFailed(string message)
        {
            //PREVIEW_UNAVAILABLE
            //PERMISSION_UNAVAILABLE
            m_listener.OnPreviewSaved(message);
        }
    }
}
#endif