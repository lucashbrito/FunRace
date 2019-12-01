namespace Gympass.Domain.Infrastructure.Interfaces
{
    public interface ICalculate
    {
        double GetHourToMinutes(string hour);

        double GetMinutesToSeconds(string minute);
    }
}
