namespace Gympass.Domain.Interfaces
{
    public interface ILapTemplate : IMethodTemplate
    {
        string GetArrivalTime(string line, string startIndex, string length);

        int GetRaceTracks(string line, string startIndex, string length);

        string GetCircuitTime(string line, string startIndex, string length);

        decimal GetAverageLap(string line, string startIndex, string length);
    }
}
