namespace HelloWorld.Domain
{
    public interface IPersonRepository
    {
        public void Save(Person person);

        public Person? GetById(Guid id);

        public Person? GetByBenutzername(string benutzername);
    }
}
