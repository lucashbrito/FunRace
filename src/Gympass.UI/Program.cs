using System;
using System.Collections.Generic;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.MethodTemplate;
using Gympass.Domain.Model;
using Gympass.Domain.Service;
using Gympass.Repository;

namespace Gympass.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerResult loggerResult = new LoggerResult();
            string[] resultLines;
            var resultModel = new ResultModel();

            Console.WriteLine("Insert the path log, please!");

            var path = Console.ReadLine();

            resultLines = string.IsNullOrEmpty(path) ? loggerResult.ReadResult() : loggerResult.ReadResult(path);

            IResultService resultService = new ResultService(resultLines, new LapTemplate(resultModel), new PilotTemplate(resultModel));

            resultService.Build();

            resultService.GetBestLap();

            resultService.AverageSpeed();

            resultService.DifferenceOfEachPilot();
        }
    }
}
