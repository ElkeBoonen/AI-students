
namespace IMS_SVM
{
    internal class SimpleSVM
    {
        public double[] Weights;
        public double Bias;
        public SimpleSVM(int dimension)
        {
            Weights = new double[dimension];
        }

        private double DotProduct(double[] a, double[] b)
        {
            return a.Zip(b, (x, y) => x * y).Sum();
        }

        public object Predict(double[] doubles)
        {
            if (DotProduct(Weights, doubles) - Bias >= 0) return 1;
            return -1;
        }

        internal void Train(double[][] inputs, int[] labels, double learningrate, int epochs)
        {
            for (int count = 0; count < epochs; count++)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    double predict = DotProduct(Weights, inputs[i]) - Bias;
                    if (labels[i] * predict <= 0)
                    {
                        for (int j = 0; j < Weights.Length; j++)
                        {
                            Weights[j] += learningrate * labels[i] * inputs[i][j];
                        }
                        Bias -= learningrate * labels[i];
                    }
                }
            }
        }
    }
}