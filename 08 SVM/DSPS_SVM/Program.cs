using System.Linq;

namespace DSPS_SVM
{
    internal class Program
    {

        static (double[][],int[]) Read(string filename)
        {
            List<double[]> result = new List<double[]>();
            List<int> labels = new List<int>();
            foreach (var line in File.ReadAllLines(filename).Skip(1))
            { 
                string[] split = line.Split(',');
                double[] data = { Convert.ToDouble(split[0]), Convert.ToDouble(split[1]), Convert.ToDouble(split[2]) };
                labels.Add(Convert.ToInt32(split[3]));
                result.Add(data);
            }
            return (result.ToArray(), labels.ToArray());
        }

        static void Main(string[] args)
        {

            //https://machinelearningmastery.com/standard-machine-learning-datasets/

            var svm = new SimpleSVM(3);
            double[][] inputs = { new double[] { 1, 2, 3 }, new double[] { 2, 3, 4 }, new double[] { 3, 3, 5 } };
            int[] labels = { 1, -1, -1 };

            svm.Train(inputs, labels, 0.01, 1000);

            var prediction = svm.Predict(new double[] { 1.5, 2.5, 3.5 });
            Console.WriteLine($"Prediction: {prediction}");

            prediction = svm.Predict(new double[] { 1.1, 2.1, 3.1 });
            Console.WriteLine($"Prediction: {prediction}");

            prediction = svm.Predict(new double[] { 2.1, 2.9, 4.1 });
            Console.WriteLine($"Prediction: {prediction}");


            (double[][] inputs1, int[] labels1) = Read("Large_SVM_Test_Dataset.csv");

            svm.Train(inputs1, labels1, 0.01, 1000);

            prediction = svm.Predict(new double[] { -2.1, -2.9, 4.1 });
            Console.WriteLine($"Prediction: {prediction}");

            prediction = svm.Predict(new double[] { 1.1, 2.1, 3.1 });
            Console.WriteLine($"Prediction: {prediction}");

        }
    }
}
