using CongresoVisible.Models;
using Moq;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Test.Helpers
{
    internal class TestDataHelper
    {
        private static Fixture fixture = new Fixture();

        internal static string GetSerializedPerson()
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            serializer.WriteObject(stream, fixture.Create<Person>());
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        internal static string GetAnyString()
        {
            return fixture.Create<string>();
        }

        internal static string GetNotFound()
        {
            return "{ \"detail\": \"Not found\" }";
        }

        static TestDataHelper()
        {
            fixture.Behaviors.Clear();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        internal static T GetObject<T>()
        {
            return fixture.Create<T>();
        }

        internal static IEnumerable<T> GetCollection<T>(int count)
        {
            return fixture.CreateMany<T>(count);
        }
    }
}


