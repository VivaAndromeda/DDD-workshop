using HelloWorld.Domain.Person.ValueObjects;

namespace HelloWorld.Domain.Person
{
    public interface IPersonRepository
    {
        public void Save(PersonAggregate? person);

        public PersonAggregate? Get(PersonId id);

        public PersonAggregate? Get(PersonBenutzername benutzername);
    }
}
