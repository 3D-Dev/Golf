using VoxelBusters.ReplayKit.Common.DesignPatterns;

namespace VoxelBusters.ReplayKit
{
	using Internal;
    using UnityEngine;

    internal partial class ReplayKitInternal : SingletonPattern<ReplayKitInternal>, INativeCallbackListener
    {
        INativeService m_service;
        private bool m_enableMicrophone;
        private ReplayKitDelegates.SavePreviewCompleteCallback m_savePreviewCallback;

        private bool m_audioListenerStatus;
        private bool m_isInitialised;

        #region Query Methods

        public void Initialise()
        {
            m_isInitialised = true;
            m_service.Initialise(this);
        }

        public bool IsInitialised()
        {
            return m_isInitialised;
        }

        public bool IsRecordingAPIAvailable()
        {
			return m_service.IsRecordingAPIAvailable();
        }

        public bool IsCameraEnabled()
        {
			return m_service.IsCameraEnabled();
        }

        public bool IsRecording()
        {
            return m_service.IsRecording();
        }

        public bool IsMicrophoneEnabled()
        {
            return m_enableMicrophone;
        }

        public bool IsPreviewAvailable()
        {
            return m_service.IsPreviewAvailable();
        }

        #endregion

        #region Recording Operations

        public void StartRecording(bool enableMicrophone)
        {
            m_enableMicrophone          = enableMicrophone;
            m_service.StartRecording(enableMicrophone);
        }

        public void StopRecording()
        {
            m_service.StopRecording();
        }


        public bool Preview()
        {
            return m_service.Preview();
        }

        public string GetPreviewFilePath()
        {
            return m_service.GetPreviewFilePath();
        }

        public bool Discard()
        {
            return m_service.Discard();
        }


#endregion

#region Utility

        public void SavePreview(ReplayKitDelegates.SavePreviewCompleteCallback callback)
        {
            m_savePreviewCallback = callback;
            m_service.SavePreview();
        }

        public void SharePreview(string text = null, string subject = null)
        {
            m_service.SharePreview(text, subject);
        }

#endregion


#region Overriden Methods

        protected override void Init()
        {
            base.Init();

            // Not interested in non singleton instance
            if (instance != this)
                return;

#if (UNITY_ANDROID && !UNITY_EDITOR)
			m_service = this.gameObject.AddComponent<ReplayKitAndroid>();
#elif (UNITY_IOS && !UNITY_EDITOR)
			m_service = this.gameObject.AddComponent<ReplayKitIOS>();
#else
			m_service = this.gameObject.AddComponent<ReplayKitDefaultPlatform>();
#endif
        }

#endregion
    }
}