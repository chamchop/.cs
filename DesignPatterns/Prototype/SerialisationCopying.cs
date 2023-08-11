using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static DesignPatterns.Prototype.InheritainceCopying;

namespace DesignPatterns.Prototype
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXML<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }

        public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new()
        {
            return item.DeepCopy();
        }

/*        public static T DeepCopy<T>(this T person) where T : Person, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }*/
    }

    public class SerialisationCopying
    {
        public class Person
        {
            public string[] Names;
            public Address Address;

            public Person()
            {
                
            }

            public Person(string[] names, Address address)
            {
                if (names == null)
                {
                    throw new ArgumentNullException(paramName: nameof(names));
                }

                if (address == null)
                {
                    throw new ArgumentNullException(paramName: nameof(names));
                }

                Names = names;
                Address = address;
            }

            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }
        }

        public class Address
        {
            public string StreetName;
            public int HouseNumber;

            public Address()
            {
                
            }

            public Address(string streetName, int houseNumber)
            {
                if (streetName == null)
                {
                    throw new ArgumentNullException(paramName: nameof(streetName));
                }

                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {string.Join(" ", StreetName)}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }

        public static void Exe()
        {
            var john = new Person(new[] { "John", "Smith" },
                new Address("London Road", 123));

            var jane = john.DeepCopyXML();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}
