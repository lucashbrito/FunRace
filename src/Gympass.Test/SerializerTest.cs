using System.IO;
using Gympass.Domain.Infrastructure;
using Gympass.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gympass.Test
{
    [TestClass]
    public class SerializerTest
    {
        private static string _defaultPath;
        private static string _templatesConfig;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            ReadResults();
        }

        private static void ReadResults()
        {
            _defaultPath = $@"{Directory.GetCurrentDirectory()}\\Assets\\Config\\DefaultTemplate.json";
            _templatesConfig = File.ReadAllText(_defaultPath);
        }
      
        [TestMethod]
        public void Should_DeserializerTemplateConfig()
        {
            ISerializer serializer = new Serializer();
            var templateConfig = serializer.GetTemplateConfig(_templatesConfig);

            Assert.IsNotNull(templateConfig);
            Assert.AreEqual("ArrivalTime", templateConfig.Results[0].field);
            Assert.AreEqual("11", templateConfig.Results[0].length);
            Assert.AreEqual("0", templateConfig.Results[0].startIndex);
        }

    }
}
