using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gympass.Repository
{
    public class Pilot
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Lap> Laps { get; set; }

    }
}
