namespace HelloWorld.Domain.Person
{
    public interface IPersonRepository
    {
        public void Save(PersonAggregate? person);

        public PersonAggregate? GetById(Guid id);

        public PersonAggregate? GetByBenutzername(string benutzername);
    }
}
