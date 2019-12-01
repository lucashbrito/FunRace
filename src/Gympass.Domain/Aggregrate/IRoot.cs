namespace Gympass.Domain.Aggregate
{
    public interface IRoot
    {
        bool CheckLineLenght(string line, int lenght);
        void GetDriverId(string line, string startIndex, string length);
    }
}
