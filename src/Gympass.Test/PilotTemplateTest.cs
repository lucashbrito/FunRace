using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.MethodTemplate;
using Gympass.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gympass.Test
{
    [TestClass]
    public class PilotTemplateTest
    {
        private static string _resultPath;
        private static ILoggerResult _logger;
        private static string[] _resultLines;
        private static ResultModel _resultModel;


        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            ReadResults();
            _resultModel = new ResultModel();
        }

        private static void ReadResults()
        {
            _resultPath = $@"{Directory.GetCurrentDirectory()}\\Assets\\Documents\\LoggerResult.txt";
            _logger = new LoggerResult();
            _resultLines = _logger.ReadResult(_resultPath);
        }

        [TestMethod]
        public void Should_GetPilotId()
        {
            IPilotTemplate pilot = new PilotTemplate(_resultModel);
            var id = pilot.GetPilotId(_resultLines[1]);

            Assert.IsNotNull(id);
            Assert.AreEqual(38, id);
        }

        [TestMethod]
        public void Should_GetPilotName()
        {
            IPilotTemplate pilot = new PilotTemplate(_resultModel);
            var name = pilot.GetPilotName(_resultLines[1]);

            Assert.IsNotNull(name);
            Assert.AreEqual(" F.MASSA                           ", name);
        }
    }
}
