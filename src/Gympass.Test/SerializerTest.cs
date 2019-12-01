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
            ISerializer serializer = Serializer.Create();
            var templateConfig = serializer.GetTemplateConfig(_templatesConfig);

            Assert.IsNotNull(templateConfig);
            Assert.AreEqual("11", templateConfig.RootObjectConfigModel.ArrivalTime.length);
            Assert.AreEqual("0", templateConfig.RootObjectConfigModel.ArrivalTime.startIndex);
        }

    }
}
