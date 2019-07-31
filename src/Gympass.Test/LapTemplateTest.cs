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
        public void Should_GetTime()
        {
            ILapTemplate lap = new LapTemplate(_resultModel);
            var time = lap.GetArrivalTime(_resultLines[1]);
            var timeExpected = "23:49:08.27";

            Assert.IsNotNull(time);
            Assert.AreEqual(timeExpected, time.ToString());
        }

        [TestMethod]
        public void Should_GetAverageLap()
        {
            ILapTemplate lap = new LapTemplate(_resultModel);
            var averageLap = lap.GetAverageLap(_resultLines[1]);

            Assert.IsNotNull(averageLap);
            Assert.AreEqual(44275, averageLap);
        }

        [TestMethod]
        public void Should_GetRaceLap()
        {
            ILapTemplate lap = new LapTemplate(_resultModel);
            var raceLap = lap.GetRaceTracks(_resultLines[1]);

            Assert.IsNotNull(raceLap);
            Assert.AreEqual(1, raceLap);
        }

        [TestMethod]
        public void Should_GetTimeLap()
        {
            ILapTemplate lap = new LapTemplate(_resultModel);
            var timeLap = lap.GetCircuitTime(_resultLines[1]);

            Assert.IsNotNull(timeLap);
            Assert.AreEqual("1:02.852", timeLap);
        }
    }
}
