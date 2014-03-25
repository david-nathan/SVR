using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;
using System.Threading.Tasks;

namespace SVR
{

    /// <summary>
    ///  Abstract class for the set of values that represent Skeletal Data returned by Kinect.
    /// </summary>
    public abstract class FrameFeatures
    {

        [Flags]
        public enum DimensionType { X = 0, Y = 1, Z = 2 }

        [Flags]
        public virtual enum JointType
        {
            HipCenter = 0, Spine = 1, ShoulderCenter = 2, Head = 4,
            ShoulderLeft = 8, ElbowLeft = 16, WristLeft = 32, HandLeft = 64,
            ShoulderRight = 128, ElbowRight = 256, WristRight = 512, HandRight = 1024,
            HipLeft = 2048, KneeLeft = 4096, AnkleLeft = 8192, FootLeft = 16384,
            HipRight = 32768, KneeRight = 65536, AnkleRight = 131072, FootRight = 262144,
        }

    }
    /// <summary>
    /// Class that extends FrameFeatures by including Tracking State
    /// </summary>
    class SkeletonFeatures : FrameFeatures
    {
        public enum TrackingState { INVALID, CAMERAONETRACKING, CAMERATWOTRACKING, BOTHTRACKING }

        public Dictionary<JointType, Vector3D> skeletonFeature { get { return skeletonFeature; } set {skeletonFeature = value; } }

        public List<TrackingState> trackingStateList { get { return trackingStateList; } set { trackingStateList = value; } }

    }
}
