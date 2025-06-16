using System;
using ContainerPackingApp.Models.Diploma.Models;
using System.Collections.Generic;
using ContainerPackingApp.Models;
using System.Linq;

namespace ContainerPackingApp.Packers
{
	public class PackerEMSNoOrint: IPacker
	{
        private PackedContainer? DoesEmsFit(EMS ems, Container container, ShipHold shipHold)
        {
            if (ems.Fits(container))
            {
                return new PackedContainer(container, ems.X0, ems.Y0, ems.Z0,
                            ems.X0 + container.Length, ems.Y0 + container.Width, ems.Z0 + container.Height);
                    
            }

            return null;
        }



        public PackerResult PackContainers(ShipHold shipHold, List<Container> containers, List<int> order)
        {
            List<PackedContainer> coordinates = new List<PackedContainer>();
            var unpackedWeightContainersId = new List<int>();
            var unpackedSpaceContainersId = new List<int>();
            List<EMS> EMSs = new List<EMS>() { new EMS(0, 0, 0, shipHold.Length, shipHold.Width, shipHold.Height) };

            int totalWeight = 0;
            int totalVolume = 0;

            foreach (var id in order)
            {
                var container = containers.First(c => c.Id == id);

                if (totalWeight + container.Weight > shipHold.LiftCapacity)
                {
                    unpackedWeightContainersId.Add(container.Id);
                    continue;
                }


                PackedContainer? packedContainer = null;

                foreach (var ems in EMSs)
                {
                    packedContainer = DoesEmsFit(ems, container, shipHold);

                    if (packedContainer != null) { break; }
                }

                if (packedContainer == null)
                {
                    unpackedSpaceContainersId.Add(container.Id);
                    continue;
                }

                coordinates.Add(packedContainer);
                totalWeight += container.Weight;
                totalVolume += container.Volume;


                foreach (var ems in EMSs.ToList())
                {
                    if (ems.Overlaps(packedContainer) | ems.Covers(packedContainer))
                    {
                        EMSs.Remove(ems);
                        var newEMSs = ems.Accomodate(packedContainer);

                        foreach (var newEms in newEMSs)
                        {
                            var valid = newEms.IsValid();

                            int i = EMSs.Count - 1;

                            while (i >= 0 & valid)
                            {
                                if (EMSs[i].Covers(newEms)) { valid = false; }
                                if (newEms.Covers(EMSs[i])) { EMSs.RemoveAt(i); }
                                i -= 1;
                            }

                            if (valid) { EMSs.Add(newEms); }
                        }

                    }
                }

                EMSs.Sort(new EMSComparer());
            }

            return new PackerResult(coordinates, unpackedWeightContainersId, unpackedSpaceContainersId, totalWeight, totalVolume);
        }
    }
}

