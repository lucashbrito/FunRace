using Gympass.Repository;

namespace Gympass.Domain.Model
{
    public class ResultModel
    {
        public ResultModel()
        {
            Pilot = new Pilot();
            Lap = new Lap();
        }
        public Pilot Pilot { get; set; }

        public Lap Lap { get; set; }

    }
}
