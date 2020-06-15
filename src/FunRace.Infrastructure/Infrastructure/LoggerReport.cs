using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FunRace.Infrastructure.Infrastructure.Interfaces;

namespace FunRace.Infrastructure.Infrastructure
{
    public class LoggerReport : ILoggerReport
    {
        private readonly string _path = $@"{Directory.GetCurrentDirectory()}\\Documents\\LoggerResult.txt";

        private LoggerReport(string path)
        {
            if (!string.IsNullOrEmpty(path))
                _path = path;
        }

        public static LoggerReport ReceiveData(string path)
        {
            return new LoggerReport(path);
        }

        public string[] GetLineResults()
        {
            var list = ReadFile(_path);

            return list.ToArray();
        }

        private static List<string> ReadFile(string path)
        {
            var list = new List<string>();

            try
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return list;
        }
    }
}
