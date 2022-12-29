namespace MathProg;

public class SolverLpExecution : IDisposable
{
    // data
    readonly string Prog;
    readonly string Args;
    readonly bool Silent;
    bool Disposed;
    Opt<Process> MaybeProcess;


    // ctor
    internal SolverLpExecution(IParams parameters, string args)
    {
        Prog = parameters.PathSolver;
        Args = args;
        Silent = parameters.Silent;

        Disposed = false;
        MaybeProcess = None<Process>();
    }


    // method
    public Res Exe()
    {
        using var process = new Process();
        MaybeProcess = process;
        process.StartInfo.FileName = Prog;
        process.StartInfo.Arguments = Args;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = Silent;
        process.Start();

        try
        {
            process.WaitForExit();
            MaybeProcess = None<Process>();
            return Ok();
        }
        catch (Exception e)
        {
            process.Kill();
            return Err(e.Message + "\n" + e.InnerException?.Message + "\n" + e.StackTrace);
        }
    }
    public void Dispose()
    {
        if (Disposed)
            return;

        if (MaybeProcess.IsSome)
        {
            var pr = MaybeProcess.Unwrap();
            pr.Kill();
            pr.Dispose();
        }


        Disposed = true;
        GC.SuppressFinalize(this);
    }
}
