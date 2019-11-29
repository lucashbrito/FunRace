namespace Gympass.Domain.Interfaces
{
    public interface IRoot
    {
        bool CheckLineLenght(string line, int lenght);
        int GetPilotId(string line, string startIndex, string length);
    }
}
