using System;
using Gympass.Domain.Aggregate;

namespace Gympass.Domain.AggregateDriver
{
    public class Driver : Root, IDriver
    {
        public string Name { get; private set; }

        private Driver()
        {

        }

        public void GetDriverName(string line, string startIndex, string length)
        {
            if (!CheckLineLenght(line, Convert.ToInt32(startIndex) + Convert.ToInt32(length)))
                Name = string.Empty;

            Name = line.Substring(Convert.ToInt32(startIndex), Convert.ToInt32(length));
        }

        public static Driver Create()
        {
            return new Driver();
        }
    }
}
