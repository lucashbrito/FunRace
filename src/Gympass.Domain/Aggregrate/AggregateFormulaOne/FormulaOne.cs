using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gympass.Domain.Aggregrate.AggregateStatistics;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Model;
using static System.IO.File;

namespace Gympass.Domain.AggregateFormulaOne
{
    public class FormulaOne : IFormulaOne
    {
        private string[] _repository;
        private ReportDetailsModel _reportDetailsModel = ReportDetailsModel.Create();

        private string _path = ReadAllText($@"{Directory.GetCurrentDirectory()}\\Config\\DefaultTemplate.json");

        private FormulaOne(string template, string[] repository)
        {
            if (!string.IsNullOrEmpty(template))
                _path = template;

            _repository = repository ?? throw new ArgumentNullException("File with the grid details can not be null or empty");
        }

        public static IFormulaOne Initializer(string template, string[] resultLaps)
        {
            return new FormulaOne(template, resultLaps);
        }

        public ReportDetailsModel StartTheRace()
        {
            var serializer = Serializer.Create();
            var calculate = Calculate.Create();
            var template = serializer.GetTemplateConfig(_path);

            for (int i = 1; i < _repository.Length; i++)
            {
                var lap = AggregateLap.Lap.Create();
                var driver = AggregateDriver.Driver.Create();

                lap.GetAverageLap(_repository[i], template.RootObjectConfigModel.AverageLap.startIndex, template.RootObjectConfigModel.AverageLap.length);
                lap.GetRaceTracks(_repository[i], template.RootObjectConfigModel.Laps.startIndex, template.RootObjectConfigModel.Laps.length);
                lap.GetArrivalTime(_repository[i], template.RootObjectConfigModel.ArrivalTime.startIndex, template.RootObjectConfigModel.ArrivalTime.length);
                lap.GetCircuitTime(_repository[i], template.RootObjectConfigModel.CircuitTime.startIndex, template.RootObjectConfigModel.CircuitTime.length);
                lap.GetDriverId(_repository[i], template.RootObjectConfigModel.PilotId.startIndex, template.RootObjectConfigModel.PilotId.length);

                lap.SetArrivalTimeInMinutes(calculate.GetHourToMinutes(lap.ArrivalTime));
                lap.SetCircuitTimeInSeconds(calculate.GetMinutesToSeconds(lap.CircuitTime));

                driver.GetDriverId(_repository[i], template.RootObjectConfigModel.PilotId.startIndex, template.RootObjectConfigModel.PilotId.length);
                driver.GetDriverName(_repository[i], template.RootObjectConfigModel.PilotName.startIndex, template.RootObjectConfigModel.PilotName.length);

                _reportDetailsModel.AddDriver(driver);
                _reportDetailsModel.Laps.Add(lap);
            }

            return _reportDetailsModel;
        }    
    }
}
