using System;
using Gympass.Domain.Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace Gympass.Domain.Templates
{
    public class LapTemplate : MethodTemplate, ILapTemplate
    {
        public double GetArrivalTime(string line)
        {
            if (!CheckLineLenght(line, 11)) return 0;
            var arrivalTime = line.Substring(0, 11);

            var arrivalTimeSplit = arrivalTime.Split(':');
            var milisecondsSplit = arrivalTimeSplit[3].Split('.');

            var hours = Convert.ToInt32(arrivalTimeSplit[0]) / 60;
            var minutes = Convert.ToInt32(arrivalTimeSplit[1]) / 60;
            var second = Convert.ToInt32(arrivalTimeSplit[2]);
            var milliseconds = Convert.ToInt32(milisecondsSplit[0]) * 0.001;

            var total = hours + minutes + second + milliseconds;

            return total;
        }

        public int GetRaceTracks(string line)
        {
            if (!CheckLineLenght(line, 57 + 2)) return 0;

            return Convert.ToInt32(line.Substring(57, 2));
        }

        public double GetCircuitTime(string line)
        {
            if (!CheckLineLenght(line, 61 + 8)) return 0;

            var circuitTime = line.Substring(61, 8);

            if (string.IsNullOrEmpty(circuitTime)) return 0;

            var minuteSplit = circuitTime.Split(':');

            if (minuteSplit.Length == 0) return 0;

            var secondSplit = minuteSplit[1].Split('.');

            var minute = Convert.ToInt32(minuteSplit[0]) * 60;
            var seconds = Convert.ToInt32(secondSplit[0]);
            var milliseconds = Convert.ToInt32(secondSplit[1]) * 0.001;
            var total = minute + seconds + milliseconds;

            return total;
        }

        public decimal GetAverageLap(string line)
        {
            if (!CheckLineLenght(line, 92 + 7)) return 0;

            return Convert.ToDecimal(line.Substring(92, 7));
        }
    }
}
