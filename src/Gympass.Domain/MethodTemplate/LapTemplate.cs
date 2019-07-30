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

            return _resultModel;
        }

        public string GetTime(string line)
        {
            _resultModel.Lap.Time = line.Substring(0, 11);
            return _resultModel.Lap.Time;
        }

        public int GetRaceLap(string line)
        {
            _resultModel.Lap.RaceLap = Convert.ToInt32(line.Substring(57, 2));
            return _resultModel.Lap.RaceLap;
        }

        public string GetTimeLap(string line)
        {
            _resultModel.Lap.TimeLap = line.Substring(61, 8);
            return _resultModel.Lap.TimeLap;
        }

        public decimal GetAverageLap(string line)
        {
            _resultModel.Lap.AverageLap = Convert.ToDecimal(line.Substring(92, 7));
            return _resultModel.Lap.AverageLap;
        }
    }
}
