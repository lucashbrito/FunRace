using System;
using System.Collections.Generic;
using System.Linq;
using Gympass.Domain.Interfaces;
using Gympass.Domain.MethodTemplate;
using Gympass.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gympass.Domain.Service
{
    public class ResultService : IResultService
    {
        private GympassContext _gympassContext;
        private MethodTemplate.MethodTemplate _lapTemplate;
        private MethodTemplate.MethodTemplate _pilotTemplate;
        private List<Pilot> _pilots= new List<Pilot>();
        private string[] _resultLines;

        public ResultService(string[] resultLines, LapTemplate lapTemplate, PilotTemplate pilotTemplate)
        {
            _resultLines = resultLines;
            _lapTemplate = lapTemplate;
            _pilotTemplate = pilotTemplate;
        }
        public void Build()
        {
            for (int i = 1; i < _resultLines.Length; i++)
            {
                var resultModel = _lapTemplate.GetInformation(_resultLines[i]);
                resultModel = _pilotTemplate.GetInformation(_resultLines[i]);

                Console.WriteLine($"Time: {resultModel.Lap.Time} |" +
                                  $"Pilot: {resultModel.Pilot.Id} {resultModel.Pilot.Name} |" +
                                  $"Race lap: {resultModel.Lap.TimeLap} Time lap: {resultModel.Lap.TimeLap}|" +
                                  $" Average speed: {resultModel.Lap.AverageLap} |");


                using (_gympassContext = new GympassContext(new DbContextOptions<GympassContext>()))
                {
                    _gympassContext.Pilots.Add(resultModel.Pilot);
                    _gympassContext.Laps.Add(resultModel.Lap);
                    _gympassContext.SaveChanges();
                }

            }
        }

        public void GetBestLap()
        {
            //var query = _listResult.GroupBy(p => p.Pilot.Id).ToList();

        }

        public void AverageSpeed()
        {
            throw new NotImplementedException();
        }

        public void DifferenceOfEachPilot()
        {
            throw new NotImplementedException();
        }
    }
}
