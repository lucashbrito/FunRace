namespace Gympass.Domain.Interfaces
{
    public interface IPilotTemplate
    {
        int GetPilotId(string line);

        string GetPilotName(string line);
    }
}
