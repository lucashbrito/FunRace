using System;
using Gympass.Domain.Interfaces;

namespace Gympass.Domain.Templates
{
    public class Driver : Root, IDriver
    {
        private Driver()
        {
            
        }
        public string GetPilotName(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length))) return string.Empty;

            return line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length));
        }

        public static Driver Create()
        {
           return new Driver();
        }
    }
}
