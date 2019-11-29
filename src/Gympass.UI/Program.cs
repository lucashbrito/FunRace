using System;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Service;

namespace Gympass.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path= Apresentation();

                var loggerResult = LoggerReport.CreateLoggerResult(path);

                var resultLaps = loggerResult.ReadResult();

                var template = GetTemplate();

                IFormulaOneService formulaOneService = FormulaOneService.Initializer(template, resultLaps);

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

        private static string Apresentation()
        {
            Console.WriteLine("You're welcome to crazy f1. To return the whole details, please insert the log's path.");
            Console.WriteLine("In case if you don't have any one. We already mocked a default for you.");
            Console.WriteLine("I hope you enjoy the code.");

            return  Console.ReadLine();
        }

        private static string GetTemplate()
        {
            Console.WriteLine("Do you want to use a new template or the default? In case to use the default, just press enter.");
            return Console.ReadLine();
        }
    }
}
