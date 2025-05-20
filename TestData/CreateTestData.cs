using System.Text;

namespace ExamCsharpMikkel.TestData;


//Simple function - only meant to quickly create testdata for running the project

public static class TestDataGenerator

{
    private static readonly string[] Sensors = Enumerable.Range(1, 100) //simple function to create a range of theoretical sensors for test data
    .Select(i => $"Sensor{i}")
    .ToArray();

    private static readonly Random random = new Random();
    
    public static void CsvCreator(string filePath , int Entries = 50000)
    {
        var csv = new StringBuilder();
        csv.AppendLine("SensorName,X,Y,Date"); //header for csv. 

        foreach (var sensor in Sensors)
        {
                for (int i = 1; i <= Entries; i++)
                {
                    int x = random.Next(1, 51); //(i % 500 == 0) ? 999 : random.Next(1,51) ; // Creates testdata at random - OBS conditional operator - commented out to create clean data for demonstration 
                    int y = random.Next(1, 51); //(i % 500 == 0) ? 999 : random.Next(1,51);
                    
                    
                    string DateStamp = DateTime.Now.AddSeconds(-i).ToString("yyyy-MM-dd HH:mm:ss");

                csv.AppendLine($"{sensor},{x},{y},{DateStamp}");




                }

        }

        File.WriteAllText(filePath, csv.ToString());
        
    }










}
