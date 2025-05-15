namespace ExamCsharpMikkel.Processing;
using System.Threading;
using Serilog;
public class Method3Processor: IDataProcessor
{
        public void Run(string input)
    {
        Log.Information("Starting Method 3");
        Log.Information("Filepath received: {filePath}", input);
        Thread.Sleep(3000);
        Log.Information($"Selected file path: {input}");
    }
}
