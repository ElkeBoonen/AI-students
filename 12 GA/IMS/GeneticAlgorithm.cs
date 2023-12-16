namespace IMS
{
    internal class GeneticAlgorithm
    {
        public int PopulationSize { get; set; }
        public int ChromosoneLength { get; set; }
        public int NumberOfSelections { get; set; }

        const int maxGenerations = 300;
        Random random = new Random();

        public GeneticAlgorithm(int populationSize, int chromosoneLength, int numberOfSelections)
        {
            PopulationSize = populationSize;
            ChromosoneLength = chromosoneLength;
            NumberOfSelections = numberOfSelections;
        }

        public void Run()
        {
            int generationCount = 0;

            // Initialization
            List<string> population = InitializePopulation();

            while (generationCount < maxGenerations)
            {
                // Selection
                List<string> selected = Selection(population);

                // Crossover and Mutation
                List<string> newPopulation = new List<string>();
                for (int i = 0; i < selected.Count - 1; i += 2)
                {
                    string offspring1 = Crossover(selected[i], selected[i + 1]);
                    string offspring2 = Crossover(selected[i + 1], selected[i]);
                    newPopulation.Add(Mutation(offspring1));
                    newPopulation.Add(Mutation(offspring2));
                }
                population = newPopulation;
                generationCount++;
            }

            // Output the final population
            foreach (var individual in population)
                Console.WriteLine($"Chromosome: {individual}, Fitness: {CalculateFitness(individual)}");
        }

        private string Mutation(string offspring1)
        {
            //int index = random.Next(ChromosoneLength);
            //char[] mutation = offspring1.ToCharArray();
            //mutation[index] = Convert.ToChar(random.Next(2).ToString());
            //return String.Join("", mutation);
            return offspring1;
        }

        private string Crossover(string v1, string v2)
        {
            int split = random.Next(ChromosoneLength);
            string crossover = v1.Substring(0, split) + v2.Substring(split, ChromosoneLength-split);
            return crossover;
        }

        private int CalculateFitness(string individual)
        {
            int count = 0;
            foreach (char c in individual)
            {
                if (c == '1') count++;
            }
            return count;
        }

        private List<string> Selection(List<string> population)
        {
            for (int i = 0; i < population.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < population.Count; j++)
                {
                    if (CalculateFitness(population[j]) < CalculateFitness(population[min])) min = j;
                }
                string b = population[i];
                population[i] = population[min];
                population[min] = b;
            }
            population.Reverse();

            /*foreach (var item in population)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();*/

            return population.Take(NumberOfSelections).ToList();
        }

        private List<string> InitializePopulation()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < PopulationSize; i++)
            {
                string chromosone = "";
                for (int j = 0; j < ChromosoneLength; j++)
                {
                    int n = random.Next(2);
                    chromosone += n.ToString();
                }
                list.Add(chromosone);
            }
            return list;
        }
    }
}