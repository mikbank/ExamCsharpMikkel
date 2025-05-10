namespace ExamCsharpMikkel.Processing;
using System.Threading;
using System.Diagnostics;
public static class Method1Processor
{
    public static void Run(string message)
    {
        Thread.Sleep(1000);
        Trace.WriteLine(message);

        for (int index = 1; index <=20; index++){

            Trace.WriteLine("Count" + index);
            


        };
    }
}
