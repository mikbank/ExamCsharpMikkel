namespace ExamCsharpMikkel.Processing;
using System.Threading;
using Serilog;
public class Method2Processor: IDataProcessor
{
        public void Run(string input)
    {
        Log.Information("Starting Method 2");
        Log.Information("Message received: {Message}", input);
        Thread.Sleep(2000);
        Log.Information(input);
    }
}
