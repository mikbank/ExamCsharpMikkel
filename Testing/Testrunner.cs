using System;
using ExamCsharpMikkel.Processing;
using ExamCsharpMikkel.Monitor;
using ExamCsharpMikkel.Events;
using ExamCsharpMikkel.TestData;


class TestRunner
{
    static void Main()
    {
        // THis subscribes to the timer method
        AppEvents.OnProcessingCompleted += duration =>
        {
            Console.WriteLine($"Execution completed in {duration.TotalSeconds} seconds.");
        };

        
        
        //Test Creation of TestData
        ExecutionTimer.ChronoGraph(() => TestDataGenerator.CsvCreator(@"C:\Temp\SensorData.csv"));
        
        // Test Method 1
      //  ExecutionTimer.ChronoGraph(() => Method1Processor.Run("Testing Method 1...")); //lambda!

        // Test Method 2
      //  ExecutionTimer.ChronoGraph(() => Method2Processor.Run("Testing Method 2..."));

        // Test Method 3 with dummy file path
      //  ExecutionTimer.ChronoGraph(() => Method3Processor.Run("C:\\fakepath\\test.csv"));
    }
}