namespace Gympass.Domain.Interfaces
{
    public interface ILoggerReport
    {
        string[] ReadResult();

        string[] ReadResult(string path);
    }
}
