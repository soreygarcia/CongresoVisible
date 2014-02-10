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
    internal class DataTestHelper
    {
        private static Fixture fixture = new Fixture();

        internal static PartiesContainer GetPartiesCollection()
        {
            return new PartiesContainer()
            {
                results = fixture.CreateMany<Party>(10).ToList()
            };
        }

        internal static PeopleContainer GetPeopleCollection()
        {
            return new PeopleContainer()
            {
                results = fixture.CreateMany<Person>(10).ToList()
            };
        }

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
    }
}


