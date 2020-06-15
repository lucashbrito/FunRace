using System.Collections.Generic;
using System.Linq;

namespace Gympass.Repository
{
    public class GympassContext
    {
        public IList<Driver> Drivers { get; set; }
        public IList<Lap> Laps { get; set; }

        private GympassContext()
        {
            Drivers = new List<Driver>();
            Laps = new List<Lap>();
        }

        public void AddDriver(Driver pilot)
        {
            if (this.Drivers.Any(p => p.Id == pilot.Id)) return;

            this.Drivers.Add(pilot);
        }

        public void AddLaps(Lap lap)
        {
            this.Laps.Add(lap);
        }

        public static GympassContext Create()
        {
           return new GympassContext();
        }
    }
}
