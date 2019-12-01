namespace Gympass.Domain.Aggregrate.AggregateStatistics
{
    public interface IStatistics
    {
        void GetBestLap();

        void GetBestLapOfEachDriver();

        void Result();
       
        void AverageSpeed();

        void DifferenceOfEachPilot();

    }
}
