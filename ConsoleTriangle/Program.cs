using System;
using System.Collections.Generic;
using Triangles;


namespace ConsoleTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test example." + Environment.NewLine);

            RightTriangle rightTriangle = new RightTriangle(3, 4, 5);
            Console.WriteLine("Right triangle area for RightTriangle(3, 4, 5) = " + rightTriangle.Area + Environment.NewLine);

            Triangle triangle = (Triangle)rightTriangle;
            Console.WriteLine("Triangle area for Triangle(3, 4, 5) = " + triangle.Area + Environment.NewLine);

            Triangle equalTriangle = new Triangle(5, 3, 4);
            Triangle identityTriangle = new Triangle(3, 4, 5);

            Console.WriteLine("Triangle(3, 4, 5).Equals(Triangle(5, 3, 4)) = " + rightTriangle.Equals(equalTriangle).ToString());
            Console.WriteLine("Triangle(3, 4, 5).Equals(Triangle(3, 4, 5)) = " + rightTriangle.Equals(identityTriangle).ToString() + Environment.NewLine);

            Console.WriteLine("RightTriangle(3, 4, 5) == Triangle(5, 3, 4) = " + (rightTriangle == equalTriangle).ToString());
            Console.WriteLine("RightTriangle(3, 4, 5) == Triangle(3, 4, 5) = " + (rightTriangle == identityTriangle).ToString());

            Console.ReadKey();
        }
    }
}
