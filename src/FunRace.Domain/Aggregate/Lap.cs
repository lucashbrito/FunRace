using System;
using FunRace.Core.DomainObjects;

namespace Gympass.Domain.Aggregate
{
    public class Lap : Entity, IAggregateRoot
    {
        public string ArrivalTime { get; private set; }

        public int Laps { get; private set; }

        public string CircuitTime { get; private set; }

        public decimal AverageLap { get; private set; }

        public double CircuitTimeInSeconds { get; private set; }

        public double ArrivalTimeInMinutes { get; private set; }

        public long DriverId { get; private set; }

        private Lap(string arrivalTime, int laps, string circuitTime, decimal averageLap, long driverId)
        {
            ValidationAssertionConcern.IsNull(arrivalTime, "Arrival Time can't be null or empty");
            ValidationAssertionConcern.IsLessOrEquals(laps, 0, "Laps can't be less or equals than 0");
            ValidationAssertionConcern.IsNull(circuitTime, "Circuit time can't be null or empty");
            ValidationAssertionConcern.IsNull(averageLap, "Arrival Time can't be null or empty");
            ValidationAssertionConcern.IsNull(driverId, "Driver can't be null or empty");

            ArrivalTime = arrivalTime;
            Laps = laps;
            CircuitTime = circuitTime;
            AverageLap = averageLap;
            DriverId = driverId;
        }

        public static Lap Create(string arrivalTime, int laps, string circuitTime, decimal averageLap, long driverId)
        {
            return new Lap(arrivalTime, laps, circuitTime, averageLap, driverId);
        }

        public void SetArrivalTimeInMinutes(double minutes)
        {
            ArrivalTimeInMinutes = minutes;
        }

        public void SetCircuitTimeInSeconds(double seconds)
        {
            CircuitTimeInSeconds = seconds;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
