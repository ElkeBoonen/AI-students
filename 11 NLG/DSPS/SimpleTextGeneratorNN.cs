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

        internal void Train(string v)
        {
            throw new NotImplementedException();
        }
        internal char PredictNextChar(char nextChar)
        {
            throw new NotImplementedException();
        }

       
    }
}