using UnityEngine;
using System.Collections;
using VoxelBusters.ReplayKit.Common.Utility;
using VoxelBusters.ReplayKit.Common.UASUtils;
using System;

#if UNITY_EDITOR
using UnityEditor;

#endif

namespace VoxelBusters.ReplayKit.Internal
{
	public partial class ReplayKitSettings : SharedScriptableObject<ReplayKitSettings>, IAssetStoreProduct
	{
		/// <summary>
		/// Application Settings specific to Android platform.
		/// </summary>
		[System.Serializable]
		public class AndroidSettings : BasePlatformSettings
		{
            [SerializeField]
            [Tooltip("Set the max resolution at which you want to record. Setting higher resolution will have larger final video sizes.")]
            private VideoQuality m_videoMaxQuality = VideoQuality.QUALITY_720P;

            [SerializeField]
            [Tooltip("Enabling custom bitrates lets you set recommended bitrates compared to default values which give very big file sizes")]
            private CustomBitRateSetting m_customVideoBitrate;           

            [SerializeField]
            [Space(30)]
            [Tooltip("Enable this if you want to use SavePreview feature. This adds external storage permission to the manifest. Default is true.")]
            private bool m_allowExternalStoragePermission = true;


            [SerializeField]
            [Header("Advanced Settings")]
            [Space(30)]
            [Tooltip("Enabling this will allow ReplayKit plugin to pause/resume audio sources to reduce load while starting/stopping recording. It is recommended to keep this setting on.")]
            private bool m_allowControllingAudio = true;

            [SerializeField]
            [Tooltip("This captures app audio better when enabled")]
            private bool m_prioritiseAppAudioWhenUsingMicrophone = false;

            [SerializeField]
            private bool m_androidQSupport = false;


            public VideoQuality VideoMaxQuality
			{
				get 
				{
					return m_videoMaxQuality;
				}
			}

            public CustomBitRateSetting CustomBitrateSetting
            {
                get
                {
                    return m_customVideoBitrate;
                }
            }

            public bool PrioritiseAppAudioWhenUsingMicrophone
            {
                get
                {
                    return m_prioritiseAppAudioWhenUsingMicrophone;
                }
            }

            public bool AllowExternalStoragePermission
            {
                get
                {
                    return m_allowExternalStoragePermission;
                }
            }

            public bool AllowControllingAudio
            {
                get
                {
                    return m_allowControllingAudio;
                }
            }

            public bool AndroidQSupport
            {
                get
                {
                    return m_androidQSupport;
                }
            }
        }
	}
}