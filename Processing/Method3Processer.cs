namespace ExamCsharpMikkel.Processing;
using System.Threading;
using System.Diagnostics;
public static class Method3Processor
{
    public static void Run(string filePath)
    {
        Thread.Sleep(3000);
        Trace.WriteLine($"Selected file path: {filePath}");
    }
}
