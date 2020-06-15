using System.Collections.Generic;
using System.Linq;
using FunRace.Core.DomainObjects;
using Gympass.Domain;
using Gympass.Domain.Aggregate;

namespace FunRace.Data
{
    public class LapRepository : ILapRepository
    {
        private FunRaceContext _context;

        public LapRepository(FunRaceContext context)
        {
            _context = context;
        }

        public string ReadLine(int line, int start, int length)
        {
            CheckLineLenght(_context.Line[line], start + length);

            return _context.Line[line].Substring(start + length);
        }

        public void CheckLineLenght(string line, int lenght)
        {
            ValidationAssertionConcern.IsMoreOrEquals(line.Length, lenght - 1, "Lenght is not supported");
        }

        public int GetLengthLines()
        {
            return _context.Line.Length;
        }

        public void AddLap(Lap lap)
        {
            _context.Laps.Add(lap);
        }

        public void AddDriver(Driver driver)
        {
            if (_context.Drivers.Any(p => p.Id == driver.Id)) return;

            _context.Drivers.Add(driver);
        }

        public Lap BestLap()
        {
            return _context.Laps.OrderBy(p => p.CircuitTimeInSeconds).FirstOrDefault();
        }

        public Driver GetDriverById(long driverId)
        {
            return _context.Drivers.FirstOrDefault(d => d.Id == driverId);
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers;
        }

        public double GetBestLapCircuitTimeInSecondLapByDriverId(long driverId)
        {
            return _context.Laps.Where(l => l.DriverId == driverId).Min(p => p.CircuitTimeInSeconds);
        }

        public IEnumerable<Lap> GetLapsByDriverId(long driverId)
        {
            return _context.Laps.Where(p => p.Id == driverId);
        }

        public double GetTotalLapCircuitTimeInSecondLapByDriverId(long driverId)
        {
            return _context.Laps.Where(lap => lap.Id == driverId).Sum(lapDetail => lapDetail.CircuitTimeInSeconds);
        }

        public Lap GetLastLap(long driverId, int lapNumber)
        {
            return _context.Laps.FirstOrDefault(l => l.Id == driverId && l.Laps == lapNumber);
        }
    }
}
