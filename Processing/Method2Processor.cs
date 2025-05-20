namespace ExamCsharpMikkel.Processing;

using ExamCsharpMikkel.SensorDataClass;
using Serilog;
using System.Linq;

public class Method2Processor : IDataProcessor
{
    public void Run(List<SensorData> data)
    {
        Log.Information("Starting Method 2");

        //var data = CsvParser.ParseCsv(input);

        
        var result = from reading in data //LINQ to extract, group and calculate data
                     group reading by reading.SensorName into sensorGroup
                     select new
                     {
                         SensorName = sensorGroup.Key, // OBS using linq and lambda to fetch values
                         Count = sensorGroup.Count(),
                         AvgX = sensorGroup.Average(currentReading => currentReading.X),
                         AvgY = sensorGroup.Average(currentReading => currentReading.Y),
                         MinX = sensorGroup.Min(currentReading => currentReading.X),
                         MaxX = sensorGroup.Max(currentReading => currentReading.X),
                         MinY = sensorGroup.Min(currentReading => currentReading.Y),
                         MaxY = sensorGroup.Max(currentReading => currentReading.Y),
                         First = sensorGroup.Min(currentReading => currentReading.Date),
                         Last = sensorGroup.Max(currentReading => currentReading.Date)
                     };

        // Log output
        foreach (var sensor in result)
        {
            Log.Information(
                $"Sensor: {sensor.SensorName} | Count: {sensor.Count} | AvgX: {sensor.AvgX:F2} | AvgY: {sensor.AvgY:F2} | MinX: {sensor.MinX}, MaxX: {sensor.MaxX} | MinY: {sensor.MinY}, MaxY: {sensor.MaxY} | From: {sensor.First:g} to {sensor.Last:g}"
            );
        }

        Log.Information("Method 2 Completed");
    }
}
