using System;
namespace ContainerPackingApp.Models
{
    public class Container
    {
        public int Id { get; }
        public int Length { get; }
        public int Width { get; }
        public int Height { get; }
        public int Weight { get; }
        public int Volume => Length * Width * Height;


        public Container(int id, int length, int width, int height, int weight)
        {
            Id = id;
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }


        public Container rotate()
        {
            return new Container(Id, Width, Length, Height, Weight);
        }
    }
}

