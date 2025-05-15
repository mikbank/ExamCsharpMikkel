namespace ExamCsharpMikkel.Processing;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
//using Microsoft.VisualBasic.Logging;
using Serilog;
using ExamCsharpMikkel.SensorDataClass;




public static class CsvParser
{
    public static List<SensorData> ParseCsv(string filePath)
    {
        var readings = new List<SensorData>(); //ienoumerable list
        var invalidLines = new List<int>();
        int lineIndex = 0;

        foreach (var line in File.ReadLines(filePath)) // iterates through csv data andd assigns to list of SensorData objects
        {
            lineIndex++;
            if (line.StartsWith("SensorName")) continue; // Skip header

            var parts = line.Split(',');

            try
                {
                    var reading = new SensorData
                    {
                        SensorName = parts[0],
                        X = int.Parse(parts[1]),
                        Y = int.Parse(parts[2]),
                        Date = DateTime.ParseExact(parts[3], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                    };

                    if (reading.IsValid)
                    {
                        readings.Add(reading);
                    }
                    else
                    {
                        Log.Warning($"Validation failed for line {lineIndex}: Outlier corrected. Skipping row.");
                        invalidLines.Add(lineIndex);
                    }
                }
                catch
                {
                    Log.Warning($"Could not parse data on line index {lineIndex}. LineInfo: {line}");
                    invalidLines.Add(lineIndex);
                } 

        }

        return readings;
    }
}