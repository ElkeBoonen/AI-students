using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DSPS
{
    public class Genes : IComparable<Genes>
    {
        Random random = new Random();
        public string Chromosone { get; set; }
        public int Fitness { get; private set; }

        public Genes(int length)
        {
            string s = "";
            int fitness = 0;
            for (int j = 0; j < length; j++)
            {
                int gene = random.Next(0, 2);
                s += gene;
                if (gene == 1) fitness++;
            }
            Chromosone = s;
            Fitness = fitness;
        }

        public Genes(string part1, string part2)
        {
            Chromosone = part1 + part2;
            Fitness = Regex.Matches(Chromosone, @"1").Count();
        }

        public Genes(string chromosone)
        {
            Chromosone = chromosone;
            Fitness = Regex.Matches(Chromosone, @"1").Count();
        }

        public int CompareTo(Genes other)
        {
            if (this.Fitness < other.Fitness) return -1;
            if (this.Fitness > other.Fitness) return 1;
            return 0;
        }
    }

    internal class GeneticAlgorithm
    {
        Random random = new Random();

        public void Run()
        {
            int populationSize = 20;
            int chromosomeLength = 8;
            int numberOfSelections = 5;
            int maxGenerations = 100;
            int generationCount = 0;


            // Initialization
            List<Genes> population = InitializePopulation(populationSize, chromosomeLength);

            while (generationCount < maxGenerations)
            {
                // Selection
                List<Genes> selected = Selection(population, numberOfSelections);

                // Crossover and Mutation
                List<Genes> newPopulation = new List<Genes>();
                for (int i = 0; i < selected.Count - 1; i += 2)
                {
                    Genes offspring1 = Crossover(selected[i], selected[i + 1]);
                    Genes offspring2 = Crossover(selected[i + 1], selected[i]);
                    newPopulation.Add(Mutation(offspring1));
                    newPopulation.Add(Mutation(offspring2));
                }
                population = newPopulation;
                generationCount++;
            }

            // Output the final population
            foreach (var individual in population)
                Console.WriteLine($"Chromosome: {individual.Chromosone}, Fitness: {individual.Fitness}");
        }

        private object CalculateFitness(string individual)
        {
            throw new NotImplementedException();
        }

        private Genes Mutation(Genes child)
        {
            int gene = random.Next(0, 2);
            int place = random.Next(0,child.Chromosone.Length);
            string chromosone = child.Chromosone;
            //chromosone[place] = (char)gene;
            return child;

        }

        private Genes Crossover(Genes c1, Genes c2)
        {
            int split = random.Next(0,c1.Chromosone.Length);
            return new Genes(c1.Chromosone.Substring(0, split), c2.Chromosone.Substring(split));

        }

        private List<Genes> Selection(List<Genes> population, int numberOfSelections)
        {
            population.Sort();
            population.Reverse();
            return population.Take(numberOfSelections).ToList<Genes>();
        }

        private List<Genes> InitializePopulation(int populationSize, int chromosomeLength)
        {
            List<Genes> population = new List<Genes>();
            for (int i = 0; i < populationSize; i++)
            {
                population.Add(new Genes(chromosomeLength));
            }
            return population;
        }
    }
}