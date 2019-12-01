using System;
using Gympass.Domain.Interfaces;

namespace Gympass.Domain.Templates
{
    public class Lap : Root, ILap
    {
        private Lap()
        {
            
        }
        public string GetArrivalTime(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length))) return String.Empty;

            var arrivalTime = line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length));

            return arrivalTime;
        }

        public int GetRaceTracks(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length))) return 0;

            return Convert.ToInt32(line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length)));
        }

        public string GetCircuitTime(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length))) return String.Empty;

            var circuitTime = line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length));

            if (string.IsNullOrEmpty(circuitTime)) return String.Empty;

            return circuitTime;
        }

        public static ILap Create()
        {
            return new Lap();
        }

        public decimal GetAverageLap(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length))) return 0;

            return Convert.ToDecimal(line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length)));
        }
    }
}
