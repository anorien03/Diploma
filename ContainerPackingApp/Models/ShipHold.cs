using System;
namespace ContainerPackingApp.Models
{
    using System;
    namespace Diploma.Models
    {
        public class ShipHold
        {
            public int Length { get; }
            public int Width { get; }
            public int Height { get; }
            public int LiftCapacity { get; }
            public int Volume => Length * Width * Height;


            public ShipHold(int length, int width, int height, int liftCapacity)
            {
                Length = length;
                Width = width;
                Height = height;
                LiftCapacity = liftCapacity;
            }
        }
    }


}

