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
                        Date = DateTime.ParseExact(parts[3], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                    };
                    readings.Add(reading);
                   /* if (reading.IsValid) // if line passes validation it is added to list of readings
                    {
                        readings.Add(reading);
                    }
                    else
                    {
                        Log.Warning($"Validation failed for line {lineIndex}: Outlier detected. Skipping row."); //using set validation to detect outliers - if outlier it is not added to results
                        invalidLines.Add(lineIndex);
                    }*/
                }
                catch
                {
                    Log.Warning($"Could not parse data on line index {lineIndex}. LineInfo: {line}"); // if data cannot be parsed an error is thrown, which is catched here
                    invalidLines.Add(lineIndex);
                } 

        }

        return readings;
    }
}