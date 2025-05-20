namespace ExamCsharpMikkel.Processing;
using ExamCsharpMikkel.SensorDataClass;
using Serilog;
public class Method1Processor: IDataProcessor
{
        public void Run(List<SensorData> data)
    {
        Log.Information("Starting Method 1");

       // var data = CsvParser.ParseCsv(input);


        //slooooow function to demonstrate differences between processes   
        // Step 1: Get unique sensor names oldschool
        List<string> sensorNames = new List<string>();
        foreach (var reading in data)
        {
            if (!sensorNames.Contains(reading.SensorName))
            {
                sensorNames.Add(reading.SensorName);
            }
        }

        // Step 2: For each sensor, loop through all data to compute stats
        foreach (var sensorName in sensorNames)
        {
            int count = 0; //resets values for next iteration
            int sumX = 0;
            int sumY = 0;
            int minX = int.MaxValue;
            int maxX = int.MinValue;
            int minY = int.MaxValue;
            int maxY = int.MinValue;
            DateTime? first = null;
            DateTime? last = null;

            foreach (var reading in data)
            {
                if (reading.SensorName == sensorName) // very simple filtering to make sure current reading is the sensor we want to look at
                {
                    count++;
                    sumX += reading.X;
                    sumY += reading.Y;
                    if (reading.X < minX) minX = reading.X;
                    if (reading.X > maxX) maxX = reading.X;
                    if (reading.Y < minY) minY = reading.Y;
                    if (reading.Y > maxY) maxY = reading.Y;

                    if (first == null || reading.Date < first) first = reading.Date;
                    if (last == null || reading.Date > last) last = reading.Date;
                }
            }

            double avgX = count > 0 ? (double)sumX / count : 0; // average calculated from sum
            double avgY = count > 0 ? (double)sumY / count : 0;

            Log.Information(
                $"Sensor: {sensorName} | Count: {count} | AvgX: {avgX:F2} | AvgY: {avgY:F2} | MinX: {minX}, MaxX: {maxX} | MinY: {minY}, MaxY: {maxY} | From: {first:g} to {last:g}"
            );
        }

        Log.Information("Method 1 Completed");
    }

}