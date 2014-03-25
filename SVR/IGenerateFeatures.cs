using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR
{
    interface IGenerateFeatures
    {
    }

    public class GenerateFeaturesFromFile : IGenerateFeatures
    {

    }

    public class GenerateFeaturesFromStream : IGenerateFeatures
    {

    }

    /// <summary>
    /// Implementation of the Kabsch Algorithm to find the optimal rigid rotatation matrix R 
    /// and translation vector t for between coordinate system A and coordinate system B.
    /// This is achieved by minimizing the root mean squared standard deviation (RMSD)
    /// between the set of points.
    /// 
    /// [see: http://en.wikipedia.org/wiki/Kabsch_algorithm]
    /// 
    /// Requires three steps
    ///     1. Translation
    ///     2. Covariance Matrix computation
    ///     3. Optimal Rotation Matrix computation
    ///     
    /// </summary>
    private class KabschAlgorithm
    {

        //public double[][] coordinatesA { get { return coordinatesA;} set{ coordinatesA = value;} }
        //public double[][] coordinatesB { get { return coordinatesB; } set { coordinatesB = value; } }

        private static readonly int DIMENSION_SIZE = 3;
        private static readonly int NUMBER_OF_POINTS = 20;

        /// <summary>
        /// Step 1.Need to ensure that origins of each coordinate system cooincides. 
        /// This is done by subtracting from the point coordinates the coordinates 
        /// of the respective centroid.
        /// </summary>
        /// <param name="coordinates"> A DxN matrix of points </param>
        /// <returns></returns>
        public static double[,] GetTranslation(double[,] coordinates)
        {
            double[,] translated = new double[DIMENSION_SIZE, NUMBER_OF_POINTS];

            return translated;
        }

        public static double[,] GetCovarianceMatrix(double[,] translatedA, double[,] translatedB)
        {
            double[,] covariance = new double[NUMBER_OF_POINTS, NUMBER_OF_POINTS];


            return covariance;
        }

        public static double[,] GetRotationMatrix(double[,] covariance)
        {
            double[,] rotation = new double[DIMENSION_SIZE, DIMENSION_SIZE];

            return rotation;
        }

        public static double[] GetTranslationVector(double[,] rotation)
        {
            double[] translation = new double[DIMENSION_SIZE];

            return translation;
        }

    }
}
