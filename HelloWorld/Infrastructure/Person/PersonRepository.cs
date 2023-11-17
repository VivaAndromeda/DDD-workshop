using HelloWorld.Domain.Person;

namespace HelloWorld.Infrastructure.Person
{
    public class PersonRepository : IPersonRepository
    {
        private List<PersonAggregate?> persons = new();

        public void Save(PersonAggregate? person)
        {
            persons.Add(person);
        }

        public Domain.Person.PersonAggregate? GetById(Guid id)
        {
            return persons.FirstOrDefault(x => x.Id == id);
        }

        public Domain.Person.PersonAggregate? GetByBenutzername(string benutzername)
        {
            return persons.FirstOrDefault(x => x.Benutzername == benutzername);
        }
    }
}
