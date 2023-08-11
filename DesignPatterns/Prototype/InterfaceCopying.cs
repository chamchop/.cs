namespace DesignPatterns.Prototype
{
    public class InterfaceCopying
    {
        public interface IPrototype<T>
        {
            T DeepCopy();
        }

        public class Person : IPrototype<Person>
        {
            public string[] Names;
            public Address Address;

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

            public Person DeepCopy()
            {
                return new Person(Names, Address.DeepCopy());
            }
        }

        public class Address : IPrototype<Address> 
        {
            public string StreetName;
            public int HouseNumber;

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
            public Address DeepCopy()
            {
                return new Address(StreetName, HouseNumber);
            }
        }

        public static void Exe()
        {
            var john = new Person(new[] { "John", "Smith" },
                new Address("London Road", 123));

            var jane = john.DeepCopy();
            jane.Address.HouseNumber = 321;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}
