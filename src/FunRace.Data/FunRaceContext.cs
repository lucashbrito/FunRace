using System.Collections.Generic;
using Gympass.Domain.Aggregate;

namespace FunRace.Data
{
    public class FunRaceContext
    {
        public string[] Line { get; set; }

        public IList<Driver> Drivers { get; set; }
        public IList<Lap> Laps { get; set; }

        public FunRaceContext(string[] line)
        {
            Line = line;
            Drivers = new List<Driver>();
            Laps = new List<Lap>();
        }
    }
}
