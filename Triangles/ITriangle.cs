using System.Collections.ObjectModel;

namespace Triangles
{
    public interface ITriangle
    {
        ReadOnlyCollection<double> SideCollection { get; } 
        double Perimeter { get; }
        double Area { get; }
    }
}
