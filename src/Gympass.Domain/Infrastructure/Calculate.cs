using System;
using Gympass.Domain.Interfaces;

namespace Gympass.Domain.Infrastructure
{
    public class Calculate : ICalculate
    {
        public double GetHourToMinutes(string hour)
        {
            var arrivalTimeSplit = hour.Split(':');
            var milisecondsSplit = arrivalTimeSplit[3].Split('.');

            var hours = Convert.ToInt32(arrivalTimeSplit[0]) / 60;
            var minutes = Convert.ToInt32(arrivalTimeSplit[1]) / 60;
            var second = Convert.ToInt32(arrivalTimeSplit[2]);
            var milliseconds = Convert.ToInt32(milisecondsSplit[0]) * 0.001;

            var total = hours + minutes + second + milliseconds;

            return total;
        }

        public double GetMinutesToSeconds(string minute)
        {
            var minuteSplit = minute.Split(':');

            if (minuteSplit.Length == 0) return 0;

            var secondSplit = minuteSplit[1].Split('.');

            var minutes = Convert.ToInt32(minuteSplit[0]) * 60;
            var seconds = Convert.ToInt32(secondSplit[0]);
            var milliseconds = Convert.ToInt32(secondSplit[1]) * 0.001;
            var total = minutes + seconds + milliseconds;

            return total;
        }
    }
}
