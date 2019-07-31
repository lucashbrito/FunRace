using Gympass.Domain.Model;

namespace Gympass.Domain.Interfaces
{
    public interface IResultService
    {
        void Build();

        void GetBestLap();

        void AverageSpeed();

        void DifferenceOfEachPilot();
    }
}
