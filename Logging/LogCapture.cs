namespace ExamCsharpMikkel.Logging;

using System;
using System.IO;
using System.Text;

public class LogCapture : TextWriter
{
    private readonly StringBuilder _logBuilder = new StringBuilder(); //OBS private readonly, indicated by _ in fieldname
    public event Action<string>? OnLineWritten;
    public override Encoding Encoding => Encoding.UTF8; //encoding is abstract in this context, so need to make sure format is right


    public override void WriteLine(string? value)
    {
        _logBuilder.AppendLine(value);
        OnLineWritten?.Invoke(value ?? string.Empty); // Notify log console - null should be empty string
    }

    public string GetLog() => _logBuilder.ToString();

    public void Clear() => _logBuilder.Clear();
}
