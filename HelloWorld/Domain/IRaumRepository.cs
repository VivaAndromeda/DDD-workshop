namespace HelloWorld.Domain
{
    public interface IRaumRepository
    {
        void Save(Raum raum);
        Raum? GetById(Guid id);
        Raum? GetByRaumNummer(RaumNummer nummer);
        Raum? GetRaumByBenutzername(string personBenutzername);
        Raum? GetRaumByPerson(Guid personId);
    }
}
