namespace Gympass.Domain.Interfaces
{
    public interface IMethodTemplate
    {
        bool CheckLineLenght(string line, int lenght);
        int GetPilotId(string line);
    }
}
