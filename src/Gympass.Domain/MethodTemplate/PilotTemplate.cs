using System;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;

namespace Gympass.Domain.MethodTemplate
{
    public class PilotTemplate : MethodTemplate, IPilotTemplate
    {
        public PilotTemplate(ResultModel resultModel) : base(resultModel)
        {
        }

        public override ResultModel GetInformation(string line)
        {
            _resultModel.Pilot.Id = GetPilotId(line);

            _resultModel.Pilot.Name = GetPilotName(line);

            return _resultModel;
        }

        public string GetPilotName(string line)
        {
            if (!CheckLineLenght(line, 23 + 35)) return String.Empty;

            return line.Substring(23, 35);
        }
    }
}
