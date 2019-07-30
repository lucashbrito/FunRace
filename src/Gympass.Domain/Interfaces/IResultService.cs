using Gympass.Domain.Model;

namespace Gympass.Domain.Interfaces
{
    public interface IResultService
    {
        ResultModel Build();

        ResultModel GetBestLap();

        ResultModel AverageSpeed();

        void DifferenceOfEachPilot();
    }
}
