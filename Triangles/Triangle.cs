using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Triangles
{
    [Serializable]
    public class Triangle : ITriangle
    {
        public ReadOnlyCollection<double> SideCollection
        {
            get
            {
                return Array.AsReadOnly(sideArray);
            }
        }

        public virtual double Perimeter
        {
            get
            {
                return sideArray.Sum();
            }
        }

        public virtual double Area
        {
            get
            {
                double semiperimeter = Perimeter / 2;
                return Math.Sqrt(semiperimeter * (semiperimeter - sideArray[0]) * (semiperimeter - sideArray[1]) * (semiperimeter - sideArray[2]));
            }
        }

        protected const double delta = 0.00001;

        protected readonly double[] sideArray;

        public Triangle(double side_a, double side_b, double side_c)
        {
            Contract.Requires<ArgumentOutOfRangeException>(side_a > 0, "side_a must be greater than 0");
            Contract.Requires<ArgumentOutOfRangeException>(side_b > 0, "side_b must be greater than 0");
            Contract.Requires<ArgumentOutOfRangeException>(side_c > 0, "side_c must be greater than 0");

            Contract.Requires<TriangleException>(side_a + side_b > side_c, "The sum side_a and side_b must be greater than side_c");
            Contract.Requires<TriangleException>(side_a + side_c > side_b, "The sum side_a and side_c must be greater than side_b");
            Contract.Requires<TriangleException>(side_b + side_c > side_a, "The sum side_b and side_c must be greater than side_a");

            Contract.Ensures(sideArray != null && sideArray.Length == 3);

            this.sideArray = new [] {side_a, side_b, side_c};
        }

        /// <summary>
        /// Return TRUE if the triangles are identity.
        /// </summary>
        /// <param name="obj">Triangle for equals</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            Triangle triangle = obj as Triangle;

            return Equals(triangle);
        }

        /// <summary>
        /// Return TRUE if the triangles are identity.
        /// </summary>
        /// <param name="triangle">Triangle for equals</param>
        /// <returns>Boolean</returns>
        public bool Equals(Triangle triangle)
        {
            if (ReferenceEquals(this, triangle))
                return true;

            if (triangle == null)
            {
                return false;
            }
            
            for (int i = 0; i <= 2; i++)
            {
                if (Math.Abs(sideArray[i] - triangle.sideArray[i]) > delta)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Return TRUE if the triaangles are congruent.
        /// </summary>
        /// <param name="triangle1">First triangle</param>
        /// <param name="triangle2">Second triangle</param>
        /// <returns>Boolean</returns>
        public static bool operator ==(Triangle triangle1, Triangle triangle2)
        {
            if (ReferenceEquals(triangle1, triangle2))
                return true;

            if ((ReferenceEquals(triangle1, null)) || (ReferenceEquals(triangle2, null)))
                return false;

            double[] triangle1SortedSideArray = triangle1.sideArray;
            Array.Sort(triangle1SortedSideArray);

            double[] triangle2SortedSideArray = triangle2.sideArray;
            Array.Sort(triangle2SortedSideArray);

            for (int i = 0; i <= 2; i++)
            {
                if (Math.Abs(triangle1SortedSideArray[i] - triangle2SortedSideArray[i]) > delta)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Return TRUE if the triangles are not congruent.
        /// </summary>
        /// <param name="triangle1">First triangle</param>
        /// <param name="triangle2">Second triangle</param>
        /// <returns>Boolean</returns>
        public static bool operator !=(Triangle triangle1, Triangle triangle2)
        {
            return !(triangle1 == triangle2);
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

        public override string ToString()
        {
            return String.Format("Triangle({0:0.00000},{1:0.00000},{2:0.00000})", SideCollection[0], SideCollection[1], SideCollection[2]);
        }
    }
}
