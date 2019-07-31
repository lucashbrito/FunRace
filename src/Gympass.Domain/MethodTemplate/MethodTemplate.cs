using System;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;

namespace Gympass.Domain.MethodTemplate
{
    public abstract class MethodTemplate : IMethodTemplate
    {
        public ResultModel _resultModel;

        public MethodTemplate(ResultModel resultModel)
        {
            _resultModel = resultModel;
        }

        public bool CheckLineLenght(string line, int lenght)
        {
            return line.Length < lenght - 1 ? false : true;
        }

        public int GetPilotId(string line)
        {
            if (!CheckLineLenght(line, 18 + 4)) return 0;

            _resultModel.Pilot.Id = Convert.ToInt32(line.Substring(18, 4));
            return _resultModel.Pilot.Id;
        }

        public abstract ResultModel GetInformation(string line);
    }
}
