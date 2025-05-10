namespace ExamCsharpMikkel.Processing;
using System.Threading;
using System.Diagnostics;
public static class Method2Processor
{
    public static void Run(string message)
    {
        Thread.Sleep(2000);
        Trace.WriteLine(message);
    }
}
