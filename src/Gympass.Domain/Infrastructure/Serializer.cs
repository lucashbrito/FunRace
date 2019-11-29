using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gympass.Domain.Infrastructure
{
    public class Serializer : ISerializer
    {
        private Serializer()
        {
            
        }
        public RootObject GetTemplateConfig(string templateString)
        {
            return JsonConvert.DeserializeObject<RootObject>(templateString, new StringEnumConverter());
        }

        internal static ISerializer Create()
        {
            return new Serializer();
        }
    }
}
