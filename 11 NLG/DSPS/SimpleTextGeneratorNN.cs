using SimpleTextGeneratorNN;
using System.Text.RegularExpressions;

namespace DSPS
{
    public class SimpleTextGeneratorNN
    {
        private const int nrOfChars = 26;
        private const double learningRate = 0.1;
        private const int epochs = 1000;
        public double[,] Weights { get; private set; }

        public SimpleTextGeneratorNN()
        {
            Random rd = new Random();
            Weights = new double[nrOfChars, nrOfChars];
            for (int i = 0; i < nrOfChars; i++)
            {
                for (int j = 0; j < nrOfChars; j++)
                {
                    Weights[i, j] = rd.NextDouble();
                }
            }
        }

        internal void Train(string text)
        {
            Regex regex = new Regex("[^a-z]");
            text = regex.Replace(text.ToLower(), "");

            for (int e = 0; e < epochs; e++)
            {
                for (int i = 0; i < text.Length-1; i++)
                {
                    char current = text[i];
                    char next = text[i+1];

                    double[,] input = Convert(current);
                    double[,] target = Convert(next);

                    double[,] output = Matrix.DotProduct(input, Weights);
                    double[,] error = Matrix.Substract(target, output);

                    for (int j = 0; j < nrOfChars; j++)
                    {
                        for (int k = 0; k < nrOfChars; k++)
                        {
                            Weights[j, k] += learningRate * error[0, k] * input[0, j];
                        }
                    }
                }
            }

        }


        private double[,] Convert(char c)
        {
            int index = c - 'a';
            double[,] vector = new double[1,nrOfChars];
            vector[0, index] = 1;
            return vector;

        }

        public char PredictNextChar(char nextChar)
        {
            throw new NotImplementedException();
        }

       
    }
}