using Gympass.Repository;

namespace Gympass.Domain.Model
{
    public class ReportDetailsModel
    {
        public ReportDetailsModel()
        {
            Pilot = new Driver();
            Lap = new LapDetails();
        }
        public Driver Pilot { get; set; }

        public LapDetails Lap { get; set; }
    }
}
