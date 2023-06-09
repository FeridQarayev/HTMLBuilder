namespace DesignPatternBuilder.DesignPatterns
{
    public class FacetedBuilder
    {
        public class Person
        {
            public string StreetAdress, Postcode, City;
            public string CompanyName, Position;

            public int AnnualIncome;

            public override string ToString()
            {
                return $"{nameof(StreetAdress)}: {StreetAdress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }
        public class PersonBuilder
        {
            protected Person person = new Person();

            public PersonJobBuilder Works => new PersonJobBuilder(person);
            public PersonAddressBuilder Live => new PersonAddressBuilder(person);

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
                person.StreetAdress = streetAddress;
                return this;
            }
            public PersonAddressBuilder WithPostcode(string postcode)
            {
                person.Postcode = postcode;
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
            public PersonJobBuilder Asa(string position)
            {
                person.Position = position;
                return this;
            }
            public PersonJobBuilder Earing(int amount)
            {
                person.AnnualIncome = amount;
                return this;
            }
        }
    }
}
