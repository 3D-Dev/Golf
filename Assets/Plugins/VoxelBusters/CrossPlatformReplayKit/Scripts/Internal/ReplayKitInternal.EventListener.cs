using VoxelBusters.ReplayKit.Common.DesignPatterns;

namespace VoxelBusters.ReplayKit
{
    using System;
    using Internal;
    using UnityEngine;

    internal partial class ReplayKitInternal : SingletonPattern<ReplayKitInternal>, INativeCallbackListener
    {
        #region Events

        public  event ReplayKitDelegates.InitialiseCallback                 DidInitialiseEvent;
        public  event ReplayKitDelegates.RecordingStateChangedCallback      DidRecordingStateChangeEvent;
        private event ReplayKitDelegates.PreviewStateChangedCallback        DidPreviewStateChangeEvent; // For future updates, we provide preview states. So currently making it private

        #endregion


        #region INativeCallbackListener implementation

        public void OnInitialiseSuccess ()
		{
            Dispatch(() =>
            {
                if (DidInitialiseEvent != null)
                {
                    DidInitialiseEvent(ReplayKitInitialisationState.Success, string.Empty);
                }
            });
		}

        public void OnInitialiseFailed(string message)
        {
            Dispatch(() =>
            {
                if (DidInitialiseEvent != null)
                {
                    DidInitialiseEvent(ReplayKitInitialisationState.Failed, message);
                }
            });
        }

        public void OnRecordingStarted ()
		{

            Dispatch(() =>
            {
                if (DidRecordingStateChangeEvent != null)
                {
                    DidRecordingStateChangeEvent(ReplayKitRecordingState.Started, string.Empty);
                }
            });
		}

        public void OnRecordingStopped()
        {
            Dispatch(() =>
            {
                if (DidRecordingStateChangeEvent != null)
                {
                    DidRecordingStateChangeEvent(ReplayKitRecordingState.Stopped, string.Empty);
                }
            });
        }

        public void OnRecordingFailed(string message)
        {
            Dispatch(() =>
            {
                if (DidRecordingStateChangeEvent != null)
                {
                    DidRecordingStateChangeEvent(ReplayKitRecordingState.Failed, message);
                }
            });
        }

        public void OnRecordingAvailable()
        {
            Dispatch(() =>
            {
                if (DidRecordingStateChangeEvent != null)
                {
                    DidRecordingStateChangeEvent(ReplayKitRecordingState.Available, string.Empty);
                }
            });
        }


        public void OnPreviewOpened()
        {
            Dispatch(() =>
            {
                if (DidPreviewStateChangeEvent != null)
                {
                    DidPreviewStateChangeEvent(ReplayKitPreviewState.Opened, string.Empty);
                }
            });
        }

        public void OnPreviewClosed()
        {
            Dispatch(() =>
            {
                if (DidPreviewStateChangeEvent != null)
                {
                    DidPreviewStateChangeEvent(ReplayKitPreviewState.Closed, string.Empty);
                }
            });
        }

        public void OnPreviewPlayed()
        {
            Dispatch(() =>
            {
                if (DidPreviewStateChangeEvent != null)
                {
                    DidPreviewStateChangeEvent(ReplayKitPreviewState.Played, string.Empty);
                }
            });
        }

        public void OnPreviewShared()
        {
            Dispatch(() =>
            {
                if (DidPreviewStateChangeEvent != null)
                {
                    DidPreviewStateChangeEvent(ReplayKitPreviewState.Shared, string.Empty);
                }
            });
        }

        public void OnPreviewSaved(string error)
        {
            Dispatch(() =>
            {
                if (m_savePreviewCallback != null)
                {
                    m_savePreviewCallback(string.IsNullOrEmpty(error) ? null : error);
                }
            });
        }

        #endregion

        #region Private methods

        private void Dispatch(Action action)
        {
            UnityThreadDispatcher.Enqueue(action);
        }

        #endregion
    }
}