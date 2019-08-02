using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;
using Gympass.Repository;
using static System.IO.File;

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
        private Dictionary<int, double> _driverPositionsDictionary;

        public FormulaOneService(string path, string[] repository, ILapTemplate lapTemplate, IPilotTemplate pilotTemplate, ICalculate calculate, ISerializer serializer, GympassContext dbContext)
        {

            _path = string.IsNullOrEmpty(path) ? ReadAllText($@"{Directory.GetCurrentDirectory()}\\Config\\DefaultTemplate.json") : path;
            _repository = repository;
            _lapTemplate = lapTemplate;
            _pilotTemplate = pilotTemplate;
            _calculate = calculate;
            _serializer = serializer;
            _gympassContext = dbContext;
            _driverPositionsDictionary = new Dictionary<int, double>();
        }
        public void Start()
        {
            var templateConfig = _serializer.GetTemplateConfig(_path);

            for (int i = 1; i < _repository.Length; i++)
            {
                var resultModel = new ReportDetailsModel
                {
                    LapDetails =
                    {
                        AverageLap = _lapTemplate.GetAverageLap(_repository[i],
                            templateConfig.RootObjectConfigModel.AverageLap.startIndex,
                            templateConfig.RootObjectConfigModel.AverageLap.length),

                        Laps = _lapTemplate.GetRaceTracks(_repository[i],
                            templateConfig.RootObjectConfigModel.Laps.startIndex,
                            templateConfig.RootObjectConfigModel.Laps.length),

                        ArrivalTime = _lapTemplate.GetArrivalTime(_repository[i],
                            templateConfig.RootObjectConfigModel.ArrivalTime.startIndex,
                            templateConfig.RootObjectConfigModel.ArrivalTime.length),

                        CircuitTime = _lapTemplate.GetCircuitTime(_repository[i],
                            templateConfig.RootObjectConfigModel.CircuitTime.startIndex,
                        templateConfig.RootObjectConfigModel.CircuitTime.length),

                        DriverId = _pilotTemplate.GetPilotId(_repository[i],
                            templateConfig.RootObjectConfigModel.PilotId.startIndex,
                            templateConfig.RootObjectConfigModel.PilotId.length)
                    },
                    Driver =
                    {
                        Id = _pilotTemplate.GetPilotId(_repository[i],
                            templateConfig.RootObjectConfigModel.PilotId.startIndex,
                            templateConfig.RootObjectConfigModel.PilotId.length),

                        Name = _pilotTemplate.GetPilotName(_repository[i],
                            templateConfig.RootObjectConfigModel.PilotName.startIndex,
                            templateConfig.RootObjectConfigModel.PilotName.length)
                    }
                };

                _gympassContext.AddLaps(resultModel.LapDetails);

                _gympassContext.AddDriver(resultModel.Driver);
            }

            GetArrivalTimeInMinutes();

            GetCircuitTimeInSeconds();
        }

        public void GetBestLap()
        {
            var bestLap = _gympassContext.Laps.OrderBy(p => p.CircuitTimeInSeconds).FirstOrDefault();
            var driver = _gympassContext.Drivers.FirstOrDefault(d => d.Id == bestLap?.DriverId);

            Console.WriteLine("");
            Console.WriteLine($"Best lap in this circuit was " +
                              $"{driver?.Id}" +
                              $"{driver?.Name}" +
                              $"{bestLap?.CircuitTime}");
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
                lap.CircuitTimeInSeconds = _calculate.GetMinutesToSeconds(lap.CircuitTime);
            }
        }

        public void Result()
        {
            var drivers = DriverFinished();

            _driverPositionsDictionary = SumLapsByDriverId(drivers, _driverPositionsDictionary);

            GetPositions(_driverPositionsDictionary);
        }

        public void GetBestLapOfEachDriver()
        {
            var drivers = _gympassContext.Drivers.ToList();

            foreach (var driver in drivers)
            {
                var laps = _gympassContext.Laps.Where(d => d.DriverId == driver.Id).ToList();

                var bestLap = laps.Min(m => m.CircuitTimeInSeconds);

                Console.WriteLine($"");
                Console.WriteLine($"Best lap of {driver.Id} {driver.Name} was  {TimeSpan.FromSeconds(bestLap)}");
            }


        }

        private void GetPositions(Dictionary<int, double> driverPositionsDictionary)
        {
            var position = 1;

            foreach (var (driverId, totalLap) in driverPositionsDictionary.OrderBy(value => value.Value))
            {
                var driver = _gympassContext.Drivers.FirstOrDefault(p => p.Id == driverId);
                var laps = _gympassContext.Laps.FirstOrDefault(l => l.DriverId == driverId && l.Laps == 4);

                ShowPositions(position, driver, laps, totalLap);

                position++;
            }
        }

        private static void ShowPositions(int position, Driver driver, LapDetails laps, double totalLap)
        {
            Console.WriteLine("");
            Console.WriteLine($"Position: {position}  | " +
                              $"{driver?.Id} " +
                              $"{driver?.Name}           |" +
                              $"Total LapDetails {laps?.Laps}    |" +
                              $"Total time {TimeSpan.FromMinutes(totalLap / 60)}");
        }

        private Dictionary<int, double> SumLapsByDriverId(IEnumerable<LapDetails> drivers, Dictionary<int, double> position)
        {
            if (drivers != null)
            {
                foreach (var driver in drivers)
                {
                    var laps = _gympassContext.Laps.Where(lap => lap.DriverId == driver.DriverId);

                    var aux = laps.Sum(lapDetail => lapDetail.CircuitTimeInSeconds);

                    position.Add(driver.DriverId, aux);
                }
            }

            return position;
        }

        private IEnumerable<LapDetails> DriverFinished()
        {
            return _gympassContext.Laps.Where(lap => lap.Laps == 4).ToList();
        }

        public void AverageSpeed()
        {
            var drivers = _gympassContext.Drivers.ToList();
            Console.WriteLine("/n Average speed of each driver");

            foreach (var driver in drivers)
            {
                var laps = _gympassContext.Laps.Where(p => p.DriverId == driver.Id);

                decimal averageSpeed = 0;
                int totalLaps = 0;

                foreach (var lap in laps)
                {
                    averageSpeed += lap.AverageLap;
                    totalLaps++;
                }

                Console.WriteLine($"{driver.Id}  " +
                                  $"{driver.Name} " +
                                  $"{averageSpeed / totalLaps}");
            }

        }

        public void DifferenceOfEachPilot()
        {
            var bestDriverDictionary = _driverPositionsDictionary.OrderBy(k => k.Value).First();
            var bestDriver = _gympassContext.Drivers.FirstOrDefault(k => k.Id == bestDriverDictionary.Key);

            var auxDriverPositionDictionary = _driverPositionsDictionary;

            auxDriverPositionDictionary.Remove(bestDriverDictionary.Key);

            foreach (var (driverId, totalLap) in auxDriverPositionDictionary.OrderBy(value => value.Value))
            {
                var driver = _gympassContext.Drivers.FirstOrDefault(p => p.Id == driverId);

                var difference = totalLap - bestDriverDictionary.Value;

                Console.WriteLine("");
                Console.WriteLine($"difference between {bestDriver?.Id} {bestDriver?.Name} from {driver?.Id } {driver?.Name } was {TimeSpan.FromSeconds(difference)}");
            }


        }
    }
}
