namespace FunRace.Infrastructure.Infrastructure.Interfaces
{
    public interface ICalculate
    {
        double ConvertHourToMinute(string hour);

        double ConvertMinutesToSeconds(string minute);
    }
}
