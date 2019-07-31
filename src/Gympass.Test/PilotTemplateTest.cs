using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;
using Gympass.Domain.Templates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gympass.Test
{
    [TestClass]
    public class PilotTemplateTest
    {
        private static string _resultPath;
        private static ILoggerReport _logger;
        private static string[] _resultLines;
        private static ReportDetailsModel _resultModel;


        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            ReadResults();
            _resultModel = new ReportDetailsModel();
        }

        private static void ReadResults()
        {
            _resultPath = $@"{Directory.GetCurrentDirectory()}\\Assets\\Documents\\LoggerResult.txt";
            _logger = new LoggerReport();
            _resultLines = _logger.ReadResult(_resultPath);
        }

        [TestMethod]
        public void Should_GetPilotId()
        {
            IPilotTemplate pilot = new DriverTemplate(_resultModel);
            var id = pilot.GetPilotId(_resultLines[1]);

            Assert.IsNotNull(id);
            Assert.AreEqual(38, id);
        }

        [TestMethod]
        public void Should_GetPilotName()
        {
            IPilotTemplate pilot = new DriverTemplate(_resultModel);
            var name = pilot.GetPilotName(_resultLines[1]);

            Assert.IsNotNull(name);
            Assert.AreEqual(" F.MASSA                           ", name);
        }
    }
}
