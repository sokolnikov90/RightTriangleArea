using System;

namespace Triangles
{
    public class RightTriangle : Triangle
    {
        #region Fields

        public double Cathetus_A
        {
            get
            {
                return sides[0];
            }
        }

        public double Cathetus_B
        {
            get
            {
                return sides[1];
            }
        }

        public double Hypotenuse_C
        {
            get
            {
                return sides[2];
            }
        }

        #endregion

        #region Methods

        protected override double GetArea()
        {
            return Cathetus_A * Cathetus_B / 2;
        }

        public RightTriangle(double side_a, double side_b, double side_c)
            : base(side_a, side_b, side_c)
        {
            Array.Sort(sides);
            
            if (Math.Abs(Math.Pow(side_a, 2) + Math.Pow(side_b, 2) - Math.Pow(side_c, 2)) > delta)
                throw new TriangleException(string.Format("Triangle isn't right-angled: {0}^2 + {1}^2 != {2}^2", sides[0], sides[1], sides[2]));
        }

        #endregion
    }
}
