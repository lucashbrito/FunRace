using Gympass.Domain.AggregateDriver;
using Gympass.Domain.AggregateLap;
using System.Collections.Generic;
using System.Linq;

namespace Gympass.Domain.Model
{
    public class ReportDetailsModel
    {
        public List<Driver> Drivers { get; set; }

        public List<Lap> Laps { get; set; }
        private ReportDetailsModel()
        {
            Drivers = new List<Driver>();
            Laps = new List<Lap>();
        }

        public static ReportDetailsModel Create()
        {
            return new ReportDetailsModel();
        }     

        public void AddDriver(Driver driver)
        {
            if (Drivers.Any(p => p.IdDriver == driver.IdDriver)) return;

            Drivers.Add(driver);
        }

        public void AddLaps(Lap lap)
        {
            Laps.Add(lap);
        }      
    }
}
