using MathProgExamples;


// config
ExampleConfig.Silent = true;
ExampleConfig.TestCplex = true;
ExampleConfig.TestScip = true;


// shortest path
int n = 10;
ShortestPath.Run(n: n, seed: 0, connectivityLevel: 0.8, s: 0, t: n - 1);
