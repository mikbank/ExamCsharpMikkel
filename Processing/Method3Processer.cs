namespace ExamCsharpMikkel.Processing;

using ExamCsharpMikkel.SensorDataClass;
using Serilog;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

public class Method3Processor : IDataProcessor
{
    public void Run(List<SensorData> data)
    {
        Log.Information("Starting Method 3 (Multithreaded)");


        var groupedSensors = data // simple query to group data by sensor name
            .GroupBy(currentReading => currentReading.SensorName)
            .ToList(); //add groups to list, so threads can be spun up 

        Parallel.ForEach(groupedSensors, group =>
        {
            
            string sensorName = group.Key;
            Log.Information($"Thread {Environment.CurrentManagedThreadId} - Starting processing for {sensorName}");
            int count = group.Count();
            double avgX = group.Average(currentReading => currentReading.X);
            double avgY = group.Average(currentReading => currentReading.Y);
            int minX = group.Min(currentReading => currentReading.X);
            int maxX = group.Max(currentReading => currentReading.X);
            int minY = group.Min(currentReading => currentReading.Y);
            int maxY = group.Max(currentReading => currentReading.Y);
            DateTime first = group.Min(currentReading => currentReading.Date);
            DateTime last = group.Max(currentReading => currentReading.Date);

            Log.Information(
                $"Sensor: {sensorName} | Count: {count} | AvgX: {avgX:F2} | AvgY: {avgY:F2} | MinX: {minX}, MaxX: {maxX} | MinY: {minY}, MaxY: {maxY} | From: {first:g} to {last:g}"
            );
        });

        Log.Information("Method 3 Completed");
    }
}
