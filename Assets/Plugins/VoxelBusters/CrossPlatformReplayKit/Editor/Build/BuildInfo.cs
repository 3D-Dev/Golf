using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VoxelBusters.ReplayKit.Internal
{
    public class BuildInfo 
    {
        #region Properties

        public BuildTarget Target
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        #endregion
    }
}