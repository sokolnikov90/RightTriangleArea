using System;

namespace ShapeArea
{
    /// <summary>
    /// Фигура Треугольник
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Конструктор фигуры Треугольник
        /// </summary>
        /// <param name="sideA">Сторона 1</param>
        /// <param name="sideB">Сторона 2</param>
        /// <param name="sideC">Сторона 3</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            CheckShapeSideValue(nameof(sideA), sideA);
            CheckShapeSideValue(nameof(sideB), sideB);
            CheckShapeSideValue(nameof(sideC), sideC);

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("The sum of any 2 sides of a triangle must be greater than the measure of the third side");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Сторона 1
        /// </summary>
        public double SideA { get; }

        /// <summary>
        /// Сторона 2
        /// </summary>
        public double SideB { get; }

        /// <summary>
        /// Сторона 3
        /// </summary>
        public double SideC { get; }

        /// <summary>
        /// Площадь
        /// </summary>
        public override double Area
        {
            get
            {
                var perimeter = SideA + SideB + SideC;
                var semiperimeter = perimeter / 2;
                return Math.Sqrt(semiperimeter * (semiperimeter - SideA) * (semiperimeter - SideB) * (semiperimeter - SideC));
            }
        }
    }
}
