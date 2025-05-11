using System;
using Diploma.Models;

namespace Diploma.Packers
{
	public class PackerResult
	{
        public List<PackedContainer> PackedContainers { get; }
        public List<int> UnpackedWeightContainersId { get; }
		public List<int> UnpackedSpaceContainersId { get; }
		public int TotalWeight { get; }
		public int TotalVolume { get; }

        public PackerResult(List<PackedContainer> packedContainers, List<int> unpackedWeightContainersId, List<int> unpackedSpaceContainersId,
            int totalWeight, int totalVolume)
		{
			PackedContainers = packedContainers;
			UnpackedWeightContainersId = unpackedWeightContainersId;
			UnpackedSpaceContainersId = unpackedSpaceContainersId;
			TotalWeight = totalWeight;
			TotalVolume = totalVolume;
		}
	}
}

