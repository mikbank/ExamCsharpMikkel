namespace ExamCsharpMikkel.Processing;
using System.Threading;
using Serilog;
public static class Method1Processor
{
    public static void Run(string message)
    {

        Log.Information("Starting Method 1");
        Log.Information("Message received: {Message}", message);
        Thread.Sleep(1000);
        Log.Information(message);

        for (int index = 1; index <=20; index++){

            Log.Debug("Count" + index);
            

        };

        Log.Information("Method 1 Completed");
    }
}
