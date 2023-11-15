namespace HelloWorld.Domain
{
    public interface IRaumRepository
    {
        void Save(Raum raum);
        Raum? GetByRaumNummer(RaumNummer raumNummer);
        IEnumerable<RaumNummer> GetRaumNummern();
    }
}
