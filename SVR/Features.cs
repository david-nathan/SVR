using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR
{

    /// <summary>
    ///  Abstract class for the set of values that represent Skeletal Data returned by Kinect.
    /// </summary>
    public abstract class FrameFeatures
    {

        [Flags]
        public enum DimensionType { X = 0, Y = 1, Z = 2}

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
    /// Abtract class for the feature set used in the SVM Prediction.
    /// Note: When Dimension type X and Y are used concurrently with Feature type Joint Angle,
    /// they represent the Roll and Pitch respectively. 
    /// </summary>
    public abstract class SVMFeatures : FrameFeatures
    {        

        /// <summary>
        ///  Enumerations for the Feature Set used in the SVM
        /// </summary>
        [Flags]
        public override enum JointType {HipCenter = 0,Spine = 1, ShoulderCenter = 2, Head = 4, 
                                   ShoulderLeft = 8, ElbowLeft = 16, WristLeft = 32, HandLeft = 64,
                                   ShoulderRight = 128, ElbowRight = 256, WristRight = 512, HandRight = 1024, 
                                   HipLeft = 2048, KneeLeft = 4096, AnkleLeft = 8192, FootLeft = 16384,
                                   HipRight = 32768,  KneeRight = 65536, AnkleRight = 131072, FootRight =262144,

                                   Shoulder = ShoulderLeft & ShoulderRight, Elbow = ElbowLeft & ElbowRight,
                                   Wrist = WristLeft & WristRight, Hand = HandLeft & HandRight,
                                   Hip = HipLeft & HipRight, Knee = KneeLeft & KneeRight,
                                   Ankle= AnkleLeft & AnkleRight, Foot = FootLeft & FootRight,

                                   LeftArm = ShoulderLeft & ElbowLeft & WristLeft & HandLeft,
                                   RightArm = ShoulderRight & ElbowRight & WristRight & HandRight,
                                   UpperBody = Spine & ShoulderCenter & Head & LeftArm  & RightArm,
                                   LeftLeg = HipLeft & KneeLeft & AnkleLeft & FootLeft,
                                   RightLeg = HipRight & KneeRight & AnkleRight & FootRight,
                                   LowerBody = HipCenter & LeftLeg & RightLeg,
                                   TotalBody = LowerBody & UpperBody} 

        /// <summary>
        /// AVG = Average
        /// STD = Standard Deviation
        /// MAX = Maximum
        /// MIN = Minimum
        /// </summary>                             
        [Flags]
        public enum StatType { AVG = 0, STD = 1, MAX = 2, MIN=4 }

        /// <summary>
        /// RAW = raw position or angle value, zeroth-order time value
        /// VEL = velocity, first-order time value
        /// ACC = acceleration, second-order time value
        /// </summary>
        [Flags]
        public enum TimeType { RAW = 0, VEL = 1, ACC = 2 }

        /// <summary>
        /// POS     = position
        /// JNT_ANG = joint angle
        /// JNT_ASY = joint assymetry
        /// </summary>
        [Flags]
        public enum FeatureType { POS = 0, JNT_ANG = 1, JNT_ASY = 2 }

        /// <summary>
        ///  Data structure for the feature set. Key is feature name. Value is calculated value. 
        /// </summary>
        Dictionary<string, double> features = new Dictionary<string, double>();
    }
    
    public class Jump : SVMFeatures
    {
        static Jump(DimensionType dim, JointType jnt, StatType stat, TimeType tm, FeatureType ftr) { }        
    }

    public class Kick : SVMFeatures
    {
        static Kick(DimensionType dim, JointType jnt, StatType stat, TimeType tm, FeatureType ftr) { }
    }

    public class Throw : SVMFeatures
    {
        static Throw(DimensionType dim, JointType jnt, StatType stat, TimeType tm, FeatureType ftr) { }
    }

    public class Catch : SVMFeatures
    {
        static Catch(DimensionType dim, JointType jnt, StatType stat, TimeType tm, FeatureType ftr) { }
    }

    public class SideStep : SVMFeatures
    {
        static SideStep(DimensionType dim, JointType jnt, StatType stat, TimeType tm, FeatureType ftr) { }
    }
}
