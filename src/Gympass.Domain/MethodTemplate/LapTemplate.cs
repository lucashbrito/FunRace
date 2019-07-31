using System;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;

namespace Gympass.Domain.MethodTemplate
{
    public class LapTemplate : MethodTemplate, ILapTemplate
    {
        public LapTemplate(ResultModel resultModel) : base(resultModel)
        {
        }

        public override ResultModel GetInformation(string line)
        {
            _resultModel.Lap.Time = GetTime(line);
            _resultModel.Lap.RaceLap = GetRaceLap(line);
            _resultModel.Lap.TimeLap = GetTimeLap(line);
            _resultModel.Lap.AverageLap = GetAverageLap(line);
            _resultModel.Lap.PilotId = GetPilotId(line);

            return _resultModel;
        }

        public string GetTime(string line)
        {
            if (!CheckLineLenght(line, 11)) return String.Empty;

            return line.Substring(0, 11);
        }

        public int GetRaceLap(string line)
        {
            if (!CheckLineLenght(line, 57 + 2)) return 0;

            return Convert.ToInt32(line.Substring(57, 2));
        }

        public string GetTimeLap(string line)
        {
            if (!CheckLineLenght(line, 61 + 8)) return string.Empty;

            return line.Substring(61, 8);
        }

        public decimal GetAverageLap(string line)
        {
            if (!CheckLineLenght(line, 92 + 7)) return 0;

            return Convert.ToDecimal(line.Substring(92, 7));
        }
    }
}
