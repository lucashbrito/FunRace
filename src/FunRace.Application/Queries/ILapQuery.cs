namespace FunRace.Application.Services
{
    public interface IStatisticsQuery
    {
        void GetBestLap();

        void GetBestLapOfEachDriver();

        void Result();
       
        void AverageSpeed();

        void DifferenceOfEachPilot();

    }
}
