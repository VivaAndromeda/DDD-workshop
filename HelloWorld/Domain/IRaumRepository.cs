namespace HelloWorld.Domain
{
    public interface IRaumRepository
    {
        void Save(Raum raum);
        Raum? GetById(Guid id);
        Raum? GetByRaumNummer(RaumNummer nummer);
    }
}
