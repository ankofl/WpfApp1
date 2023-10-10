using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Geometry
{
    public class XYZ
    {
        public double X, Y, Z = double.NaN;
        public int ContainIn(List<XYZ> listPt)
        {
            int count = 0;
            foreach(XYZ pt in listPt)
            {
                if (Equal(pt))
                    count++;
            }
            return count;
        }
        public bool Equal(XYZ two)
        {
            double tolerance = 0.0001;
            return Math.Abs(X - two.X) < tolerance &&
                   Math.Abs(Y - two.Y) < tolerance &&
                   Math.Abs(Z - two.Z) < tolerance;
        }
        public double Dist(XYZ to)
        {
            double dX = X - to.X;
            double dY = Y - to.Y;
            double dZ = Z - to.Z;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }
        public string Write()
        {
            return string.Format($"{X:0.####;-0.####;0} {Y:0.####;-0.####;0} {Z:0.####;-0.####;0}");
        }
        public XYZ(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
