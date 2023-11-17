using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Infrastructure.Raum;

public class RaumRepository : IRaumRepository
{
    private List<RaumAggregate> raeume = new();

    public void Save(RaumAggregate raum)
    {
        raeume.Add(raum);
    }

    public RaumAggregate? Get(RaumNummer raumNummer)
    {
        return raeume.FirstOrDefault(x => x.RaumNummer == raumNummer);
    }

    public RaumAggregate? Get(RaumId id)
    {
        return raeume.FirstOrDefault(x => x.Id == id);
    }
}
