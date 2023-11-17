using HelloWorld.Domain.Raum;

namespace HelloWorld.Infrastructure.Raum;

public class RaumRepository : IRaumRepository
{
    private List<Domain.Raum.RaumAggregate> raums = new();

    public Domain.Raum.RaumAggregate? GetByRaumNummer(RaumNummer raumNummer)
    {
        return raums.FirstOrDefault(x => x.RaumNummer.Value == raumNummer.Value);
    }

    public void Save(Domain.Raum.RaumAggregate raum)
    {
        raums.Add(raum);
    }

    public Domain.Raum.RaumAggregate? GetById(Guid id)
    {
        return raums.FirstOrDefault(x => x.Id == id);
    }
}
