using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;

namespace Triangles
{
    [Serializable]
    public class RightTriangle : Triangle, IRightTriangle
    {
        public double Cathetus_A
        {
            get
            {
                return GetSide(0);
            }
        }

        public double Cathetus_B
        {
            get
            {
                return GetSide(1);
            }
        }

        public double Hypotenuse_C
        {
            get
            {
                return GetSide(2);
            }
        }

        public override double Area
        {
            get
            {
                return Cathetus_A * Cathetus_B / 2;
            }
        }

        [NonSerialized]
        protected byte[] sortedSideIndex;

        public RightTriangle(double side_a, double side_b, double side_c)
            : base(side_a, side_b, side_c)
        {
            OnDeserialized();

            if (Math.Abs(Math.Pow(Cathetus_A, 2) + Math.Pow(Cathetus_B, 2) - Math.Pow(Hypotenuse_C, 2)) > delta)
                throw new TriangleException("The square of the hypotenuse must be equal to the sum of the squares of the other two sides");
        }

        [OnDeserialized]
        protected void OnDeserialized()
        {
            Contract.Ensures((sortedSideIndex != null) && (sortedSideIndex.Length == 3));

            sortedSideIndex = sideArray
                .Select((side, index) => new { side, index })
                .ToDictionary(x => x.index, x => x.side)
                .OrderBy(side => side.Value)
                .Select(side => Convert.ToByte(side.Key))
                .ToArray();
        }

        protected double GetSide(byte sideId)
        {
            return sideArray[sortedSideIndex[sideId]];
        }

        /// <summary>
        /// Return TRUE if the right triaangles are congruent.
        /// </summary>
        /// <param name="rightTriangle1">First right triangle</param>
        /// <param name="rightTriangle2">Second right triangle</param>
        /// <returns>Boolean</returns>
        public static bool operator ==(RightTriangle rightTriangle1, RightTriangle rightTriangle2)
        {
            if (ReferenceEquals(rightTriangle1, rightTriangle2))
                return true;

            if ((ReferenceEquals(rightTriangle1, null)) || (ReferenceEquals(rightTriangle2, null)))
                return false;

            // If the legs of one right triangle are congruent to the legs of another right triangle,
            // then the two right triangles are congruent
            if ((Math.Abs(rightTriangle1.Cathetus_A - rightTriangle2.Cathetus_A) > delta) ||
                (Math.Abs(rightTriangle1.Cathetus_B - rightTriangle2.Cathetus_B) > delta))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Return TRUE if the triangles are not congruent.
        /// </summary>
        /// <param name="rightTriangle1">First right triangle</param>
        /// <param name="rightTriangle2">Second right triangle</param>
        /// <returns>Boolean</returns>
        public static bool operator !=(RightTriangle rightTriangle1, RightTriangle rightTriangle2)
        {
            return !(rightTriangle1 == rightTriangle2);
        }
    }
}
