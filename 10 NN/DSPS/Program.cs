namespace DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] training_input = new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
            double[,] training_output = Matrix.Transpose(new double[,] { { 0, 1, 1, 0 } });

            var nn = new NN(training_input, training_output);

            Console.WriteLine("Weights before training:");
            Matrix.Print(nn.Weights);

            nn.Train();

            Console.WriteLine("Weights after training:");
            Matrix.Print(nn.Weights);

            double output = nn.Predict(new double[,] { { 1, 0, 1 } });
            Console.WriteLine("Predict [1, 0, 1] => " + output);

            output = nn.Predict(new double[,] { { 0,0,0 } });
            Console.WriteLine("Predict [0,0,1] => " + output);
        }
    }
}