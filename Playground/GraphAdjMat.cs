﻿namespace Playground;

public record GraphAdjMat(double[][] Weights)
{
    // method
    public int V => Weights.Length;
    public bool IsConnected(int i, int j)
        => Weights[i][j] != double.PositiveInfinity;
    public IEnumerable<int> Heads(int i)
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
}
