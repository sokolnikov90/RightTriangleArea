using System;
using System.Runtime.Serialization;
using System.Linq;

namespace Triangles
{
    public class Triangle
    {
        #region Fields

        protected const double delta = 0.00001;

        protected readonly double[] sideArray = new double[3];

        //For fast Equals(...)
        protected readonly double[] sortedSideArray = new double[3]; 

        protected readonly Lazy<double> perimeter, area;

        #endregion

        #region Properties

        public double[] SideArray
        {
            get
            {
                return sideArray;
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
            return sideArray.Sum();
        }

        protected virtual double GetArea()
        {
            double semiperimeter = Perimeter / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - sideArray[0]) * (semiperimeter - sideArray[1]) * (semiperimeter - sideArray[2]));
        }

        /// <summary>
        /// Return TRUE if the triangles are not congruent.
        /// </summary>
        /// <param name="obj">Triangle for equals</param>
        /// <returns>Boolean</returns>
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Triangle triangle = obj as Triangle;

            return Equals(triangle);
        }

        /// <summary>
        /// Return TRUE if the triangles are not congruent.
        /// </summary>
        /// <param name="triangle">Triangle for equals</param>
        /// <returns>Boolean</returns>
        public bool Equals(Triangle triangle)
        {
            if ((this == null) || (triangle == null))
            {
                return false;
            }

            for (int i = 0; i <= 2; i++)
            {
                if (sortedSideArray[i] != triangle.sortedSideArray[i])
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Return TRUE if the triaangles are identity.
        /// </summary>
        /// <param name="triangle1">First triangle</param>
        /// <param name="triangle2">Second triangle</param>
        /// <returns>Boolean</returns>
        public static bool operator ==(Triangle triangle1, Triangle triangle2)
        {
            if (object.ReferenceEquals(triangle1, triangle2))
                return true;

            if ((object.ReferenceEquals(triangle1, null)) || (object.ReferenceEquals(triangle2, null)))
                return false;

            if ((triangle1.sideArray[0] == triangle2.sideArray[0]) && (triangle1.sideArray[1] == triangle2.sideArray[1]) && (triangle1.sideArray[2] == triangle2.sideArray[2]))
                return true;

            return false;
        }

        /// <summary>
        /// Return TRUE if the triangles are not identity.
        /// </summary>
        /// <param name="triangle1">First triangle</param>
        /// <param name="triangle2">Second triangle</param>
        /// <returns>Boolean</returns>
        public static bool operator !=(Triangle triangle1, Triangle triangle2)
        {
            if (object.ReferenceEquals(triangle1, triangle2))
                return false;

            if ((object.ReferenceEquals(triangle1, null)) || (object.ReferenceEquals(triangle2, null)))
                return true;

            if ((triangle1.sideArray[0] != triangle2.sideArray[0]) || (triangle1.sideArray[1] != triangle2.sideArray[1]) || (triangle1.sideArray[2] != triangle2.sideArray[2]))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + sideArray[0].GetHashCode();
                hash = hash * 23 + sideArray[1].GetHashCode();
                hash = hash * 23 + sideArray[2].GetHashCode();
                return hash;
            }
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

            sideArray[0] = side_a;
            sideArray[1] = side_b;
            sideArray[2] = side_c;

            Array.Copy(sideArray, sortedSideArray, 3);
            Array.Sort(sortedSideArray);
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
