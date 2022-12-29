namespace MathProg.Helpers;

internal static class Io
{
    internal static void DeleteFileIfExists(this string path)
    {
        if (File.Exists(path))
            File.Delete(path);
    }
}
