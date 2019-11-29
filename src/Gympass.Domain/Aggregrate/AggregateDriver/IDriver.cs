namespace Gympass.Domain.Interfaces
{
    public interface IDriver : IRoot
    {
        string GetPilotName(string line, string startIndex, string length);
    }
}
