namespace Lab1;

public class Vertex
{
    public double X { get; set; }
    public double Y { get; set; }

    public double DistanceTo(Vertex anotherVertex)
    {
        var distance = Math.Sqrt(Math.Pow(X - anotherVertex.X, 2) + Math.Pow(Y - anotherVertex.Y, 2));
        return distance;
    }
}