using System;
using FunRace.Application.Services;
using FunRace.Data;
using FunRace.Infrastructure.Infrastructure;
using Gympass.Domain;

namespace FunRace.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var path = Apresentation();

                var dataReceived = LoggerReport.ReceiveData(path);

                var resultLaps = dataReceived.GetLineResults();

                var template = GetTemplate();

                ILapRepository lapRepository = new LapRepository(new FunRaceContext(resultLaps));

                var formulaOneServices = FormulaOneServices.Initializer(template, lapRepository);

                formulaOneServices.StartTheRace();

                var statistics = StatisticsServices.Create(lapRepository);

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
