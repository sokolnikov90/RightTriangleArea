using System;
using Triangles;


namespace ConsoleTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            RightTriangle rightTriangle = new RightTriangle(3, 4, 5);
            Console.WriteLine("Right triangle area = " + rightTriangle.Area);
            
            Triangle triangle = (Triangle)rightTriangle;
            Console.WriteLine("Triangle area = " + triangle.Area);

            Console.ReadKey();
        }
    }
}
