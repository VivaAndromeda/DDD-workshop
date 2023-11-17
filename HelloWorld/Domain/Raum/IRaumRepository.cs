using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Domain.Raum
{
    public interface IRaumRepository
    {
        void Save(RaumAggregate raum);
        RaumAggregate? Get(RaumId id);
        RaumAggregate? Get(RaumNummer nummer);
    }
}
