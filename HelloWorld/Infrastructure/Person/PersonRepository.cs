using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;

namespace HelloWorld.Infrastructure.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<PersonAggregate?> _persons = new();

        public void Save(PersonAggregate? person)
        {
            _persons.Add(person);
        }

        public PersonAggregate? Get(PersonId id)
        {
            return _persons.FirstOrDefault(x => x.Id == id);
        }

        public PersonAggregate? Get(PersonBenutzername benutzername)
        {
            return _persons.FirstOrDefault(x => x.Benutzername == benutzername);
        }
    }
}
