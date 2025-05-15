namespace ExamCsharpMikkel.Processing;
using ExamCsharpMikkel.SensorDataClass;
using Serilog;
public class Method1Processor: IDataProcessor
{
        public void Run(string input)
    {
        Log.Information("Starting Method 1");

        var data = CsvParser.ParseCsv(input);

        // Group by sensor using a dictionary
        var grouped = new Dictionary<string, List<SensorData>>();

        foreach (var reading in data)
        {
            if (!grouped.ContainsKey(reading.SensorName))
            {
                grouped[reading.SensorName] = new List<SensorData>();
            }

            grouped[reading.SensorName].Add(reading);
        }

        // Process each sensor group
        foreach (var sensor in grouped)
        {
            var sensorName = sensor.Key;
            var readings = sensor.Value;

            int count = readings.Count;
            double avgX = readings.Average(r => r.X);
            double avgY = readings.Average(r => r.Y);
            int minX = readings.Min(r => r.X);
            int maxX = readings.Max(r => r.X);
            int minY = readings.Min(r => r.Y);
            int maxY = readings.Max(r => r.Y);
            DateTime first = readings.Min(r => r.Date);
            DateTime last = readings.Max(r => r.Date);

            Log.Information(
                $"Sensor: {sensorName} | Count: {count} | AvgX: {avgX:F2} | AvgY: {avgY:F2} | MinX: {minX}, MaxX: {maxX} | MinY: {minY}, MaxY: {maxY} | From: {first:g} to {last:g}"
            );
        }

        Log.Information("Method 1 Completed");
    }

}