namespace IMS
{
    internal class SimpleSVM
    {

        public double[] Weights;
        public double Bias;

        public SimpleSVM(int dimension)
        {
            Weights = new double[dimension];
        }


        /*It calculates the dot product of the input and the weights, 
         * subtracts the bias, and checks if the result is greater 
         * than or equal to 0. If so, it predicts class 1; otherwise, it predicts class -1.*/
        public int Predict(double[] doubles)
        {
            double dp = DotProduct(doubles, Weights) - Bias;
            if (dp >= 0) return 1;
            return -1;
        }

        /*
         iterates over the dataset for the given number of epochs.
         In each iteration, it checks if each input sample is misclassified 
            by the current model. Misclassification is determined by checking if the product
            of the label and the SVM decision function is less than or equal to 0.
            If a sample is misclassified, it updates the Weights and Bias to correct the model.
         */

        public void Train(double[][] inputs, int[] labels, double learningrate, int epochs)
        {
            for (int i = 0; i < epochs; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    if (labels[j] != Predict(inputs[j]))
                    {
                        for (int k = 0; k < Weights.Length; k++)
                        {
                            Weights[k] += learningrate * labels[j] * inputs[j][k];
                        }
                        Bias -= learningrate * labels[j];
                    }
                }
            }
        }

        private double DotProduct(double[] a, double[] b)
        {
            return a.Zip(b, (x, y) => x * y).Sum();
        }


    }
}