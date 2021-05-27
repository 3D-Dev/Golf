using UnityEngine;
using System.Collections;

#if UNITY_IOS
using System.Runtime.InteropServices;
using System.IO;

namespace VoxelBusters.ReplayKit.Internal
{
    public partial class ReplayKitIOS : MonoBehaviour, INativeService
    {
        private INativeCallbackListener m_listener;

#region Native Methods

        [DllImport("__Internal")]
        private static extern void replaykit_startRecording(bool isMicrophoneEnabled);

        [DllImport("__Internal")]
        private static extern void replaykit_stopRecording();

        [DllImport("__Internal")]
        private static extern string replaykit_getPreviewFilePath();

        [DllImport("__Internal")]
        private static extern bool replaykit_isAPIAvailable();

        [DllImport("__Internal")]
        private static extern bool replaykit_isRecording();

        [DllImport("__Internal")]
        private static extern bool replaykit_isPreviewAvailable();

        [DllImport("__Internal")]
        private static extern bool replaykit_previewRecording();

        [DllImport("__Internal")]
        private static extern void replaykit_sharePreview (string text, string subject);

        [DllImport("__Internal")]
        private static extern void replaykit_savePreview (string filename);

        [DllImport("__Internal")]
        private static extern bool replaykit_discardRecording ();

#endregion

#region INativeService implementation

        public void Initialise(INativeCallbackListener listener)
        {
            m_listener = listener;
            IsRecordingAPIAvailable();
            m_listener.OnInitialiseSuccess();
        }

        public bool IsRecordingAPIAvailable()
        {
            return replaykit_isAPIAvailable();
        }

        public bool IsRecording()
        {
            return replaykit_isRecording();
        }

        public bool IsPreviewAvailable()
        {
            return replaykit_isPreviewAvailable();
        }

        public bool IsCameraEnabled()
        {
            return UnityEngine.Apple.ReplayKit.ReplayKit.cameraEnabled;
        }

        public void StartRecording(bool enableMicrophone)
        {
            replaykit_startRecording(enableMicrophone);
        }

        public void StopRecording()
        {
            replaykit_stopRecording();
        }

        public bool Discard()
        {
            return replaykit_discardRecording();
        }

        public string GetPreviewFilePath()
        {
            return replaykit_getPreviewFilePath();
        }

        public void SavePreview(string filename = null)
        {
            string previewFilePath  = GetPreviewFilePath();

            if (!string.IsNullOrEmpty(previewFilePath))
            {
                replaykit_savePreview(previewFilePath);
            }
            else
            {
                Debug.LogError("No preview recording available for saving!");
                return;
            }

        }


        public void SharePreview(string text = null, string subject = null)
        {
            replaykit_sharePreview(text, subject);
        }

        public bool Preview()
        {
            return replaykit_previewRecording();
        }

#endregion
    }
}
#endif