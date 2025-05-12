namespace ExamCsharpMikkel.Processing;
using System.Threading;
using Serilog;
public static class Method3Processor
{
    public static void Run(string filePath)
    {
        Log.Information("Starting Method 3");
        Log.Information("Filepath received: {filePath}", filePath);
        Thread.Sleep(3000);
        Log.Information($"Selected file path: {filePath}");
    }
}
