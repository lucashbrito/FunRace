namespace Gympass.Domain.Interfaces
{
    public interface ILapTemplate
    {
        string GetTime(string line);

        int GetRaceLap(string line);

        string GetTimeLap(string line);

        decimal GetAverageLap(string line);
    }
}
