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

        public abstract ResultModel GetInformation(string line);
    }
}
