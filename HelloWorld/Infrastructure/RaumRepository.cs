using HelloWorld.Domain;

namespace HelloWorld.Infrastructure;

public class RaumRepository : IRaumRepository
{
    private List<Raum> raums = new();

    public Raum? GetByRaumNummer(RaumNummer raumNummer)
    {
        return raums.FirstOrDefault(x => x.RaumNummer.Value == raumNummer.Value);
    }

    public void Save(Raum raum)
    {
        raums.Add(raum);
    }

    public Raum? GetById(Guid id)
    {
        return raums.FirstOrDefault(x => x.Id == id);
    }
}
