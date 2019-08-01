namespace Gympass.Domain.Interfaces
{
    public interface IFormulaOneService
    {
        void Start();

        void GetBestLap();

        void AverageSpeed();

        void DifferenceOfEachPilot();

        void Result();
        void GetBestLapOfEachDriver();
    }
}
