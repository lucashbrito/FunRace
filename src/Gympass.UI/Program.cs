using System;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.AggregateFormulaOne;
using Gympass.Domain.Aggregrate.AggregateStatistics;

namespace Gympass.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = Apresentation();

                var loggerResult = LoggerReport.CreateLoggerResult(path);

                var resultLaps = loggerResult.ReadResult();

                var template = GetTemplate();

                IFormulaOne formulaOne = FormulaOne.Initializer(template, resultLaps);

                var reportDetailsModel = formulaOne.StartTheRace();

                var statistics = Statistics.Create(reportDetailsModel.Laps, reportDetailsModel.Drivers);

                statistics.Result();

                statistics.GetBestLap();

                statistics.AverageSpeed();

                statistics.DifferenceOfEachPilot();

                statistics.GetBestLapOfEachDriver();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        private static string Apresentation()
        {
            Console.WriteLine("You're welcome to crazy f1. To return the whole details, please insert the log's path.");
            Console.WriteLine("In case if you don't have any one. We already mocked a default for you.");
            Console.WriteLine("I hope you enjoy the code.");

            return Console.ReadLine();
        }

        private static string GetTemplate()
        {
            Console.WriteLine("Do you want to use a new template or the default? In case to use the default, just press enter.");
            return Console.ReadLine();
        }
    }
}
