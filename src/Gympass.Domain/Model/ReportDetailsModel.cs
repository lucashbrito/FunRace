using Gympass.Repository;

namespace Gympass.Domain.Model
{
    public class ReportDetailsModel
    {
        public ReportDetailsModel()
        {
            Driver = new Driver();
            LapDetails = new LapDetails();
        }
        public Driver Driver { get; set; }

        public LapDetails LapDetails { get; set; }


    }
}
