namespace Gympass.Domain.Interfaces
{
    public interface ICalculate
    {
        double GetHourToMinutes(string hour);

        double GetMinutesToSeconds(string minute);
    }
}
