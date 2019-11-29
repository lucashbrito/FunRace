namespace Gympass.Domain.Interfaces
{
    public interface ILap : IRoot
    {
        string GetArrivalTime(string line, string startIndex, string length);

        int GetRaceTracks(string line, string startIndex, string length);

        string GetCircuitTime(string line, string startIndex, string length);

        decimal GetAverageLap(string line, string startIndex, string length);
    }
}
