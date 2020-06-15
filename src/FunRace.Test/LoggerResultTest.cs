using System.IO;
using FunRace.Infrastructure.Infrastructure;
using FunRace.Infrastructure.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunRace.Test
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
            ILoggerReport logger = LoggerReport.ReceiveData(_configPath);

            var result = logger.GetLineResults();

            Assert.IsNotNull(result);
        }
    }
}
