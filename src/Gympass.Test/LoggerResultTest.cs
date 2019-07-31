using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gympass.Test
{
    [TestClass]
    public class LoggerResultTest
    {
        private static string _configPath;
        private static string _resultPath;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _configPath = $@"{Directory.GetCurrentDirectory()}\\Config\\Config.json";
            _resultPath = $@"{Directory.GetCurrentDirectory()}\\Assets\\Documents\\LoggerResult.txt";
        }

        [TestMethod]
        public void Should_ReadConfig()
        {
            ILoggerReport logger = new LoggerReport();

            var result = logger.ReadResult(_configPath);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_ReadResult_WithoutPath()
        {
            ILoggerReport logger = new LoggerReport();

            var result = logger.ReadResult();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_ReadResult_WithPath()
        {
            ILoggerReport logger = new LoggerReport();

            logger.ReadResult(_resultPath);

        }
    }
}
