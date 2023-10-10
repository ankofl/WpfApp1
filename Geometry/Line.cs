using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Geometry
{
    public class Line
    {
        public XYZ A;
        public XYZ B;
        public Line(XYZ _p1, XYZ _p2)
        {
            A = _p1;
            B = _p2;
        }
        public List<XYZ> Inter(Line line)
        {
            XYZ C = line.A;
            XYZ D = line.B;

            List<XYZ> listInter = new List<XYZ>();

            if (Math.Abs(A.Dist(B) - (A.Dist(C) + C.Dist(B))) < double.Epsilon)
            {
                // C принадлежит AB
                listInter.Add(C);
            }
            if (Math.Abs(A.Dist(B) - (A.Dist(D) + D.Dist(B))) < double.Epsilon)
            {
                // D принадлежит AB
                if (D.ContainIn(listInter) == 0)
                    listInter.Add(D);
            }

            if (Math.Abs(C.Dist(D) - (C.Dist(A) + A.Dist(D))) < double.Epsilon)
            {
                // A принадлежит CD
                if (A.ContainIn(listInter) == 0)
                    listInter.Add(A);
            }
            if (Math.Abs(C.Dist(D) - (C.Dist(B) + B.Dist(D))) < double.Epsilon)
            {
                // B принадлежит CD
                if (B.ContainIn(listInter) == 0)
                    listInter.Add(B);
            }

            if (listInter.Count() == 0)
            {
                double
                    xo = A.X,
                    yo = A.Y,
                    zo = A.Z;

                double
                    p = B.X - A.X,
                    q = B.Y - A.Y,
                    r = B.Z - A.Z;

                double
                    x1 = C.X,
                    y1 = C.Y,
                    z1 = C.Z;

                double
                    p1 = D.X - C.X,
                    q1 = D.Y - C.Y,
                    r1 = D.Z - C.Z;

                int i = 0;
                double xN = (q * p1 - q1 * p);
                if (xN == 0)
                {
                    xN = double.Epsilon;
                    i++;
                }


                double yN = (p * q1 - p1 * q);
                if (yN == 0)
                {
                    yN = double.Epsilon;
                    i++;
                }

                double zN = (q * r1 - q1 * r);
                if (zN == 0)
                {
                    zN = double.Epsilon;
                    i++;
                }
                if (i < 3)
                {
                    double X = (xo * q * p1 - x1 * q1 * p - yo * p * p1 + y1 * p * p1) / xN;
                    double Y = (yo * p * q1 - y1 * p1 * q - xo * q * q1 + x1 * q * q1) / yN;
                    double Z = (zo * q * r1 - z1 * q1 * r - yo * r * r1 + y1 * r * r1) / zN;
                    if (!double.IsNaN(X) && !double.IsNaN(Y) && !double.IsNaN(Z) &&
                        !double.IsInfinity(X) && !double.IsInfinity(Y) && !double.IsInfinity(Z))
                        listInter.Add(new XYZ(X, Y, Z));
                }
            }
            return listInter;
        }
    }
}
