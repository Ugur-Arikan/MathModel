namespace MathProg;

internal static class ParamsHelpers
{
    internal static Res CreateDirIfAbsent(string dir)
    {
        if (Directory.Exists(dir))
            return Ok();
        else
            return Ok().Try(() => Directory.CreateDirectory(dir));
    }
}
