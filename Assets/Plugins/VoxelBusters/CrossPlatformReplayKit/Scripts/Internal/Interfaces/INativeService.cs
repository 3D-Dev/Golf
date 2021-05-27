using UnityEngine;
using System.Collections;

namespace VoxelBusters.ReplayKit.Internal
{
    public interface INativeService
    {
        // Init
        void Initialise(INativeCallbackListener listener);

        // Query
        bool IsRecordingAPIAvailable();
        bool IsRecording();
        bool IsPreviewAvailable();
        bool IsCameraEnabled();

        // Actions
        void    StartRecording(bool enableMicrophone);
        void    StopRecording();
        bool    Preview();
        bool    Discard();
        string  GetPreviewFilePath();

        void    SavePreview(string filename = null);
        void    SharePreview(string text = null, string subject = null);
    }
}