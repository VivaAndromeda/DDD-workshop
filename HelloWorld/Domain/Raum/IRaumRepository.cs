namespace HelloWorld.Domain.Raum
{
    public interface IRaumRepository
    {
        void Save(RaumAggregate raum);
        RaumAggregate? GetById(Guid id);
        RaumAggregate? GetByRaumNummer(RaumNummer nummer);
    }
}
