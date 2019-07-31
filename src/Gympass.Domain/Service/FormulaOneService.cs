using System;
using System.Collections.Generic;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;
using Gympass.Repository;

namespace Gympass.Domain.Service
{
    public class FormulaOneService : Interfaces.IFormulaOneService
    {
        private GympassContext _gympassContext;
        private ILapTemplate _lapTemplate;
        private IPilotTemplate _pilotTemplate;
        private string[] _repository;

        public FormulaOneService(string[] repository, ILapTemplate lapTemplate, IPilotTemplate pilotTemplate, GympassContext dbContext)
        {
            _repository = repository;
            _lapTemplate = lapTemplate;
            _pilotTemplate = pilotTemplate;
            _gympassContext = dbContext;
        }
        public void Start()
        {
            for (int i = 1; i < _repository.Length; i++)
            {
                var resultModel = new ReportDetailsModel
                {
                    Lap =
                    {
                        AverageLap = _lapTemplate.GetAverageLap(_repository[i]),
                        Laps = _lapTemplate.GetRaceTracks(_repository[i]),
                        ArrivalTime = _lapTemplate.GetArrivalTime(_repository[i]),
                        CircuitTime = _lapTemplate.GetCircuitTime(_repository[i]),
                        DriverId = _pilotTemplate.GetPilotId(_repository[i])
                    },
                    Pilot =
                    {
                        Id = _pilotTemplate.GetPilotId(_repository[i]),
                        Name = _pilotTemplate.GetPilotName(_repository[i])
                    }
                };

                Console.WriteLine($"ArrivalTime: {resultModel.Lap.ArrivalTime} |" +
                                  $"Pilot: {resultModel.Pilot.Id} {resultModel.Pilot.Name} |" +
                                  $"Race lap: {resultModel.Lap.CircuitTime} ArrivalTime lap: {resultModel.Lap.CircuitTime}|" +
                                  $" Average speed: {resultModel.Lap.AverageLap} |");

                _gympassContext.AddLaps(resultModel.Lap);

                _gympassContext.AddPilots(resultModel.Pilot);
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
