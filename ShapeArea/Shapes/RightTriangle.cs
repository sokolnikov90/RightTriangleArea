namespace ShapeArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Фигура Прямоугольный треугольник
    /// </summary>
    [Serializable]
    public class RightTriangle : Triangle
    {
        /// <summary>
        /// Конструктор фигуры Прямоугольный треугольник
        /// </summary>
        /// <param name="sideA">Сторона 1</param>
        /// <param name="sideB">Сторона 2</param>
        /// <param name="sideC">Сторона 3</param>
        public RightTriangle(double sideA, double sideB, double sideC) : base(sideA, sideB, sideC)
        {
            var cathetus = new List<double> { sideA, sideB, sideC };
            var hypotenuse = cathetus.Max();
            cathetus.Remove(hypotenuse);

            if (Math.Abs(Math.Pow(cathetus[0], 2) + Math.Pow(cathetus[1], 2) - Math.Pow(hypotenuse, 2)) > 0)
            {
                throw new ArgumentException("The square of the hypotenuse isn't equal to the sum of the squares of the other two sides");
            }
        }

        /// <summary>
        /// Площадь
        /// </summary>
        public override double Area
        {
            get
            {
                var cathetus = new List<double> { SideA, SideB, SideC };
                var hypotenuse = cathetus.Max();
                cathetus.Remove(hypotenuse);

                return cathetus[0] * cathetus[1] / 2d;
            }
        }
    }
}