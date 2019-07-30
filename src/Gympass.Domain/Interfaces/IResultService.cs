using Gympass.Domain.Model;

namespace Gympass.Domain.Interfaces
{
    public interface IResultService
    {
        void Build();

        ResultModel GetBestLap();

        ResultModel AverageSpeed();

        void DifferenceOfEachPilot();
    }
}
