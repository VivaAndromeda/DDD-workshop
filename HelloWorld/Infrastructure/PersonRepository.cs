using HelloWorld.Domain;

namespace HelloWorld.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> persons = new();

        public void Save(Person person)
        {
            persons.Add(person);
        }

        public Person? GetById(Guid id)
        {
            return persons.FirstOrDefault(x => x.Id == id);
        }

        public Person? GetByBenutzername(string benutzername)
        {
            return persons.FirstOrDefault(x => x.Benutzername == benutzername);
        }
    }
}
