using System;
using Gympass.Domain.Interfaces;

namespace Gympass.Domain.Templates
{
    public class Root : IRoot
    {
        public virtual bool CheckLineLenght(string line, int lenght)
        {
            return line.Length >= lenght - 1;
        }

        public int GetPilotId(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length))) return 0;

            var id = Convert.ToInt32(line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length)));

            return id;
        }
    }
}
