namespace ExamCsharpMikkel.Processing;
using ExamCsharpMikkel.SensorDataClass;
public interface IDataProcessor //very simple interface to play around with holding calls to methods
{

    void Run(List<SensorData> data);
}