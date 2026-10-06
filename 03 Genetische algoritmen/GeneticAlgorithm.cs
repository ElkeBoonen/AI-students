namespace GeneticAlgorithm
{
    internal class GA
    {
        private Random rd = new Random();
 
        private const int PopulationSize = 40;
        private const int ChromosomeLength = 50;
        private const int NumberOfSelections = 10;
        private const int MaxGenerations = 300;
 
        public void Run()
        {
            List<string> population = InitializePopulation(PopulationSize, ChromosomeLength);
 
            for (int generation = 1; generation <= MaxGenerations; generation++)
            {
                List<string> selected = Selection(population, NumberOfSelections);
 
                List<string> newPopulation = new List<string>();
                for (int i = 0; i < selected.Count - 1; i += 2)
                {
                    string offspring1 = Crossover(selected[i], selected[i + 1]);
                    string offspring2 = Crossover(selected[i + 1], selected[i]);
                    newPopulation.Add(Mutation(offspring1));
                    newPopulation.Add(Mutation(offspring2));
                }
                population = newPopulation;
 
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
            return population.OrderByDescending(CalculateFitness).Take(numberOfSelections).ToList();
        }
 
        private string Crossover(string v1, string v2)
        {
            int mom = rd.Next(2);
            string baby = "";
            int piece = rd.Next(0, v1.Length);
 
            if (mom == 0) baby += v1.Substring(0, piece) + v2.Substring(piece);
            else baby += v2.Substring(0, piece) + v1.Substring(piece);
 
            return baby;
        }
 
        private string Mutation(string offspring1)
        {
            int index = rd.Next(0, offspring1.Length);
            char[] mutant = offspring1.ToCharArray();
            mutant[index] = '1';
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
 