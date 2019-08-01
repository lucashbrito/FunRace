namespace Gympass.Repository
{
    public class LapDetails
    {
        public string ArrivalTime { get; set; }

        public double ArrivalTimeInMinutes { get; set; }

        public int Laps { get; set; }

        public string CircuitTime { get; set; }

        public double CircuitTimeInSeconds { get; set; }

        public decimal AverageLap { get; set; }

        public int DriverId { get; set; }
    }
}
