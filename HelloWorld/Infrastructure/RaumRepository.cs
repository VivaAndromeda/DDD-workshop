using HelloWorld.Domain;

namespace HelloWorld.Infrastructure;

public class RaumRepository : IRaumRepository
{
    private List<Raum> raums = new();

    public Raum? GetByRaumNummer(RaumNummer raumNummer)
    {
        return raums.FirstOrDefault(x => x.RaumNummer == raumNummer);
    }

    public Raum? GetRaumByBenutzername(string personBenutzername)
    {
        return raums.FirstOrDefault(x => x.Personen.Select(y => y.Benutzername).Contains(personBenutzername));
    }

    public Raum? GetRaumByPerson(Guid personId)
    {
        return raums.FirstOrDefault(x => x.Personen.Select(y => y.Id).Contains(personId));
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
