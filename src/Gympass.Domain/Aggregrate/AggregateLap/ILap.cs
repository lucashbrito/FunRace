using Gympass.Domain.Aggregate;

namespace Gympass.Domain.AggregateLap
{
    public interface ILap : IRoot
    {       
        void GetArrivalTime(string line, string startIndex, string length);

        void GetRaceTracks(string line, string startIndex, string length);

        void GetCircuitTime(string line, string startIndex, string length);

        void GetAverageLap(string line, string startIndex, string length);
        
        void SetArrivalTimeInMinutes(double minutes);
        
        void SetCircuitTimeInSeconds(double seconds);
    }
}
