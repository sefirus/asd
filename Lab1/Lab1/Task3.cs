namespace Lab1;

public static class Task3
{
    public static List<Vertex> GetVertices(string line)
    {
        var result = new List<Vertex>();
        var pairs = line.Split(',', StringSplitOptions.TrimEntries);
        foreach (var pair in pairs)
        {
            var values = pair.Replace(",", "").Split(' ', StringSplitOptions.TrimEntries);
            double.TryParse(values[0], out var x);
            double.TryParse(values[1], out var y);
            var vertex = new Vertex()
            {
                X = x,
                Y = y
            };
            result.Add(vertex);
        }

        return result;
    }
    
    private static void InitiateTable(List<List<(double, int)>> array, int width, int height)
    {
        array.Clear();
        for (int i = 0; i < height; i++)
        {
            var l = new List<(double, int)>();
            for (int j = 0; j < width; j++)
            {
                 if(i > j)
                     l.Add((Double.MinValue, -1));
                 else
                    l.Add((0, -1));
            }            
            array.Add(l);
        }
    }
    
    public static void Run(Func<Vertex, Vertex, Vertex, double> worthFunc)
    {
        Console.WriteLine("Input vertices coords: x1 y1, x2 y2, x3 y3...");
        var vertices = GetVertices(Console.ReadLine()!);
        var worthMatrix = new List<List<(double Value, int K)>>();
        InitiateTable(worthMatrix, vertices.Count, vertices.Count);
        for (int i = 0; i < vertices.Count; i++)
        {
            for (int j = i + 1; j < vertices.Count; j++)
            {
                var minWorth = (double.MaxValue, -1);
                for (int k = i + 1; k < j; k++)
                {
                    var funcResult = worthFunc(vertices[i], vertices[j], vertices[k]);
                    var currentWorth = worthMatrix[i][k].Value
                                       + worthMatrix[k + 1][j].Value 
                                       + funcResult;
                    if (currentWorth < minWorth.MaxValue && currentWorth != 0)
                    {
                        minWorth.MaxValue = currentWorth;
                        minWorth.Item2 = k;
                    }
                }
        
                worthMatrix[i][j] = Math.Abs(minWorth.MaxValue - double.MaxValue) < 0.0003 ? (0, -1) : minWorth; 
            }
        }
        
        Console.WriteLine("Optimal triangles:");
        int outI = 0;
        int outJ = vertices.Count - 1;
        while (outJ - outI > 1)
        {
            var worth = worthMatrix[outI][outJ];
            Console.WriteLine($"{vertices[outI].X} {vertices[outI].Y}\t" +
                              $"{vertices[outJ].X} {vertices[outJ].Y}\t" +
                              $"{vertices[worth.K].X} {vertices[worth.K].Y}\t{worth.Value}");
            outI = worth.K;
        }
    }

    public static double GetAreaWorth(Vertex v1, Vertex v2, Vertex v3)
    {
        double a = v1.DistanceTo(v2);
        double b = v2.DistanceTo(v3);
        double c = v3.DistanceTo(v1);
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p-a) * (p-b) * (p-c));
    }

    public static double GetDiagonalLengthWorth(Vertex v1, Vertex v2, Vertex v3)
    {
        double a = v1.DistanceTo(v3);
        double b = v2.DistanceTo(v3);
        return a + b;
    }
}