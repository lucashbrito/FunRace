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
        private ILapTemplate _lapTemplate;
        private IPilotTemplate _pilotTemplate;

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

        public ResultService(string[] resultLines, List<ResultModel> listResult)
        {
            _resultLines = resultLines;
            _lapTemplate = new LapTemplate(_resultModel);
            _pilotTemplate = new PilotTemplate(_resultModel);
            _listResult = listResult;
        }
        public ResultModel Build()
        {
            throw new NotImplementedException();
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
