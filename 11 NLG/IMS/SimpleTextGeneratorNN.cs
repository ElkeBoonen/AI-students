using System.ComponentModel;
using System.Text.RegularExpressions;

namespace IMS
{
    public class SimpleTextGeneratorNN
    {
        private const int nrChars = 26;
        private const double learningRate = 0.1;
        private const int epochs = 1000;
        public double[,] Weights { get; private set; }

        public SimpleTextGeneratorNN()
        {
            Random rd = new Random();
            Weights = new double[nrChars, nrChars];
            for (int i = 0; i < nrChars; i++)
            {
                for (int j = 0; j < nrChars; j++)
                {
                    Weights[i,j] = rd.NextDouble();
                }
            }
        }

        internal char PredictNextChar(char nextChar)
        {
            double[,] input = CharToOneHot(nextChar);
            double[,] output = Matrix.DotProduct(input, Weights);

            double max = double.MinValue;
            int index = -1;
            for (int i = 0; i < nrChars; i++)
            {
                if (max < output[0, i])
                {
                    max = output[0, i];
                    index = i;
                }
            }
            return (char)(index + 'a');
        }

        private double[,] CharToOneHot(char c)
        {
            double[,] vector = new double[1, nrChars];
            //int index = "abcdefghijklmnopqrstuvwxyz".IndexOf(c);
            int index = c - 'a';
            vector[0, index] = 1;
            return vector;
        }

        internal void Train(string text)
        {
            text = text.ToLower();
            Regex regex = new Regex("[^a-z]");
            text = regex.Replace(text, ""); 

            for (int e = 0; e < epochs; e++)
            {
                for (int i = 0; i < text.Length-1; i++)
                {
                    char current = text[i];
                    char next = text[i + 1];

                    double[,] input = CharToOneHot(current);
                    double[,] target = CharToOneHot(next);

                    double[,] output = Matrix.DotProduct(input, Weights);
                    double[,] error = Matrix.Substract(target, output);

                    for (int j = 0; j < nrChars; j++)
                    {
                        for (int k = 0; k < nrChars; k++)
                        {
                            Weights[j, k] += learningRate * error[0, k] * input[0, j];
                        }
                    }
                    
                }
            }
        }
    }
}