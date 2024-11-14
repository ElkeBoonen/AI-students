
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Emit;
using System.Reflection;

namespace DSPS_SVM
{
    internal class SimpleSVM
    {
        private double[] Weights;
        private double Bias;

        public SimpleSVM(int v)
        {
            Weights = new double[v];
        }

        private double DotProduct(double[] a, double[] b)
        {
            return a.Zip(b, (x, y) => x * y).Sum();
        }

        /*
            It calculates the dot product of the input and the weights, 
            subtracts the bias, and checks if the result is greater than 
            or equal to 0. If so, it predicts class 1; otherwise, it predicts class -1.
         */
        public object Predict(double[] doubles)
        {
            if ((DotProduct(Weights, doubles) - Bias) >= 0) return 1;
            return -1;
        }
        /*
            iterates over the dataset for the given number of epochs.
            In each iteration, it checks if each input sample is misclassified by the current model.
            Misclassification is determined by checking if the product of the label and the SVM decision function is less than or equal to 0.
            If a sample is misclassified, it updates the Weights and Bias to correct the model.
        */
        internal void Train(double[][] inputs, int[] labels, double learningrate, int epochs)
        {
            for (int count = 0; count < epochs; count++)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    double[] input = inputs[i];
                    int label = labels[i];

                    if (label * (DotProduct(Weights, input)) - Bias <= 0)
                    {
                        for (int j = 0; j < Weights.Length; j++)
                        {
                            Weights[j] += learningrate * label * input[j];
                        }
                        Bias -= learningrate * label;
                    }
                }
            }
        }
    }
}