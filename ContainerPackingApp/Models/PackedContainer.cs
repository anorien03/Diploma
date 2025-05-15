using System;
namespace ContainerPackingApp.Models
{
    using System;
    namespace Diploma.Models
    {
        public class PackedContainer
        {
            public Container Container { get; }
            public int X0 { get; }
            public int Y0 { get; }
            public int Z0 { get; }
            public int X1 { get; }
            public int Y1 { get; }
            public int Z1 { get; }

            public PackedContainer(Container container, int x0, int y0, int z0, int x1, int y1, int z1)
            {
                Container = container;
                X0 = x0;
                Y0 = y0;
                Z0 = z0;
                X1 = x1;
                Y1 = y1;
                Z1 = z1;
            }
        }
    }


}

