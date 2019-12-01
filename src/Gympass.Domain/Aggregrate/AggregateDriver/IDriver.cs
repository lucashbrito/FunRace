using Gympass.Domain.Aggregate;

namespace Gympass.Domain.AggregateDriver
{
    public interface IDriver : IRoot
    {
        void GetDriverName(string line, string startIndex, string length);
    }
}
