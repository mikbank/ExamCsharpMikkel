using System;
using ExamCsharpMikkel.Processing;
using ExamCsharpMikkel.Monitor;
using ExamCsharpMikkel.Events;
using ExamCsharpMikkel.TestData;


class TestRunner
{
    static void Main() // here the methods can also be called, used  for unit testing
    {
        // THis subscribes to the timer method
        AppEvents.OnProcessingCompleted += duration =>
        {
            Console.WriteLine($"Execution completed in {duration.TotalSeconds} seconds.");
        };

        
        //Test Creation of TestData
        ExecutionTimer.ChronoGraph(() => TestDataGenerator.CsvCreator(@"C:\Temp\SensorData.csv"));
        
      
    }
}