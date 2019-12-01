using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Infrastructure.Interfaces;
using Gympass.Domain.Model;
using Gympass.Domain.AggregateDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gympass.Test
{
    [TestClass]
    public class DriverTemplateTest
    {
        private static string _resultPath;
        private static ILoggerReport _logger;
        private static string[] _repository;
        private static Driver _driver;
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

            _logger = LoggerReport.CreateLoggerResult(_resultPath);
            _driver = Driver.Create();
            _serializer = Serializer.Create();

            _repository = _logger.ReadResult();

            var template = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\Assets\\Config\\DefaultTemplate.json");

            _templateConfig = _serializer.GetTemplateConfig(template);
        }

        [TestMethod]
        public void Should_GetPilotId()
        {
             _driver.GetDriverId(_repository[1],
                _templateConfig.RootObjectConfigModel.PilotId.startIndex,
                _templateConfig.RootObjectConfigModel.PilotId.length);

            Assert.IsNotNull(_driver.IdDriver);
            Assert.AreEqual(38, _driver.IdDriver);
        }

        [TestMethod]
        public void Should_GetPilotName()
        {

            _driver.GetDriverName(_repository[1],
                _templateConfig.RootObjectConfigModel.PilotName.startIndex,
                _templateConfig.RootObjectConfigModel.PilotName.length);

            Assert.IsNotNull(_driver.Name);
            Assert.AreEqual(" F.MASSA                           ", _driver.Name);
        }
    }
}
