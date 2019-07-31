using Gympass.Domain.Interfaces;
using static System.String;

namespace Gympass.Domain.Templates
{
    public class DriverTemplate : MethodTemplate, IPilotTemplate
    {
        public string GetPilotName(string line)
        {
            if (!CheckLineLenght(line, 23 + 35)) return Empty;

            return line.Substring(23, 35);
        }
    }
}
