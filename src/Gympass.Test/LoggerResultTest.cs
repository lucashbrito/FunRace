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
            ILoggerResult logger = new LoggerResult();

            var result = logger.ReadResult(_configPath);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_ReadResult_WithoutPath()
        {
            ILoggerResult logger = new LoggerResult();

            var result = logger.ReadResult();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_ReadResult_WithPath()
        {
            ILoggerResult logger = new LoggerResult();

            logger.ReadResult(_resultPath);

        }
    }
}
