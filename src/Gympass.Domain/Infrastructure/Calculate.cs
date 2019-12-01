using System;
using Gympass.Domain.Infrastructure.Interfaces;

namespace Gympass.Domain.Infrastructure
{
    public class Calculate : ICalculate
    {
        private Calculate()
        {
            
        }
        public double GetHourToMinutes(string hour)
        {
            int hours = 0, minutes = 0, second = 0;
            double milliseconds = 0;

            if (string.IsNullOrEmpty(hour))
            {
                return 0;
            }

            var arrivalTimeSplit = hour.Split(':');

            if (arrivalTimeSplit.Length > 0)
                hours = Convert.ToInt32(arrivalTimeSplit[0]) * 360;

            if (arrivalTimeSplit.Length >= 1)
                minutes = Convert.ToInt32(arrivalTimeSplit[1]) * 60;

            if (arrivalTimeSplit.Length >= 2)
            {
                var millisecondsSplit = arrivalTimeSplit[2].Split('.');

                if (millisecondsSplit.Length > 0)
                    second = Convert.ToInt32(millisecondsSplit[0]);

                if (millisecondsSplit.Length >= 1)
                    milliseconds = Convert.ToInt32(millisecondsSplit[1]) * 0.001;
            }

            var totalSeconds = hours + minutes + second + milliseconds;

            return totalSeconds;
        }

        public static ICalculate Create()
        {
            return new Calculate();
        }

        public double GetMinutesToSeconds(string minute)
        {
            int minutes = 0, seconds = 0;
            double milliseconds = 0;

            var minuteSplit = minute.Split(':');

            if (minuteSplit.Length == 0) return 0;

            if (minuteSplit.Length >= 1)
            {
                var secondSplit = minuteSplit[1].Split('.');

                if (minuteSplit.Length > 0)
                    minutes = Convert.ToInt32(minuteSplit[0]) * 60;

                if (secondSplit.Length > 0)
                    seconds = Convert.ToInt32(secondSplit[0]);

                if (secondSplit.Length >= 1)
                    milliseconds = Convert.ToInt32(secondSplit[1]) * 0.001;
            }

            var total = minutes + seconds + milliseconds;

            return total;
        }
    }
}
