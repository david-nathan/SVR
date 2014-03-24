using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;

namespace SVR
{
    class Program
    {

        private static readonly int INPUT_DIMENSION = 749;

        static void Main(string[] args)
        {            
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
           
            do
            {
                Console.WriteLine("\nPress a key S to start; press the 'x' key to quit.");

                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(250); // Loop until input is entered.
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.S)
                    {
                        Console.WriteLine("\nReading in Features.");

                        int featureSetSize = 0;
                        string rowline;

                        // Read the file and display it line by line.
                        System.IO.StreamReader nfile = new System.IO.StreamReader("features.csv");
                        while ((rowline = nfile.ReadLine()) != null)
                        {
                            featureSetSize++;
                        }

                        nfile.Close(); 

                        // Allocate inputs and outputs memory
                        double[][] inputs = new double[featureSetSize][];
                        double[] outputs = new double[featureSetSize];

                        int row = 0;
                        string line;

                        // Read the file and display it line by line.
                        System.IO.StreamReader file = new System.IO.StreamReader("features.csv");
                        while ((line = file.ReadLine()) != null)
                        {
                            //Console.WriteLine(line);
                            List<double> features = new List<double>();
                            double[] featuresArray = Array.ConvertAll(line.Split(','), new Converter<string, double>(Double.Parse));
                            features.AddRange(featuresArray);

                            double[] toadd = features.GetRange(1, INPUT_DIMENSION).ToArray();
                            inputs[row] = new double[INPUT_DIMENSION];
                            for (int col = 0; col < INPUT_DIMENSION; col++)
                            {
                                inputs[row][col] = toadd[col];
                            }                          
                            outputs[row] = features[features.Count - 1];
                            row++;
                        }

                        file.Close();                       

                        // Create Kernel Support Vector Machine with a Gaussian Kernelx
                        var machine = new KernelSupportVectorMachine(new Gaussian(), inputs:INPUT_DIMENSION);

                        // Create the sequential minimal optimization teacher
                        var learn = new SequentialMinimalOptimizationRegression(machine, inputs, outputs);

                        Console.WriteLine("\nRunning Machine");

                        // Run the learning algorithm
                        double error = learn.Run();

                        // Compute the answer for one particular example
                        double fxy = machine.Compute(inputs[0]);

                        //Write answer to console
                        Console.WriteLine("\nResult: {0}",fxy);
                    }
                }
            } while (cki.Key != ConsoleKey.X);           
        }
    }
}
