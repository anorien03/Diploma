using System;
namespace Diploma.Models
{
	public class Individual
	{
		public List<int> Chromosome { get; }
		public int Fitness { get; set; } = -1;

		public Individual(List<int> chromosome)
		{
			Chromosome = chromosome;
		}
	}


    public class IndividualComparer : IComparer<Individual>
    {
        public int Compare(Individual? ind1, Individual? ind2)
        {
            if (ind1 == null || ind2 == null)
                return 0;

            return ind1.Fitness - ind2.Fitness;
        }
    }
}

