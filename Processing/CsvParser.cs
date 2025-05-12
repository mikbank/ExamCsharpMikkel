namespace ExamCsharpMikkel.Processing;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class SensorData // class to contain sensor data line structure. 
{
    public string SensorName { get; set; } = string.Empty;
    public int X { get; set; }
    public int Y { get; set; }
    public DateTime Date { get; set; }
};


public static class CsvParser
{
    public static List<SensorData> ParseCsv(string filePath)
    {
        var readings = new List<SensorData>(); //ienoumerable list

        foreach (var line in File.ReadLines(filePath))
        {
            if (line.StartsWith("SensorName")) continue; // Skip header

            var parts = line.Split(',');


            readings.Add(new SensorData
            {
                SensorName = parts[0],
                X = int.Parse(parts[1]),
                Y = int.Parse(parts[2]),
                Date = DateTime.ParseExact(parts[3], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
            });
        }

        return readings;
    }
}