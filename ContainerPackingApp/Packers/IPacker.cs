using System;
using ContainerPackingApp.Models.Diploma.Models;
using System.Collections.Generic;
using ContainerPackingApp.Models;

namespace ContainerPackingApp.Packers
{
    public interface IPacker
    {
        PackerResult PackContainers(ShipHold shipHold, List<Container> containers, List<int> order);

    }
}

