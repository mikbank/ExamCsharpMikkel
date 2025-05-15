
namespace ExamCsharpMikkel.SensorDataClass;
using Serilog;
using Serilog.Context;

public class SensorData // class to contain sensor data line structure and enforce validation. 
{
    private int _x;
    private int _y;
    private DateTime _date;  

    public bool IsValid { get; private set; } = true;
    public string SensorName { get; set; } = string.Empty;

    public int X
    {
        get => _x;
        set
        {
            if (value >= 999)
            {
                Log.Information($"[Validation] X value {value} is invalid (>= 999). Entry not valid");
                IsValid = false;
            }
            else
            {
                _x = value;
            }
        }
    }

    public int Y
    {
        get => _y;
        set
        {
            if (value >= 999)
            {
                Log.Information($"[Validation] Y value {value} is invalid (>= 999). Entry not valid");
                IsValid = false;
                
            }
            else
            {
                _y = value;
            }
        }
    }

    public DateTime Date
    {
        get => _date;
        set
        {
            if (value > DateTime.Now)
            {
                Log.Information($"[Validation] Date {value} is in the future. Entry not valid");
                IsValid = false;
                
            }
            else
            {
                _date = value;
            }
        }
    }
}