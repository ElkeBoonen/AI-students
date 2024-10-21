namespace KNN_IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            /*
                5.7,3.8,1.7,0.3,setosa
                5.1,3.8,1.5,0.3,setosa
                5.4,3.4,1.7,0.2,setosa
                6.1,2.8,4.7,1.2,versicolor
                6.4,2.9,4.3,1.3,versicolor
                6.3,2.8,5.1,1.5,virginica
                6.1,2.6,5.6,1.4,virginica 
             */


            KNN knn = new KNN("iris.dat");
            Console.WriteLine(knn.Classify(new double[] { 6.1, 2.6, 5.6, 1.4 }));

            //Weight (grams),Diameter (cm),Sweetness (%),Color Intensity (scale),Fruit Type

            /*   Weight (grams)  Diameter (cm)  Sweetness (%)  Color Intensity (scale)  \
                0      157.168205       8.944781      92.533520                 9.209144   
                1      121.749361       5.272946      89.071679                 5.698862   
                2      153.936204       7.954309      93.775942                 8.976337   
                3      106.979899       4.900524      64.350403                 6.008137   
                4      142.925411       7.248265      85.580362                 5.818280   

                  Fruit Type  
                0      Apple  
                1     Orange  
                2      Apple  
                3     Orange  
                4     Banana  */


            knn = new KNN("fruit_classification_dataset.csv");
            Console.WriteLine(knn.Classify(new double[] { 157.168205,8.944781,92.533520,9.209144 }));
        }
    }
}
