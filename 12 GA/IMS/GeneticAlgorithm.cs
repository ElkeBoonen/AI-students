namespace IMS
{
    internal class GeneticAlgorithm
    {
        public int PopulationSize { get; set; }
        public int ChromosoneLength { get; set; }
        public int NumberOfSelections { get; set; }

        const int maxGenerations = 50;

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
            List<string> population = InitializePopulation(populationSize, chromosomeLength);

            while (generationCount < maxGenerations)
            {
                // Selection
                List<string> selected = Selection(population, numberOfSelections);

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
    }
}