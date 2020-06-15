using System.Collections.Generic;
using Gympass.Domain.Aggregate;

namespace Gympass.Domain
{
    public interface ILapRepository
    {
        string ReadLine(int line, int start, int length);
        int GetLengthLines();
        void AddLap(Lap lap);
        void AddDriver(Driver driver);
        Lap BestLap();
        Driver GetDriverById(long driverId);
        IEnumerable<Driver> GetDrivers();
        double GetBestLapCircuitTimeInSecondLapByDriverId(long driverId);
        IEnumerable<Lap> GetLapsByDriverId(long driverId);
        double GetTotalLapCircuitTimeInSecondLapByDriverId(long driverId);
        Lap GetLastLap(long driverId, int lapNumber);
    }
}
