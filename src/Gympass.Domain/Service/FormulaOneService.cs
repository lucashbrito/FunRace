using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;
using Gympass.Repository;

namespace Gympass.Domain.Service
{
    public class FormulaOneService : IFormulaOneService
    {
        private GympassContext _gympassContext;
        private ILapTemplate _lapTemplate;
        private IPilotTemplate _pilotTemplate;
        private string[] _repository;
        private ICalculate _calculate;
        private ISerializer _serializer;
        private string _path;

        public FormulaOneService(string path, string[] repository, ILapTemplate lapTemplate, IPilotTemplate pilotTemplate, ICalculate calculate, ISerializer serializer, GympassContext dbContext)
        {
            _path = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\Config\\DefaultTemplate.json");
            _repository = repository;
            _lapTemplate = lapTemplate;
            _pilotTemplate = pilotTemplate;
            _calculate = calculate;
            _serializer = serializer;
            _gympassContext = dbContext;
        }
        public void Start()
        {
            var templateConfig = _serializer.GetTemplateConfig(_path);

            for (int i = 1; i < _repository.Length; i++)
            {
                var resultModel = new ReportDetailsModel
                {
                    Lap =
                    {
                        AverageLap = _lapTemplate.GetAverageLap(_repository[i],
                            templateConfig.RootObjectConfigModel.AverageLap.startIndex,
                            templateConfig.RootObjectConfigModel.AverageLap.length),

                        Laps = _lapTemplate.GetRaceTracks(_repository[i],
                            templateConfig.RootObjectConfigModel.Laps.startIndex,
                            templateConfig.RootObjectConfigModel.Laps.length),

                        ArrivalTime = _lapTemplate.GetArrivalTime(_repository[i],
                            templateConfig.RootObjectConfigModel.ArrivalTime.startIndex,
                            templateConfig.RootObjectConfigModel.Laps.length),

                        CircuitTime = _lapTemplate.GetCircuitTime(_repository[i],
                            templateConfig.RootObjectConfigModel.CircuitTime.startIndex,
                        templateConfig.RootObjectConfigModel.Laps.length),

                        DriverId = _pilotTemplate.GetPilotId(_repository[i],
                            templateConfig.RootObjectConfigModel.PilotId.startIndex,
                            templateConfig.RootObjectConfigModel.PilotId.length)
                    },
                    Pilot =
                    {
                        Id = _pilotTemplate.GetPilotId(_repository[i],
                            templateConfig.RootObjectConfigModel.PilotId.startIndex,
                            templateConfig.RootObjectConfigModel.PilotId.length),

                        Name = _pilotTemplate.GetPilotName(_repository[i],
                            templateConfig.RootObjectConfigModel.PilotName.startIndex,
                            templateConfig.RootObjectConfigModel.PilotName.length)
                    }
                };

                Console.WriteLine("Repository read: ");

                Console.WriteLine($"ArrivalTime: {resultModel.Lap.ArrivalTime} |" +
                                  $"Pilot: {resultModel.Pilot.Id} {resultModel.Pilot.Name} |" +
                                  $"Race lap: {resultModel.Lap.CircuitTime} ArrivalTime lap: {resultModel.Lap.CircuitTime}|" +
                                  $" Average speed: {resultModel.Lap.AverageLap} |");

                _gympassContext.AddLaps(resultModel.Lap);

                _gympassContext.AddPilots(resultModel.Pilot);
            }

            GetArrivalTimeInMinutes();

            GetCircuitTimeInSeconds();
        }

        public void GetBestLap()
        {
            //var query = _listResult.GroupBy(p => p.Pilot.Id).ToList();

        }

        private void GetArrivalTimeInMinutes()
        {
            foreach (var lap in _gympassContext.Laps)
            {
                lap.ArrivalTimeInMinutes = _calculate.GetHourToMinutes(lap.ArrivalTime);
            }
        }

        private void GetCircuitTimeInSeconds()
        {
            foreach (var lap in _gympassContext.Laps)
            {
                lap.CircuitTimeInSeconds = _calculate.GetHourToMinutes(lap.CircuitTime);
            }
        }

        public void Result()
        {
            var drivers = DriverFinished();
            var position = new Dictionary<int, double>();
            if (drivers != null)
            {
                foreach (var driver in drivers)
                {
                    var laps = _gympassContext.Laps.Where(lap => lap.DriverId == driver.Id);
                    double aux = 0;

                    foreach (var lapDetail in laps)
                    {
                        aux += lapDetail.CircuitTimeInSeconds;
                    }

                    position.Add(driver.Id, aux);
                }
            }
        }

        private IEnumerable<Driver> DriverFinished()
        {
            IEnumerable<Driver> drivers = null;
            var whoFinished = _gympassContext.Laps.Where(lap => lap.Laps == 4).ToList();

            foreach (var driverFinished in whoFinished)
            {
                drivers = _gympassContext.Pilots.Where(p => p.Id == driverFinished.DriverId);
            }

            return drivers;
        }

        public void AverageSpeed()
        {
            throw new NotImplementedException();
        }

        public void DifferenceOfEachPilot()
        {
            throw new NotImplementedException();
        }
    }
}
