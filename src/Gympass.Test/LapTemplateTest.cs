using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Gympass.Domain.Model;
using Gympass.Domain.Templates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gympass.Test
{
    [TestClass]
    public class LapTemplateTest
    {
        private static string _resultPath;
        private static ILoggerReport _logger;
        private static string[] _repository;
        private static  ISerializer _serializer;
        private static RootObject _templateConfig;
        private static ILapTemplate _lap;

      [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            ReadResults();
            _serializer= new Serializer();
            _lap = new LapTemplate();

            var template = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\Assets\\Config\\DefaultTemplate.json");

            _templateConfig = _serializer.GetTemplateConfig(template);
        }

        private static void ReadResults()
        {
            _resultPath = $@"{Directory.GetCurrentDirectory()}\\Assets\\Documents\\LoggerResult.txt";
            _logger = new LoggerReport();
            _repository = _logger.ReadResult(_resultPath);
        }

        [TestMethod]
        public void Should_GetArrivalTime()
        {
            var time = _lap.GetArrivalTime(_repository[1],
                _templateConfig.RootObjectConfigModel.ArrivalTime.startIndex,
                _templateConfig.RootObjectConfigModel.ArrivalTime.length);

            var timeExpected = "23:49:08.27";

            Assert.IsNotNull(time);
            Assert.AreEqual(timeExpected, time.ToString());
        }

        [TestMethod]
        public void Should_GetAverageLap()
        {
            var averageLap = _lap.GetAverageLap(_repository[1],
                _templateConfig.RootObjectConfigModel.AverageLap.startIndex,
                _templateConfig.RootObjectConfigModel.AverageLap.length);

            Assert.IsNotNull(averageLap);
            Assert.AreEqual(44275, averageLap);
        }

        [TestMethod]
        public void Should_GetRaceLap()
        {
            var raceLap = _lap.GetRaceTracks(_repository[1],
                _templateConfig.RootObjectConfigModel.Laps.startIndex,
                _templateConfig.RootObjectConfigModel.Laps.length);

            Assert.IsNotNull(raceLap);
            Assert.AreEqual(1, raceLap);
        }

        [TestMethod]
        public void Should_GetCircuitTime()
        {
            var timeLap = _lap.GetCircuitTime(_repository[1],
                _templateConfig.RootObjectConfigModel.CircuitTime.startIndex,
                _templateConfig.RootObjectConfigModel.CircuitTime.length);

            Assert.IsNotNull(timeLap);
            Assert.AreEqual("1:02.852", timeLap);
        }
    }
}
