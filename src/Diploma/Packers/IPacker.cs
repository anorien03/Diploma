using System;
using Diploma.Models;

namespace Diploma.Packers
{
	public interface IPacker
	{
        PackerResult PackContainers(ShipHold shipHold, List<Container> containers, List<int> chromosome);

    }
}

