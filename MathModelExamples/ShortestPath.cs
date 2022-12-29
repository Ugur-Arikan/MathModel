using MathProg;
using System.Diagnostics;
using static MathProg.Extensions;

namespace MathProgExamples;

public static class ShortestPath
{
    // graph variants
    static void ExAdjList(GraphAdjList graph, int s, int t, bool silent)
    {
        // sets
        Set i = new("i", graph.V);
        Set hi = i.St("j", i => graph.HeadsFrom(i));    // heads of arcs outgoing from i
        Set ti = i.St("k", i => graph.TailsInto(i));    // tails of arcs incoming to i


        // pars
        Par1 b = new("b", i => i == s ? 1 : (i == t ? -1 : 0)); // 1 if source; -1 if sink; 0 o/w
        Par2 w = new("w", (i, j) => graph.Weights[i][j]);


        // vars
        Var2 x = Var2.Nonneg("x", (i, hi));


        // constraints
        Constr flowBal = i | Sum(hi | x[i, hi]) - Sum(ti | x[ti, i]) == b[i];


        // obj
        ObjFun dist = ObjDir.Min | Sum((i, hi) | w[i, hi] * x[i, hi]);


        // model
        var modelSp = Model.New(obj: dist, constrs: ("flowBal", flowBal)).Unwrap();
        //modelSp += x[0, 3] == 1.0;
        if (!silent)
            Console.WriteLine("\nModel\n" + modelSp);

        // export lp
        string path = "spp.lp";
        modelSp.CreateLpFile(path);
        if (!silent)
            Console.WriteLine("\nModel - LP\n" + File.ReadAllText(path));


        // solve by differnet solvers
        if (ExampleConfig.TestCplex)
        {
            var solver = SolverLp.Cplex(new ParamsCplex()
            {
                Silent = ExampleConfig.Silent,
            });
            using var soln = solver.Solve(modelSp, x);
            CheckSoln(soln, x, graph);
        }
        if (ExampleConfig.TestScip)
        {
            var solver = SolverLp.Scip(new ParamsScip()
            {
                Silent = ExampleConfig.Silent,
            });
            using var soln = solver.Solve(modelSp, x);
            CheckSoln(soln, x, graph);
        }
    }
    static void ExAdjMatrix(GraphAdjMat graph, int s, int t, bool silent)
    {
        // sets
        Set i = new("i", graph.V);
        Set j = new("j", graph.V);


        // pars
        Par1 b = new("b", i => i == s ? 1 : (i == t ? -1 : 0)); // 1 if source; -1 if sink; 0 o/w
        Par2 w = new("w", (i, j) => graph.Weights[i][j]);


        // vars
        Var2 x = Var2.Nonneg("x", (i, j));


        // constraints
        Constr flowBal = i | Sum(j | x[i, j]) - Sum(j | x[j, i]) == b[i];


        // obj
        ObjFun dist = ObjDir.Min | Sum((i, j) | w[i, j] * x[i, j]);


        // model
        var modelSp = Model.New(obj: dist, constrs: ("flowBal", flowBal)).Unwrap();
        if (!silent)
            Console.WriteLine("\nModel\n" + modelSp);


        // export lp
        string path = "spp.lp";
        var buildErrors = modelSp.CreateLpFile(path);
        if (!silent)
            Console.WriteLine("\nModel\n" + File.ReadAllText(path));


        // solve by differnet solvers
        if (ExampleConfig.TestCplex)
        {
            var solver = SolverLp.Cplex(new ParamsCplex()
            {
                Silent = ExampleConfig.Silent,
                TimeLimitSec = 4.2,
                Gap = 0,
                AbsGap = 0
            });
            using var soln = solver.Solve(modelSp, x);
            CheckSoln(soln, x, graph);
        }
        if (ExampleConfig.TestScip)
        {
            var solver = SolverLp.Scip(new ParamsScip()
            {
                Silent = ExampleConfig.Silent,
                PathTempDir = "tmp",
                TimeLimitSec = 4.2,
                Gap = 0,
                AbsGap = 0
            });
            var soln = solver.Solve(modelSp, x);
            CheckSoln(soln, x, graph);
        }
    }

    
    // soln
    static void CheckSoln(SolnMp soln, Var2 x, GraphAdjMat graph)
    {
        // summary
        Console.WriteLine($"\n-- Example: {graph.GetType().Name} & {soln.GetType().Name.Substring(nameof(SolnMp).Length)} --\n{soln.Summary()}");
        if (!soln.IsFeasible)
            return;


        // vals dict
        var valsX = soln.GetVals(x);


        // value by key
        if (valsX.ContainsKey((0, 6)))
        {
            double val06 = valsX[0, 6];
        }


        // filter vals dict
        var nonzeroIndices = valsX.FilterIndices(x => x > 0.0).ToArray();
        var nonzeroIndicesAndValues = valsX.Filter(x => x > 0.0).ToList();
        Console.WriteLine("shortest path edges: {0}", string.Join(" - ", nonzeroIndices));


        // vals into jagged array matching Heads; 1-to-1 mapping since a complete graph is used
        var arrX = valsX.IntoArr((i, j) => (i, j));


        // validate mapping
        for (int i = 0; i < arrX.Length; i++)
        {
            for (int hi = 0; hi < arrX[i].Length; hi++)
            {
                double valFromArr = arrX[i][hi];

                int j = hi;
                if (valsX.ContainsKey((i, j)))
                {
                    double valFromDict = valsX[i, j];
                    Debug.Assert(valFromDict == valFromArr);
                }
                else
                    Debug.Assert(valFromArr == 0.0);
            }
        }
    }
    static void CheckSoln(SolnMp soln, Var2 x, GraphAdjList graph)
    {
        // summary
        Console.WriteLine($"\n-- Example: {graph.GetType().Name} & {soln.GetType().Name.Substring(nameof(SolnMp).Length)} --\n{soln.Summary()}");
        if (!soln.IsFeasible)
            return;


        // vals dict
        var valsX = soln.GetVals(x);


        // value by key
        if (valsX.ContainsKey((0, 6)))
        {
            double val06 = valsX[0, 6];
        }


        // filter vals dict
        var nonzeroIndices = valsX.FilterIndices(x => x > 0.0).ToArray();
        var nonzeroIndicesAndValues = valsX.Filter(x => x > 0.0).ToList();
        Console.WriteLine("shortest path edges: {0}", string.Join(" - ", nonzeroIndices));

        // map vals into jagged array matching Heads
        var arrX = valsX.IntoArr((i, j) => (i, graph.Heads[i][j]));


        // validate mapping
        for (int i = 0; i < arrX.Length; i++)
        {
            for (int hi = 0; hi < arrX[i].Length; hi++)
            {
                double valFromArr = arrX[i][hi];

                int j = graph.Heads[i][hi];
                if (valsX.ContainsKey((i, j)))
                {
                    double valFromDict = valsX[i, j];
                    Debug.Assert(valFromDict == valFromArr);
                }
                else
                    Debug.Assert(valFromArr == 0.0);
            }
        }
    }


    // validation
    static void SanityChecks(int n, int seed, double connectivityLevel, int s, int t)
    {
        Debug.Assert(seed >= 0);
        Debug.Assert(n > 0);
        Debug.Assert(s >= 0 && s < n);
        Debug.Assert(t >= 0 && t < n);
        Debug.Assert(connectivityLevel >= 0 && connectivityLevel <= 1.0);
    }


    // run
    internal static void Run(int n, int seed, double connectivityLevel, int s, int t)
    {
        bool silent = ExampleConfig.Silent;

        SanityChecks(n, seed, connectivityLevel, s, t);

        // data
        var graphList = GraphAdjList.Random(n, new Random(seed), connectivityLevel);
        var graphMat = graphList.IntoAdjMat();
        if (!silent)
            graphList.Log();

        ExAdjList(graphList, s, t, silent);
        ExAdjMatrix(graphMat, s, t, silent);
    }
}
