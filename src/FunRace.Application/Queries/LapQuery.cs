using System;
using System.Collections.Generic;
using System.Linq;
using Gympass.Domain;
using Gympass.Domain.Aggregate;

namespace FunRace.Application.Queries
{
    public class LapQuery : IStatisticsQuery
    {
        private Dictionary<long, double> _driverPositionsDictionary;
        private ILapRepository _lapRepository;

        private LapQuery(ILapRepository lapRepository)
        {
            _lapRepository = lapRepository;
            _driverPositionsDictionary = new Dictionary<long, double>();
        }

        public static LapQuery Create(ILapRepository lapRepository)
        {
            return new LapQuery(lapRepository);
        }

        public void GetBestLap()
        {
            var bestLap = _lapRepository.BestLap();
            var driver = _lapRepository.GetDriverById(bestLap.DriverId);

            Console.WriteLine("");
            Console.WriteLine($"Best lap in this circuit was {driver?.Id} {driver?.Name} {bestLap?.CircuitTime}");
        }

        public void GetBestLapOfEachDriver()
        {
            foreach (var driver in _lapRepository.GetDrivers())
            {
                var bestLap = _lapRepository.GetBestLapCircuitTimeInSecondLapByDriverId(driver.Id);

                Console.WriteLine("");
                Console.WriteLine($"Best lap of {driver.Id} {driver.Name} was in {TimeSpan.FromSeconds(bestLap)}");
            }
        }

        public void GetPositions()
        {
            var auxPosition = 1;

            foreach (var driver in _lapRepository.GetDrivers())
            {
                _driverPositionsDictionary.Add(driver.Id, _lapRepository.GetTotalLapCircuitTimeInSecondLapByDriverId(driver.Id));
            }

            foreach (var (driverId, totalLap) in _driverPositionsDictionary.OrderBy(value => value.Value))
            {
                var driver = _lapRepository.GetDriverById(driverId);
                var laps = _lapRepository.GetLastLap(driverId, 4);

                ShowPositions(auxPosition, driver, laps, totalLap);

                auxPosition++;
            }
        }

        public void GetAverageSpeed()
        {
            Console.WriteLine("/n Average speed of each driver");

            foreach (var driver in _lapRepository.GetDrivers())
            {
                var laps = _lapRepository.GetLapsByDriverId(driver.Id);

                decimal averageSpeed = 0;
                var totalLaps = 0;

                foreach (var lap in laps)
                {
                    averageSpeed += lap.AverageLap;
                    totalLaps++;
                }

                Console.WriteLine($"{driver.Id} {driver.Name} {averageSpeed / totalLaps}");
            }
        }

        public void GetDifferenceForEachDriver()
        {
            if (DriverPositionsIsEmpty()) return;

            var bestDriverDictionary = _driverPositionsDictionary.OrderBy(k => k.Value).First();
            var bestDriver = _lapRepository.GetDriverById(bestDriverDictionary.Key);

            var auxDriverPositionDictionary = _driverPositionsDictionary;

            auxDriverPositionDictionary.Remove(bestDriverDictionary.Key);

            foreach (var (driverId, totalLap) in auxDriverPositionDictionary.OrderBy(value => value.Value))
            {
                var driver = _lapRepository.GetDriverById(driverId);

                var difference = totalLap - bestDriverDictionary.Value;

                Console.WriteLine("");
                Console.WriteLine($"difference between {bestDriver?.Id} {bestDriver?.Name} from {driver?.Id } {driver?.Name } was {TimeSpan.FromSeconds(difference)}");
            }
        }

        private bool DriverPositionsIsEmpty()
        {
            return _driverPositionsDictionary.Count <= 0;
        }

        private static void ShowPositions(int position, Driver driver, Lap laps, double totalLap)
        {
            Console.WriteLine("");
            Console.WriteLine($"Position: {position}  | " +
                              $"{driver?.Id} " +
                              $"{driver?.Name}           |" +
                              $"Total LapDetails {laps?.Laps}    |" +
                              $"Total time {TimeSpan.FromMinutes(totalLap / 60)}");
        }
    }
}
