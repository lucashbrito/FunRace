using System;
using System.Collections.Generic;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.MethodTemplate;
using Gympass.Domain.Model;
using Gympass.Domain.Service;

namespace Gympass.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerResult loggerResult = new LoggerResult();
            string[] resultLines;
            var resultModel = new ResultModel();
            var resultModelsList = new List<ResultModel>();

            var lapTemplate = new LapTemplate(resultModel);
            var pilotTemplate = new PilotTemplate(resultModel);


            Console.WriteLine("Insert the path log, please!");

            var path = Console.ReadLine();

            resultLines = string.IsNullOrEmpty(path) ? loggerResult.ReadResult() : loggerResult.ReadResult(path);

            IResultService resultService = new ResultService(resultLines, resultModelsList, lapTemplate, pilotTemplate);

            resultService.Build();

            resultService.GetBestLap();

            resultService.AverageSpeed();

            resultService.DifferenceOfEachPilot();
        }
    }
}
