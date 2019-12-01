using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Infrastructure.Interfaces;
using Gympass.Domain.Model;
using Gympass.Domain.AggregateLap;
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
        private static Lap _lap;

      [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            ReadResults();
            _serializer= Serializer.Create();
            _lap = Lap.Create();

            var template = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\Assets\\Config\\DefaultTemplate.json");

            _templateConfig = _serializer.GetTemplateConfig(template);
        }

        private static void ReadResults()
        {
            _resultPath = $@"{Directory.GetCurrentDirectory()}\\Assets\\Documents\\LoggerResult.txt";
            _logger = LoggerReport.CreateLoggerResult(_resultPath);
            _repository = _logger.ReadResult();
        }

        [TestMethod]
        public void Should_GetArrivalTime()
        {
             _lap.GetArrivalTime(_repository[1],
                _templateConfig.RootObjectConfigModel.ArrivalTime.startIndex,
                _templateConfig.RootObjectConfigModel.ArrivalTime.length);

            var timeExpected = "23:49:08.27";

            Assert.IsNotNull(_lap.ArrivalTime);
            Assert.AreEqual(timeExpected, _lap.ArrivalTime.ToString());
        }

        [TestMethod]
        public void Should_GetAverageLap()
        {
             _lap.GetAverageLap(_repository[1],
                _templateConfig.RootObjectConfigModel.AverageLap.startIndex,
                _templateConfig.RootObjectConfigModel.AverageLap.length);

            Assert.IsNotNull(_lap.AverageLap);
            Assert.AreEqual(44275, _lap.AverageLap);
        }

        [TestMethod]
        public void Should_GetRaceLap()
        {
            _lap.GetRaceTracks(_repository[1],
                _templateConfig.RootObjectConfigModel.Laps.startIndex,
                _templateConfig.RootObjectConfigModel.Laps.length);

            Assert.IsNotNull(_lap.Laps);
            Assert.AreEqual(1, _lap.Laps);
        }

        [TestMethod]
        public void Should_GetCircuitTime()
        {
            _lap.GetCircuitTime(_repository[1],
                _templateConfig.RootObjectConfigModel.CircuitTime.startIndex,
                _templateConfig.RootObjectConfigModel.CircuitTime.length);

            Assert.IsNotNull(_lap.CircuitTime);
            Assert.AreEqual("1:02.852", _lap.CircuitTime);
        }
    }
}
