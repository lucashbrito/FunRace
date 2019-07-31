using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Gympass.Repository
{
    public class GympassContext
    {
        public IList<Driver> Pilots { get; set; }
        public IList<LapDetails> Laps { get; set; }

        public GympassContext()
        {
            Pilots = new List<Driver>();
            Laps = new List<LapDetails>();
        }

        public void AddPilots(Driver pilot)
        {
            if (this.Pilots.Any(p => p.Id == pilot.Id)) return;

            this.Pilots.Add(pilot);
        }

        public void AddLaps(LapDetails lap)
        {
            this.Laps.Add(lap);
        }
    }
}
