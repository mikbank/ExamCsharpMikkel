using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ExamCsharpMikkel.TestData;


//Simple function - only meant to quickly create testdata for running the project

public static class TestDataGenerator

{
    private static readonly string[] Sensors = {"Sensor1", "Sensor2", "Sensor3", "Sensor4","Sensor5"};
    private static readonly Random random = new Random();
    
    public static void CsvCreator(string filePath , int Entries = 10000)
    {
        var csv = new StringBuilder();
        csv.AppendLine("SensorName,X,Y,Date"); //header for csv. 

        foreach (var sensor in Sensors)
        {
                for (int i = 1; i <= Entries; i++)
                {
                    int x = (i % 500 == 0) ? 999 : random.Next(1,51) ; // Creates testdata at random - OBS conditional operator - 
                    int y = (i % 500 == 0) ? 999 : random.Next(1,51);
                    string DateStamp = DateTime.Now.AddHours(-i).ToString("yyyy-MM-dd HH:mm:ss");

                csv.AppendLine($"{sensor},{x},{y},{DateStamp}");




                }

        }

        File.WriteAllText(filePath, csv.ToString());
        
    }










}
