using System;
using Gympass.Domain.Aggregate;

namespace Gympass.Domain.AggregateLap
{
    public class Lap : Root, ILap
    {
        public string ArrivalTime { get; private set; }

        public int Laps { get; private set; }

        public string CircuitTime { get; private set; }

        public decimal AverageLap { get; private set; }

        public double CircuitTimeInSeconds { get; private set; }

        public double ArrivalTimeInMinutes { get; private set; }

        private Lap()
        {

        }

        public static Lap Create()
        {
            return new Lap();
        }

        public void GetArrivalTime(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length)))
                ArrivalTime = String.Empty;

            ArrivalTime = line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length));
        }

        public void GetRaceTracks(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length))) Laps = 0;

            Laps = Convert.ToInt32(line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length)));
        }

        public void GetCircuitTime(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length)))
                CircuitTime = String.Empty;

            var circuitTime = line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length));

            if (string.IsNullOrEmpty(circuitTime)) CircuitTime = String.Empty;

            CircuitTime = circuitTime;
        }

        public void GetAverageLap(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length)))
                AverageLap = 0;

            AverageLap = Convert.ToDecimal(line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length)));
        }

        public void SetArrivalTimeInMinutes(double minutes)
        {
            ArrivalTimeInMinutes = minutes;
        }

        public void SetCircuitTimeInSeconds(double seconds)
        {
            CircuitTimeInSeconds = seconds;
        }       
    }
}
