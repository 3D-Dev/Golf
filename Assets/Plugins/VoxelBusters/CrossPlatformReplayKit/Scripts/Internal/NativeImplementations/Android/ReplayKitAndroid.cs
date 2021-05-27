using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_ANDROID
namespace VoxelBusters.ReplayKit.Internal
{
	public partial class ReplayKitAndroid : MonoBehaviour, INativeService
	{
        #region Fields

        private INativeCallbackListener 		m_listener;
        private bool                            m_allowControllingAudio;

        private Dictionary<AudioSource, float> collection = new Dictionary<AudioSource, float>();
        

        #endregion

        #region Constructors

        public ReplayKitAndroid()
		{
			AndroidJavaClass _class = new AndroidJavaClass(Native.Class.NAME);
			Plugin = _class.CallStatic<AndroidJavaObject>("getInstance");
		}

        #endregion

        #region INativeService implementation

        public void Initialise(INativeCallbackListener listener)
		{
			m_listener = listener;

            if (IsRecordingAPIAvailable())
            {
                bool isAppAudioPriority         = ReplayKitSettings.Instance.Android.PrioritiseAppAudioWhenUsingMicrophone;
                m_allowControllingAudio         = ReplayKitSettings.Instance.Android.AllowControllingAudio;

                Plugin.Call(Native.Methods.INITIALISE);
                Plugin.Call(Native.Methods.SET_APP_AUDIO_PRIORITY, isAppAudioPriority);
            }
            else
            {
                m_listener.OnInitialiseFailed("Replay Kit API not available");
            }
		}

        public bool IsRecordingAPIAvailable()
        {
            return Plugin.Call<bool>(Native.Methods.IS_RECORDING_API_AVAILABLE);
        }

        public bool IsRecording()
        {
            return Plugin.Call<bool>(Native.Methods.IS_RECORDING);
        }

        public bool IsPreviewAvailable()
        {
            return Plugin.Call<bool>(Native.Methods.IS_PREVIEW_AVAILABLE);
        }

        public bool IsCameraEnabled()
        {
            return Plugin.Call<bool>(Native.Methods.IS_CAMERA_ENABLED);
        }

        public void StartRecording(bool enableMicrophone)
        {
            if (!IsRecording())
            {
                if(m_allowControllingAudio)
                    PauseAudio();

                StartCoroutine(StartRecordingInternal(enableMicrophone));
            }
        }

        private IEnumerator StartRecordingInternal(bool enableMicrophone)
        {
            yield return new WaitForEndOfFrame();

            ReplayKitSettings.AndroidSettings androidSettings = ReplayKitSettings.Instance.Android;
            Plugin.Call(Native.Methods.START_RECORDING, enableMicrophone, (int)androidSettings.VideoMaxQuality, androidSettings.CustomBitrateSetting.AllowCustomBitrates ? androidSettings.CustomBitrateSetting.BitrateFactor : -1f);
        }

        public void StopRecording()
        {
            if (IsRecording())
            {
                if(m_allowControllingAudio)
                    PauseAudio();

                StartCoroutine(StopRecordingInternal());
            }
        }

        private IEnumerator StopRecordingInternal()
        {
            yield return new WaitForEndOfFrame();

            Plugin.Call(Native.Methods.STOP_RECORDING);
        }


        public bool Preview()
        {
            return Plugin.Call<bool>(Native.Methods.PREVIEW_RECORDING);
        }

        public bool Discard()
        {
            return Plugin.Call<bool>(Native.Methods.DISCARD_RECORDING);
        }

        public string GetPreviewFilePath()
        {
            return Plugin.Call<string>(Native.Methods.PREVIEW_FILE_PATH);
        }

        public void SavePreview(string filename = null)
        {
            if(!ReplayKitSettings.Instance.Android.AllowExternalStoragePermission)
            {
                string message = "Please enable AllowExternalStoragePermission in ReplayKit Settings and click on save to use this feature!";
                Debug.LogError("[ReplayKit] " + message);
                Plugin.Call(Native.Methods.SHOW_MESSAGE, message);
            }
            Plugin.Call(Native.Methods.SAVE_PREVIEW, filename);
        }

        public void SharePreview(string text = null, string subject = null)
        {
            Plugin.Call(Native.Methods.SHARE_PREVIEW, text, subject);
        }

        #endregion

        #region Helpers

        private void PauseAudio()
        {
            AudioSource[] audioArray = FindObjectsOfType<AudioSource>();
            collection.Clear();
            foreach (AudioSource each in audioArray)
            {
                if (each.isPlaying)
                {
                    //Debug.Log("Stop audio : " + each.name + " Time : " + each.time);
                    collection.Add(each, each.time);
                    each.Stop();
                }
            }
        }

        private void ResumeAudio()
        {
            StartCoroutine(ResumeAudioInternal());
        }

        private IEnumerator ResumeAudioInternal()
        {
            yield return new WaitForSeconds(0.1f);

            foreach (AudioSource each in collection.Keys)
            {
                each.time = collection[each];
                each.Play();
                //Debug.Log("Resume audio : " + each.name + " Time : " + each.time + " Mute ? : " + each.mute + " Is Playing : " + each.isPlaying);
            }
            collection.Clear();
        }

        #endregion
    }
}
#endif
