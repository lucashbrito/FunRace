using Gympass.Domain.Model;

namespace Gympass.Domain.Infrastructure.Interfaces
{
    public interface ISerializer
    {
        RootObject GetTemplateConfig(string template);
    }
}
