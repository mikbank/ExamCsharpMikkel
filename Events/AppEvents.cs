using System;

namespace ExamCsharpMikkel.Events;

public static class AppEvents
{
    //  Event when processing is completed (e.g. to show duration)
    public static event Action<TimeSpan>? OnProcessingCompleted;

    //  Event when an outlier is detected (e.g. for future analytics/alerts)
    public static event Action<string>? OnOutlierDetected;

    //  Method to raise the completion event
    public static void RaiseProcessingCompleted(TimeSpan duration)
    {
        OnProcessingCompleted?.Invoke(duration);
    }

    //  Method to raise the outlier event
    public static void RaiseOutlierDetected(string description)
    {
        OnOutlierDetected?.Invoke(description);
    }
}
