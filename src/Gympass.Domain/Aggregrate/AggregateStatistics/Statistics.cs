using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gympass.Domain.Aggregrate.AggregateStatistics
{
    public class Statistics : IStatistics
    {
        private Dictionary<int, double> _driverPositionsDictionary = new Dictionary<int, double>();

        public List<AggregateDriver.Driver> Drivers { get; private set; }

        public List<AggregateLap.Lap> Laps { get; private set; }

        private Statistics(List<AggregateLap.Lap> laps, List<AggregateDriver.Driver> drivers)
        {
            Drivers = drivers ?? throw new NullReferenceException("Drivers can`t be null");
            Laps = laps ?? throw new NullReferenceException("Lap cant not be null");

            if (drivers.Count <= 0)
                throw new ArgumentOutOfRangeException("should have one or more Drivers");

            if (laps.Count <= 0)
                throw new ArgumentOutOfRangeException("should have one or more Laps");
        }

        public static Statistics Create(List<AggregateLap.Lap> laps, List<AggregateDriver.Driver> drivers)
        {
            return new Statistics(laps, drivers);
        }

        public void GetBestLap()
        {
            var bestLap = Laps.OrderBy(p => p.CircuitTimeInSeconds).FirstOrDefault();
            var driver = Drivers.FirstOrDefault(d => d.IdDriver == bestLap?.IdDriver);

            Console.WriteLine("");
            Console.WriteLine($"Best lap in this circuit was {driver?.IdDriver} {driver?.Name} {bestLap?.CircuitTime}");
        }

        public void GetBestLapOfEachDriver()
        {
            foreach (var driver in Drivers)
            {
                var laps = Laps.Where(d => d.IdDriver == driver.IdDriver).ToList();

                var bestLap = laps.Min(m => m.CircuitTimeInSeconds);

                Console.WriteLine($"");
                Console.WriteLine($"Best lap of {driver.IdDriver} {driver.Name} was in {TimeSpan.FromSeconds(bestLap)}");
            }
        }

        public void Result()
        {
            SumLapsByDriverId();

            GetPositions();
        }

        public void AverageSpeed()
        {
            Console.WriteLine("/n Average speed of each driver");

            foreach (var driver in Drivers)
            {
                var laps = Laps.Where(p => p.IdDriver == driver.IdDriver);

                decimal averageSpeed = 0;
                int totalLaps = 0;

                foreach (var lap in laps)
                {
                    averageSpeed += lap.AverageLap;
                    totalLaps++;
                }

                Console.WriteLine($"{driver.IdDriver} {driver.Name} {averageSpeed / totalLaps}");
            }
        }

        public void DifferenceOfEachPilot()
        {
            if (DriverPositionsIsEmpty()) return;

            var bestDriverDictionary = _driverPositionsDictionary.OrderBy(k => k.Value).First();
            var bestDriver = Drivers.FirstOrDefault(k => k.IdDriver == bestDriverDictionary.Key);

            var auxDriverPositionDictionary = _driverPositionsDictionary;

            auxDriverPositionDictionary.Remove(bestDriverDictionary.Key);

            foreach (var (driverId, totalLap) in auxDriverPositionDictionary.OrderBy(value => value.Value))
            {
                var driver = Drivers.FirstOrDefault(p => p.IdDriver == driverId);

                var difference = totalLap - bestDriverDictionary.Value;

                Console.WriteLine("");
                Console.WriteLine($"difference between {bestDriver?.IdDriver} {bestDriver?.Name} from {driver?.IdDriver } {driver?.Name } was {TimeSpan.FromSeconds(difference)}");
            }
        }

        private bool DriverPositionsIsEmpty()
        {
            return _driverPositionsDictionary.Count <= 0;
        }

        private void GetPositions()
        {
            var auxPosition = 1;

            foreach (var (driverId, totalLap) in _driverPositionsDictionary.OrderBy(value => value.Value))
            {
                var driver = Drivers.FirstOrDefault(p => p.IdDriver == driverId);
                var laps = Laps.FirstOrDefault(l => l.IdDriver == driverId && l.Laps == 4);

                ShowPositions(auxPosition, driver, laps, totalLap);

                auxPosition++;
            }
        }

        private static void ShowPositions(int position, AggregateDriver.Driver driver, AggregateLap.Lap laps, double totalLap)
        {
            Console.WriteLine("");
            Console.WriteLine($"Position: {position}  | " +
                              $"{driver?.IdDriver} " +
                              $"{driver?.Name}           |" +
                              $"Total LapDetails {laps?.Laps}    |" +
                              $"Total time {TimeSpan.FromMinutes(totalLap / 60)}");
        }

        private void SumLapsByDriverId()
        {
            foreach (var driver in Drivers)
            {
                var laps = Laps.Where(lap => lap.IdDriver == driver.IdDriver).Sum(lapDetail => lapDetail.CircuitTimeInSeconds);

                _driverPositionsDictionary.Add(driver.IdDriver, laps);
            }
        }
    }
}
