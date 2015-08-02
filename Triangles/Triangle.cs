using System;
using System.Runtime.Serialization;
using System.Linq;

namespace Triangles
{
    public class Triangle
    {
        #region Fields

        protected const double delta = 0.00001;

        protected readonly double[] sides = new double[3];

        protected readonly Lazy<double> perimeter, area;

        #endregion

        #region Properties

        public double[] SideArray
        {
            get
            {
                return sides;
            }
        }

        public double Perimeter
        {
            get
            {
                return perimeter.Value;
            }
        }

        public double Area
        {
            get
            {
                return area.Value;
            }
        }

        # endregion

        #region Methods

        protected double GetPerimeter()
        {
            return sides.Sum();
        }

        protected virtual double GetArea()
        {
            double semiperimeter = Perimeter / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - sides[0]) * (semiperimeter - sides[1]) * (semiperimeter - sides[2]));
        }

        public Triangle()
        {
            perimeter = new Lazy<double>(GetPerimeter);
            area = new Lazy<double>(GetArea);
        }

        public Triangle(double side_a, double side_b, double side_c)
            : this()
        {
            if (side_a <= 0)
                throw new ArgumentOutOfRangeException("side_a", side_a.ToString(), "The value must be greater than 0");

            if (side_b <= 0)
                throw new ArgumentOutOfRangeException("side_b", side_b.ToString(), "The value must be greater than 0");

            if (side_c <= 0)
                throw new ArgumentOutOfRangeException("side_c", side_c.ToString(), "The value must be greater than 0");

            if (side_a > side_b + side_c)
                throw new TriangleException("Triangle inequality failed: side_a can't be greater than side_b + side_c");

            if (side_b > side_a + side_c)
                throw new TriangleException("Triangle inequality failed: side_b can't be greater than side_a + side_c");

            if (side_c > side_a + side_b)
                throw new TriangleException("Triangle inequality failed: side_c can't be greater than side_a + side_b");

            sides[0] = side_a;
            sides[1] = side_b;
            sides[2] = side_c;
        }

        #endregion

        #region Exceptions

        [Serializable]
        public class TriangleException : Exception, ISerializable
        {
            public TriangleException()
                : base() { }

            public TriangleException(string message)
                : base(message) { }

            public TriangleException(string message, Exception inner)
                : base(message, inner) { }

            //It's enough for serialize "TriangleException" because we don't actually add new properties and simply rely on the message.
            protected TriangleException(SerializationInfo info, StreamingContext ctxt)
                : base(info, ctxt) { }
        }

        #endregion

    }
}
