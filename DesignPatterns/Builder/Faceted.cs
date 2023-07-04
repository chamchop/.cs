namespace DesignPatterns.Builder
{
    public class Faceted
    {
        public class Person
        {
            public string StreetAddress, Postcode, City;

            public string CompanyName, Position;

            public int AnnualIncome;

            public override string ToString()
            {
                return $"{nameof(StreetAddress)} : {StreetAddress}, {nameof(Postcode)} : {Postcode}, {nameof(City)} : {City}";
            }
        }

        public class PersonBuilder // facade
        {
            protected Person person = new Person();

            public PersonJobBuilder Works => new PersonJobBuilder(person);

            public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

            public static implicit operator Person(PersonBuilder pb)
            {
                return pb.person;
            }
        }

        public class PersonAddressBuilder : PersonBuilder
        {
            public PersonAddressBuilder(Person person)
            {
                this.person = person;
            }

            public PersonAddressBuilder At(string streetAddress)
            {
                person.StreetAddress = streetAddress;
                return this;
            }

            public PersonAddressBuilder WithPostcode(string postCode)
            {
                person.Postcode = postCode;
                return this;
            }

            public PersonAddressBuilder In(string city)
            {
                person.City = city;
                return this;
            }
        }

        public class PersonJobBuilder : PersonBuilder
        {
            public PersonJobBuilder(Person person)
            {
                this.person = person;
            }

            public PersonJobBuilder At(string companyName)
            {
                person.CompanyName = companyName;
                return this;
            }

            public PersonJobBuilder AsA(string position)
            {
                person.Position = position;
                return this;
            }

            public PersonJobBuilder Earning(int amount)
            {
                person.AnnualIncome = amount;
                return this;
            }
        }

        public class Execution
        {
            public static void Exe()
            {
                var pb = new PersonBuilder();
                Person person = pb
                    .Lives.At("10 High Street")
                        .In("London")
                        .WithPostcode("ABC123")
                    .Works.At("7Eleven")
                        .AsA("Engineer")
                        .Earning(123000);
                Console.WriteLine(person);
            }
        }
    }
}
