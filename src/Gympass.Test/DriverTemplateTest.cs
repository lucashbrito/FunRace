using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;
using Gympass.Domain.Templates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gympass.Test
{
    [TestClass]
    public class DriverTemplateTest
    {
        private static string _resultPath;
        private static ILoggerReport _logger;
        private static string[] _repository;
        private static DriverTemplate _driver;
        private static RootObject _templateConfig;
        private static ISerializer _serializer;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            ReadResults();
        }

        private static void ReadResults()
        {
            _resultPath = $@"{Directory.GetCurrentDirectory()}\\Assets\\Documents\\LoggerResult.txt";

            _logger = new LoggerReport();
            _driver = new DriverTemplate();
            _serializer = new Serializer();

            _repository = _logger.ReadResult(_resultPath);

            var template = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\Assets\\Config\\DefaultTemplate.json");

            _templateConfig = _serializer.GetTemplateConfig(template);
        }

        [TestMethod]
        public void Should_GetPilotId()
        {
            var id = _driver.GetPilotId(_repository[1],
                _templateConfig.RootObjectConfigModel.PilotId.startIndex,
                _templateConfig.RootObjectConfigModel.PilotId.length);

            Assert.IsNotNull(id);
            Assert.AreEqual(38, id);
        }

        [TestMethod]
        public void Should_GetPilotName()
        {

            var name = _driver.GetPilotName(_repository[1],
                _templateConfig.RootObjectConfigModel.PilotName.startIndex,
                _templateConfig.RootObjectConfigModel.PilotName.length);

            Assert.IsNotNull(name);
            Assert.AreEqual(" F.MASSA                           ", name);
        }
    }
}
