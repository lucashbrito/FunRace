namespace Gympass.Domain.Interfaces
{
    public interface IPilotTemplate : IMethodTemplate
    {
        string GetPilotName(string line);
    }
}
