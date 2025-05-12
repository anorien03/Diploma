using System;
using System.Drawing;
using System.Text;
using Diploma.Models;
using Diploma.Packers;

namespace Diploma
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


        private void OrderedCrossover(List<int> parent1, List<int> parent2, out List<int> child1, out List<int> child2)
        {
            int size = parent1.Count;

            var random = new Random();
            int a = random.Next(size);
            int b = random.Next(size);
            if (a > b) (a, b) = (b, a);

            child1 = Enumerable.Repeat(-1, size).ToList();
            child2 = Enumerable.Repeat(-1, size).ToList();

            for (int i = a; i < b; i++)
            {
                child1[i] = parent1[i];
                child2[i] = parent2[i];
            }

            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (i < a | i >= b)
                {
                    while (index < size && child1.Contains(parent2[index]))
                        index++;
                    child1[i] = parent2[index++];
                }
            }

            index = 0;
            for (int i = 0; i < size; i++)
            {
                if (i < a || i >= b)
                {
                    while (index < size && child2.Contains(parent1[index]))
                        index++;
                    child2[i] = parent1[index++];
                }
            }
        }


        private void Mutation(List<Individual> population)
        {

        }




    }
}

