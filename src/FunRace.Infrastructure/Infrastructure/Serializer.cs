﻿using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using FunRace.Infrastructure.Infrastructure.Interfaces;
using FunRace.Infrastructure.Template;

namespace FunRace.Infrastructure.Infrastructure
{
    public class Serializer : ISerializer
    {
        private Serializer()
        {

        }
        public RootObject GetTemplateConfig(string templateString)
        {
            var rootObject = new RootObject();
            var contractJson = new DataContractJsonSerializer(rootObject.GetType());
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(templateString));
            
            rootObject = contractJson.ReadObject(stream) as RootObject;
            
            stream.Close();
           
            return rootObject;
        }


        public static ISerializer Create()
        {
            return new Serializer();
        }
    }
}
