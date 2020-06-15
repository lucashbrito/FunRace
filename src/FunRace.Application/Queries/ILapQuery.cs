namespace FunRace.Application.Queries
{
    public interface IStatisticsQuery
    {
        void GetBestLap();
        void GetBestLapOfEachDriver();
        void GetPositions();
        void GetAverageSpeed();
        void GetDifferenceForEachDriver();

    }
}
