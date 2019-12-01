using System;

namespace Gympass.Domain.Aggregate
{
    public class Root : IRoot
    {
        public delegate void GetInformation(string line, string startIndex, string length);

        public int IdDriver { get; private set; }
        public virtual bool CheckLineLenght(string line, int lenght)
        {
            return line.Length >= lenght - 1;
        }

        public void GetDriverId(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length)))
                IdDriver = 0;

            IdDriver = Convert.ToInt32(line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length)));
        }
    }
}
