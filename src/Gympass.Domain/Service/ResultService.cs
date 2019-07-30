using System;
using System.Collections.Generic;
using Gympass.Domain.Interfaces;
using Gympass.Domain.MethodTemplate;
using Gympass.Domain.Model;

namespace Gympass.Domain.Service
{
    public class ResultService : IResultService
    {
        private ResultModel _resultModel;
        private IList<ResultModel> _listResult;
        private MethodTemplate.MethodTemplate _lapTemplate;
        private MethodTemplate.MethodTemplate _pilotTemplate;

        public ResultModel ResultModel
        {
            get
            {
                if (_resultModel != null) return _resultModel;

                return _resultModel = new ResultModel();
            }
            set { _resultModel = value; }
        }

        private string[] _resultLines;

        public ResultService(string[] resultLines, IList<ResultModel> listResult, LapTemplate lapTemplate, PilotTemplate pilotTemplate)
        {
            _resultLines = resultLines;
            _listResult = listResult;
            _lapTemplate = lapTemplate;
            _pilotTemplate = pilotTemplate;
        }
        public void Build()
        {
            for (int i = 1; i < _resultLines.Length - 1; i++)
            {
                _resultModel = _lapTemplate.GetInformation(_resultLines[i]);
                _resultModel = _pilotTemplate.GetInformation(_resultLines[i]);


                _listResult.Add(_resultModel);

                Console.WriteLine($"Time: {_resultModel.Lap.Time} " +
                                  $"Pilot {_resultModel.Pilot.Id} {_resultModel.Pilot.Name}" +
                                  $"Race lap {_resultModel.Lap.TimeLap} Time lap{_resultModel.Lap.TimeLap}" +
                                  $" Average speed{_resultModel.Lap.AverageLap}");
            }


        }

        public ResultModel GetBestLap()
        {
            throw new NotImplementedException();
        }

        public ResultModel AverageSpeed()
        {
            throw new NotImplementedException();
        }

        public void DifferenceOfEachPilot()
        {
            throw new NotImplementedException();
        }
    }
}
