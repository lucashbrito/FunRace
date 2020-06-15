using FunRace.Infrastructure.Template;

namespace FunRace.Infrastructure.Infrastructure.Interfaces
{
    public interface ISerializer
    {
        RootObject GetTemplateConfig(string template);
    }
}
