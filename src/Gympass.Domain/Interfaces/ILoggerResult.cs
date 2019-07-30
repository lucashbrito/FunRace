namespace Gympass.Domain.Interfaces
{
    public interface ILoggerResult
    {
        string[] ReadResult();

        string[] ReadResult(string path);
    }
}
