using Gympass.Domain.Model;

namespace Gympass.Domain.MethodTemplate
{
    public abstract class MethodTemplate
    {
        public ResultModel _resultModel;

        public MethodTemplate(ResultModel resultModel)
        {
            _resultModel = resultModel;
        }

        public abstract ResultModel GetInformation(string line);
    }
}
