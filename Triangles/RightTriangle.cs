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
                return sortedSideArray[0];
            }
        }

        public double Cathetus_B
        {
            get
            {
                return sortedSideArray[1];
            }
        }

        public double Hypotenuse_C
        {
            get
            {
                return sortedSideArray[2];
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
            if (Math.Abs(Math.Pow(sortedSideArray[0], 2) + Math.Pow(sortedSideArray[1], 2) - Math.Pow(sortedSideArray[2], 2)) > delta)
                throw new TriangleException(string.Format("Triangle isn't right-angled: {0}^2 + {1}^2 != {2}^2", sortedSideArray[0], sortedSideArray[1], sortedSideArray[2]));
        }

        #endregion
    }
}
