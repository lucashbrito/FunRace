using System.Collections.Generic;
using Gympass.Domain.Model;

namespace Gympass.Domain.Interfaces
{
    public interface ISerializer
    {
        RootObject GetTemplateConfig(string template);
    }
}
