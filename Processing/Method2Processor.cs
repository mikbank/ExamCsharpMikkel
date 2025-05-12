namespace ExamCsharpMikkel.Processing;
using System.Threading;
using Serilog;
public static class Method2Processor
{
    public static void Run(string message)
    {
        Log.Information("Starting Method 2");
        Log.Information("Message received: {Message}", message);
        Thread.Sleep(2000);
        Log.Information(message);
    }
}
