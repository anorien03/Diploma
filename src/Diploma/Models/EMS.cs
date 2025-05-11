using System;
namespace Diploma.Models
{
	public class EMS
	{
        public int X0 { get; }
        public int Y0 { get; }
        public int Z0 { get; }
        public int X1 { get; }
        public int Y1 { get; }
        public int Z1 { get; }
        public int Volume => (X1 - X0) * (Y1 - Y0) * (Z1 - Z0);

        public EMS(int x0, int y0, int z0, int x1, int y1, int z1)
		{
            X0 = x0;
            Y0 = y0;
            Z0 = z0;
            X1 = x1;
            Y1 = y1;
            Z1 = z1;
        }


        public bool IsValid()
        {
            return X0 < X1 & Y0 < Y1 & Z0 < Z1;
        }

        public bool Fits(Container container)
        {
            return container.Length <= X1 - X0 & container.Width <= Y1 - Y0 & container.Height <= Z1 - Z0;
        }


        public bool Overlaps(PackedContainer container)
        {
            return X0 < container.X1 & Y0 < container.Y1 & Z0 < container.Z1 & X1 > container.X0 & Y1 > container.Y0 & Z1 > container.Z0;
        }


        public bool Covers(PackedContainer container)
        {
            return X0 <= container.X0 & Y0 <= container.Y0 & Z0 <= container.Z0 & X1 >= container.X1 & Y1 >= container.Y1 & Z1 >= container.Z1;
        }

        public bool Covers(EMS ems)
        {
            return X0 <= ems.X0 & Y0 <= ems.Y0 & Z0 <= ems.Z0 & X1 >= ems.X1 & Y1 >= ems.Y1 & Z1 >= ems.Z1;
        }


        public List<EMS> Accomodate(PackedContainer container)
        {
            return new List<EMS>()
            {
                new EMS(X0, Y0, Z0, container.X0, Y1, Z1),
                new EMS(container.X1, Y0, Z0, X1, Y1, Z1),
                new EMS(X0, Y0, Z0, X1, container.Y0, Z1),
                new EMS(X0, container.Y1, Z0, X1, Y1, Z1),
                new EMS(X0, Y0, Z0, X1, Y1, container.Z0),
                new EMS(X0, Y0, container.Z1, X1, Y1, Z1),
            };
        }
    }


    public class EMSComparer : IComparer<EMS>
    {
        public int Compare(EMS? ems1, EMS? ems2)
        {
            if (ems1 == null || ems2 == null)
                return 0;

            return ems1.Volume - ems2.Volume;
        }
    }
}

