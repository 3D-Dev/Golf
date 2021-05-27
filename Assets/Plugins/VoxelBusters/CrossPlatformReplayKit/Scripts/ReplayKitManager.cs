using UnityEngine;
using System.Collections;

namespace VoxelBusters.ReplayKit
{
	using Internal;
    public class ReplayKitManager
    {

        #region Events

        public static event ReplayKitDelegates.InitialiseCallback               DidInitialise;
        public static event ReplayKitDelegates.RecordingStateChangedCallback    DidRecordingStateChange;

        #endregion

        #region Public Methods
        /// <summary>
        /// Initialise Replay Kit
        /// </summary>
        public static void Initialise()
        {
            if (!ReplayKitInternal.Instance.IsInitialised())
            {
                ReplayKitInternal.Instance.DidInitialiseEvent               += DidInitialise;
                ReplayKitInternal.Instance.DidRecordingStateChangeEvent     += DidRecordingStateChange;
                ReplayKitInternal.Instance.Initialise();
            }
            else
            {
                if(DidInitialise != null)
                {
                    DidInitialise(ReplayKitInitialisationState.Success, "Already initialised");
                }
            }
        }

        /// <summary>
        /// Check if Recording API is available on this platform
        /// </summary>
        /// <returns><c>true</c>, if recording API is available, <c>false</c> otherwise.</returns>
        public static bool IsRecordingAPIAvailable()
        {
            return ReplayKitInternal.Instance.IsRecordingAPIAvailable();
        }

        public static bool IsRecording()
        {
            return ReplayKitInternal.Instance.IsRecording();
        }

        public static bool IsPreviewAvailable()
        {
            return ReplayKitInternal.Instance.IsPreviewAvailable();
        }

        public static void StartRecording(bool enableMicrophone)
        {			
			ReplayKitInternal.Instance.StartRecording(enableMicrophone);
        }

        public static void StopRecording()
        {
            ReplayKitInternal.Instance.StopRecording();
        }

        public static bool Preview()
        {
            return ReplayKitInternal.Instance.Preview();
        }

        public static string GetPreviewFilePath()
        {
            return ReplayKitInternal.Instance.GetPreviewFilePath();
        }

        public static bool Discard()
        {
            return ReplayKitInternal.Instance.Discard();
        }

        public static void SavePreview(ReplayKitDelegates.SavePreviewCompleteCallback callback)
        {
            ReplayKitInternal.Instance.SavePreview(callback);
        }

        public static void SharePreview()
        {
            ReplayKitInternal.Instance.SharePreview(null);
        }

        #endregion

        #region Private Methods

        private static bool IsCameraEnabled()
        {
            return ReplayKitInternal.Instance.IsCameraEnabled();
        }

        #endregion


    }
}