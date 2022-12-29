namespace MathProgExamples;

public record GraphAdjList(int[][] Heads, Dictionary<int, double>[] Weights)
{
    // method
    public int V => Weights.Length;
    public bool ArcExists(int i, int j)
        => Heads[i].Contains(j);
    public IEnumerable<int> HeadsFrom(int i)
        => Heads[i];
    public IEnumerable<int> TailsInto(int j)
    {
        for (int i = 0; i < Heads.Length; i++)
            if (Heads[i].Contains(j))
                yield return i;
    }
    public int OutDegree(int i)
        => Heads[i].Length;

    
    // test
    public static GraphAdjList Random(int nbVertices, Random rng, double connectivityLevel)
    {
        var heads = new int[nbVertices][];
        var weights = new Dictionary<int, double>[nbVertices];
        for (int i = 0; i < weights.Length; i++)
        {
            var weightsI = new Dictionary<int, double>();
            var headsI = new List<int>();
            for (int j = 0; j < nbVertices; j++)
            {
                if (i != j && rng.NextDouble() <= connectivityLevel)
                {
                    headsI.Add(j);
                    weightsI[j] = rng.Next(1, 100);
                }
            }
            heads[i] = headsI.ToArray();
            weights[i] = weightsI;
        }
        return new(heads, weights);
    }
    public void Log()
    {
        Console.WriteLine(nameof(GraphAdjList));
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
    public GraphAdjMat IntoAdjMat()
    {
        var weights = new double[V][];
        for (int i = 0; i < weights.Length; i++)
        {
            var dictWeights = Weights[i];
            weights[i] = new double[V];
            for (int j = 0; j < weights[i].Length; j++)
            {
                if (!dictWeights.TryGetValue(j, out weights[i][j]))
                    weights[i][j] = double.PositiveInfinity;
            }
        }
        return new(weights);
    }
}
