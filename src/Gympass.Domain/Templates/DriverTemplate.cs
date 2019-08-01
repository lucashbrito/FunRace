using System;
using Gympass.Domain.Interfaces;
using static System.String;

namespace Gympass.Domain.Templates
{
    public class DriverTemplate : MethodTemplate, IPilotTemplate
    {
        public string GetPilotName(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, 23 + 35)) return Empty;

            return line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length));
        }
    }
}
