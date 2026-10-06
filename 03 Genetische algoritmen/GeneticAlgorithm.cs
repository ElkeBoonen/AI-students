namespace GeneticAlgorithm
{
    internal class GA
    {
        private Random rd = new Random();
 
        private const int PopulationSize = 40;
        private const int ChromosomeLength = 50;
        private const int NumberOfSelections = 15;
        private const int MaxGenerations = 300;
 
        public void Run()
        {
            List<string> population = InitializePopulation(PopulationSize, ChromosomeLength);
 
            for (int generation = 1; generation <= MaxGenerations; generation++)
            {
                List<string> newPopulation = Selection(population, NumberOfSelections).OrderByDescending(CalculateFitness).Take(5).ToList();
 
                while (newPopulation.Count < PopulationSize)
                {
                    string moeder = Selection(population, NumberOfSelections)[rd.Next(NumberOfSelections)];
                    string vader = Selection(population, NumberOfSelections)[rd.Next(NumberOfSelections)];
                    
                    (string offspring1, string offspring2) = Crossover(moeder, vader);
                    //string offspring2 = Crossover(vader, moeder);
                    newPopulation.Add(Mutation(offspring1));
                    newPopulation.Add(Mutation(offspring2));
                }
                population = newPopulation;
                Console.WriteLine(population.Count);
 
                int best = population.Max(CalculateFitness);
                double average = population.Average(CalculateFitness);
                Console.WriteLine($"Generatie {generation,3}: beste = {best,2}, gemiddeld = {average:F1}");
 
                if (best == ChromosomeLength) break;

            }
 
            string winner = population.OrderByDescending(CalculateFitness).First();
            Console.WriteLine($"Beste chromosoom: {winner}, Fitness: {CalculateFitness(winner)}");
        }
 
        private int CalculateFitness(string individual)
        {
            int result = 0;
            foreach (char c in individual)
            {
                if (c == '1') result++;
            }
            return result;
        }
 
        private List<string> Selection(List<string> population, int numberOfSelections)
        {
            List<string> selected = new List<string>();
            int totalFitness = population.Sum(CalculateFitness);
            for (int i =0; i < numberOfSelections; i++)
            {
                int randomValue = rd.Next(0,totalFitness);
                int currentFitness = 0;
                foreach (string chromosome in population)
                {
                    currentFitness += CalculateFitness(chromosome);
                    if (currentFitness > randomValue) { selected.Add(chromosome); break;}
                }
            }
            return selected;
        }
 
        private (string, string) Crossover(string v1, string v2)
        {
            int piece = rd.Next(0, v1.Length);
 
            string baby1 = v1.Substring(0, piece) + v2.Substring(piece);
            string baby2= v2.Substring(0, piece) + v1.Substring(piece);
 
            return (baby1,baby2);
        }
 
        private string Mutation(string offspring1)
        {
            char[] mutant = offspring1.ToCharArray();
            for (int index=0; index < mutant.Length; index++)
            {
                double kans = rd.NextDouble();
                if (kans <= 1/mutant.Length) mutant[index] = '1';
   
            }
            return String.Join("", mutant);
        }
 
        private List<string> InitializePopulation(int populationSize, int chromosomeLength)
        {
            List<string> population = new List<string>();
            for (int i = 0; i < populationSize; i++)
            {
                string chromosome = "";
                for (int j = 0; j < chromosomeLength; j++)
                {
                    chromosome += rd.Next(0, 2).ToString();
                }
                population.Add(chromosome);
            }
            return population;
        }
    }
}
 