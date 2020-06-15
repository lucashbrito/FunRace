using System;
using System.IO;
using FunRace.Infrastructure.Infrastructure;
using Gympass.Domain;
using Gympass.Domain.Aggregate;
using static System.IO.File;

namespace FunRace.Application.Services
{
    public class FormulaOneCommand : IAddLapCommandHandler
    {
        public ILapRepository LapRepository { get; set; }

        private string _path = ReadAllText($@"{Directory.GetCurrentDirectory()}\\Config\\DefaultTemplate.json");

        private FormulaOneCommand(string template, ILapRepository lapRepository)
        {
            if (!string.IsNullOrEmpty(template))
                _path = template;

            LapRepository = lapRepository ?? throw new ArgumentNullException("File with the grid details can not be null or empty");
        }

        public static IAddLapCommandHandler Initializer(string template, ILapRepository lapRepository)
        {
            return new FormulaOneCommand(template, lapRepository);
        }

        public void Handler()
        {
            var serializer = Serializer.Create();
            var calculate = Calculate.Create();
            var template = serializer.GetTemplateConfig(_path);

            for (int line = 1; line < LapRepository.GetLengthLines(); line++)
            {
                var averageLap = Convert.ToDecimal(LapRepository.ReadLine(line, template.RootObjectConfigModel.AverageLap.startIndex, template.RootObjectConfigModel.AverageLap.length));
                var raceTracks = Convert.ToInt32(LapRepository.ReadLine(line, template.RootObjectConfigModel.Laps.startIndex, template.RootObjectConfigModel.Laps.length));
                var arrivalTime = LapRepository.ReadLine(line, template.RootObjectConfigModel.ArrivalTime.startIndex, template.RootObjectConfigModel.ArrivalTime.length);
                var circuitTime = LapRepository.ReadLine(line, template.RootObjectConfigModel.CircuitTime.startIndex, template.RootObjectConfigModel.CircuitTime.length);
                var id = Convert.ToInt64(LapRepository.ReadLine(line, template.RootObjectConfigModel.PilotId.startIndex, template.RootObjectConfigModel.PilotId.length));
                var name = LapRepository.ReadLine(line, template.RootObjectConfigModel.PilotName.startIndex, template.RootObjectConfigModel.PilotName.length);

                var driver = Driver.Create(id, name);
                var lap = Lap.Create(arrivalTime, raceTracks, circuitTime, averageLap, driver.Id);

                lap.SetArrivalTimeInMinutes(calculate.ConvertHourToMinute(lap.ArrivalTime));
                lap.SetCircuitTimeInSeconds(calculate.ConvertMinutesToSeconds(lap.CircuitTime));

                LapRepository.AddDriver(driver);
                LapRepository.AddLap(lap);
            }
        }
    }
}
