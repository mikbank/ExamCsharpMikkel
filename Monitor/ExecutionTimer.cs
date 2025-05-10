namespace ExamCsharpMikkel.Monitor;

using System;
using System.Diagnostics;
using ExamCsharpMikkel.Events;

public static class ExecutionTimer

{
    public static void ChronoGraph(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        action();

        stopwatch.Stop();
        AppEvents.RaiseProcessingCompleted(stopwatch.Elapsed);

    }
}