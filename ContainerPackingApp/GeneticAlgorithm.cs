using System;
using ContainerPackingApp.Models.Diploma.Models;
using ContainerPackingApp.Packers;
using System.Collections.Generic;
using System.Linq;
using ContainerPackingApp.Models;

namespace ContainerPackingApp
{
    public class GeneticAlgorithm
    {
        private IPacker _packer { get; }
        private ShipHold _shipHold { get; set; }
        private List<Container> _containers { get; set; }

        public int PopulationSize { get; set; }
        public int GenerationsCount { get; set; }
        public int MutationRate { get; set; }
        public int TournamentSize { get; set; }
        public int Elitism { get; set; }

        public GeneticAlgorithm(IPacker packer, int populationSize, int generationsCount, int mutationRate, int tournamentSize, int elitism)
        {
            _packer = packer;
            PopulationSize = populationSize;
            GenerationsCount = generationsCount;
            MutationRate = mutationRate;
            TournamentSize = tournamentSize;
            Elitism = elitism;

            _shipHold = new ShipHold(0, 0, 0, 0);
            _containers = new List<Container>();
        }



        public PackerResult Run(ShipHold shipHold, List<Container> containers, out List<int> fitnessList)
        {
            _shipHold = shipHold;
            _containers = containers;

            var population = GeneratePopulation(PopulationSize);
            fitnessList = new List<int>();

            for (int g = 0; g < GenerationsCount; g++)
            {
                SortByFitness(population);
                fitnessList.Add(population[0].Fitness);

                List<Individual> elites;
                List<Individual> selected;
                Partition(population, out elites, out selected);


                var offspring = new List<Individual>();
                Individual child1;
                Individual child2;

                for (int k = 0; k < selected.Count - 1; k += 2)
                {
                    OrderedCrossover(selected[k], selected[k + 1], out child1, out child2);
                    offspring.Add(child1);
                    offspring.Add(child2);
                }

                if (selected.Count % 2 == 1) { offspring.Add(selected[selected.Count - 1]); }

                population = elites;
                population.AddRange(offspring);

                SortByFitness(population);

                Mutation(population);


                var populationCopy = population.ToList();
                int i = PopulationSize - 1;
                while (i > 0)
                {
                    int j = i - 1;
                    while (j >= 0)
                    {
                        if (populationCopy[i].Chromosome.SequenceEqual(populationCopy[j].Chromosome))
                        {
                            population.RemoveAt(i);
                            j = 0;
                        }
                        j--;
                    }

                    i--;
                }

                population.AddRange(GeneratePopulation(PopulationSize - population.Count));
            }

            SortByFitness(population);
            Console.WriteLine($"end: fitness = {population[0].Fitness}");

            return PackContainers(population[0]);

            //foreach (var a in population) { Console.WriteLine($"{a.Chromosome[0]} {a.Chromosome[1]} {a.Chromosome[2]} {a.Fitness}"); }

            //var elites = new List<Individual>();
            //var selected = new List<Individual>();
            //Partition(population, out elites, out selected);

            //Console.WriteLine("elites");
            //foreach (var a in elites) { Console.WriteLine($"{a.Chromosome[0]} {a.Chromosome[1]} {a.Chromosome[2]} {a.Fitness}"); }
            //Console.WriteLine("selected");
            //foreach (var a in selected) { Console.WriteLine($"{a.Chromosome[0]} {a.Chromosome[1]} {a.Chromosome[2]} {a.Fitness}"); }

            //Individual child1;
            //Individual child2;
            //Console.WriteLine();
            //Console.WriteLine();
            //Mutation(population);
            //Console.WriteLine();
            //foreach (var a in population[0].Chromosome) { Console.Write($"{a} "); }
            //Console.WriteLine();
            //foreach (var a in population[1].Chromosome) { Console.Write($"{a} "); }
            //Console.WriteLine();
            //foreach (var a in population[2].Chromosome) { Console.Write($"{a} "); }
            //Console.WriteLine();
            //foreach (var a in population[3].Chromosome) { Console.Write($"{a} "); }
            //Console.WriteLine();
            //foreach (var a in population[4].Chromosome) { Console.Write($"{a} "); }
            //Console.WriteLine();
            //foreach (var a in population[5].Chromosome) { Console.Write($"{a} "); }
            //Console.WriteLine();
            //foreach (var a in population[6].Chromosome) { Console.Write($"{a} "); }
        }














        private List<Individual> GeneratePopulation(int size)
        {
            var population = new List<Individual>();
            var containersId = _containers.Select(c => c.Id).ToList();

            while (population.Count < size)
            {
                var random = new Random();

                var chromosome = containersId.OrderBy(x => random.Next()).ToList();

                var exists = false;
                for (int j = 0; !exists & j < population.Count; j++)
                {
                    if (population[j].Chromosome.SequenceEqual(chromosome)) { exists = true; }
                }

                if (!exists)
                    population.Add(new Individual(chromosome));
            }

            return population;
        }


        private PackerResult PackContainers(Individual individual)
        {
            return _packer.PackContainers(_shipHold, _containers, individual.Chromosome);
        }


        private void SortByFitness(List<Individual> population)
        {
            population.ForEach(ind => ind.Fitness = _shipHold.Volume - PackContainers(ind).TotalVolume);
            population.Sort(new IndividualComparer());
        }


        private void Partition(List<Individual> sortedPopulation, out List<Individual> elites, out List<Individual> selected)
        {
            int elitesCount = Elitism * PopulationSize / 100;
            selected = new List<Individual>();
            elites = sortedPopulation.Take(elitesCount).ToList();

            for (int i = 0; i < PopulationSize - elitesCount; i++)
            {
                var random = new Random();

                var tournament = sortedPopulation.OrderBy(x => random.Next()).Take(TournamentSize).ToList();
                tournament.Sort(new IndividualComparer());
                selected.Add(tournament[0]);
            }
        }


        private void OrderedCrossover(Individual parent1, Individual parent2, out Individual child1, out Individual child2)
        {
            int size = parent1.Chromosome.Count;

            var random = new Random();
            int a = random.Next(size);
            int b = random.Next(size);
            if (a > b) (a, b) = (b, a);


            var chr1 = Enumerable.Repeat(-1, size).ToList();
            var chr2 = Enumerable.Repeat(-1, size).ToList();

            for (int i = a; i < b; i++)
            {
                chr1[i] = parent1.Chromosome[i];
                chr2[i] = parent2.Chromosome[i];
            }

            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (i < a | i >= b)
                {
                    while (index < size && chr1.Contains(parent2.Chromosome[index]))
                        index++;
                    chr1[i] = parent2.Chromosome[index++];
                }
            }

            index = 0;
            for (int i = 0; i < size; i++)
            {
                if (i < a || i >= b)
                {
                    while (index < size && chr2.Contains(parent1.Chromosome[index]))
                        index++;
                    chr2[i] = parent1.Chromosome[index++];
                }
            }

            child1 = new Individual(chr1);
            child2 = new Individual(chr2);
        }


        private void Mutation(List<Individual> population)
        {
            var size = _containers.Count;
            var random = new Random();
            for (int i = Elitism * PopulationSize / 100; i < PopulationSize; i++)
            {
                if (random.Next(100) < MutationRate)
                {
                    int a = random.Next(size);
                    int b = random.Next(size);
                    if (a > b) (a, b) = (b, a);
                    int c = size - b;
                    int d = b - a;
                    if (c > d) (c, d) = (d, c);

                    int genes = random.Next(c + 1);

                    for (int j = 0; j < genes; j++)
                        (population[i].Chromosome[a + j], population[i].Chromosome[b + j]) = (population[i].Chromosome[b + j], population[i].Chromosome[a + j]);
                }
            }
        }

    }
}

