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

        public int GetPilotId(string line)
        {
            _resultModel.Pilot.Id = Convert.ToInt32(line.Substring(18, 3));
            return _resultModel.Pilot.Id;
        }

        public string GetPilotName(string line)
        {
            _resultModel.Pilot.Name = line.Substring(23, 35);
            return _resultModel.Pilot.Name;
        }
    }
}
