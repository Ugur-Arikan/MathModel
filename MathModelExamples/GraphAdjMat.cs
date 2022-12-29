namespace MathProgExamples;

public record GraphAdjMat(double[][] Weights)
{
    // method
    public int V => Weights.Length;
    public bool ArcExists(int i, int j)
        => Weights[i][j] != double.PositiveInfinity;
    public IEnumerable<int> HeadsFrom(int i)
    {
        return Weights[i]
            .Select((w, j) => (w, j)) // map to (weight, head index) pairs
            .Where(wj => wj.w != double.PositiveInfinity) // filter connected heads
            .Select(wj => wj.j); // map (weight, head index) to only head index
    }

    
    // test
    public static GraphAdjMat Random(int nbVertices, Random rng, double connectivityLevel)
    {
        var weights = new double[nbVertices][];
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = new double[nbVertices];
            for (int j = 0; j < weights[i].Length; j++)
            {
                if (i == j || rng.NextDouble() > connectivityLevel)
                    weights[i][j] = double.PositiveInfinity;
                else
                    weights[i][j] = rng.Next(1, 100);
            }
        }
        return new(weights);
    }
    public void Log()
    {
        Console.WriteLine(nameof(GraphAdjMat));
        Console.WriteLine("Tail => Heads | Weights");
        for (int i = 0; i < V; i++)
        {
            Console.Write(i + " => ");
            foreach (var j in HeadsFrom(i))
                Console.Write(j + " ");
            Console.Write(" | ");
            foreach (var j in HeadsFrom(i))
                Console.Write(Weights[i][j] + " ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
