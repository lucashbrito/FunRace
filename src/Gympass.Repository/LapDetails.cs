using System;

namespace Gympass.Repository
{
    public class LapDetails
    {
        public DateTime ArrivalTime { get; set; }

        public int Laps { get; set; }

        public double CircuitTime { get; set; }

        public decimal AverageLap { get; set; }

        public int DriverId { get; set; }
    }
}
