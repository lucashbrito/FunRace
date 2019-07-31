using System;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Service;
using Gympass.Domain.Templates;
using Gympass.Repository;

namespace Gympass.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ILoggerReport loggerResult = new LoggerReport();
                string[] resultLines;

                Console.WriteLine("Insert the path report, please!");
                Console.WriteLine("In case if you don't have any one. We already setup the default for you. :)");

                var path = Console.ReadLine();

                resultLines = string.IsNullOrEmpty(path) ? loggerResult.ReadResult() : loggerResult.ReadResult(path);

                IFormulaOneService resultService = new FormulaOneService(resultLines, new LapTemplate(), new DriverTemplate(), new GympassContext());

                resultService.Start();

                resultService.GetBestLap();

                resultService.AverageSpeed();

                resultService.DifferenceOfEachPilot();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
