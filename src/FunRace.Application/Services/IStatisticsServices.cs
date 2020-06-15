namespace FunRace.Application.Services
{
    public interface IStatisticsServices
    {
        void GetBestLap();

        void GetBestLapOfEachDriver();

        void Result();
       
        void AverageSpeed();

        void DifferenceOfEachPilot();

    }
}
