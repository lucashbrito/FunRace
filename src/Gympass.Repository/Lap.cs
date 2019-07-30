using System;

namespace Gympass.Repository
{
    public class Lap
    {
        public string Time { get; set; }

        public int RaceLap { get; set; }

        public string TimeLap { get; set; }

        public decimal AverageLap { get; set; }

        public int PilotId { get; set; }
    }
}
