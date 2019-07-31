using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gympass.Repository
{
    public class Lap
    {
        public IList<Lap> Laps;

        [Key]
        public int Id { get; set; }
        public string Time { get; set; }

        public int RaceLap { get; set; }

        public string TimeLap { get; set; }

        public decimal AverageLap { get; set; }

        public int PilotId { get; set; }
        public virtual Pilot Pilot { get; set; }
    }
}
