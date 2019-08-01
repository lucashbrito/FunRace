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

                Console.WriteLine("You're welcome to crazy f1. To return the whole details, please insert the log's path.");
                Console.WriteLine("In case if you don't have any one. We already mocked a default for you.");
                Console.WriteLine("I hope you enjoy the code.");

                var path = Console.ReadLine();

                resultLines = string.IsNullOrEmpty(path) ? loggerResult.ReadResult() : loggerResult.ReadResult(path);

                IFormulaOneService formulaOneService = new FormulaOneService(path, resultLines, new LapTemplate(), new DriverTemplate(), new Calculate(), new Serializer(), new GympassContext());

                formulaOneService.Start();

                formulaOneService.Result();

                formulaOneService.GetBestLap();

                formulaOneService.AverageSpeed();

                formulaOneService.DifferenceOfEachPilot();

                formulaOneService.GetBestLapOfEachDriver();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
