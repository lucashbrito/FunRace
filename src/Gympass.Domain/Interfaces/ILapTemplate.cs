using System;

namespace Gympass.Domain.Interfaces
{
    public interface ILapTemplate : IMethodTemplate
    {
        double GetArrivalTime(string line);

        int GetRaceTracks(string line);

        double GetCircuitTime(string line);

        decimal GetAverageLap(string line);
    }
}
