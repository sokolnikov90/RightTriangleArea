namespace Triangles
{
    public interface IRightTriangle : ITriangle
    {
        double Cathetus_A { get; }
        double Cathetus_B { get; }
        double Hypotenuse_C { get; }
    }
}
