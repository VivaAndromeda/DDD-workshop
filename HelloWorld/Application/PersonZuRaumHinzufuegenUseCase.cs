using HelloWorld.Domain;

namespace HelloWorld.Application;

public class PersonZuRaumHinzufuegenUseCase
{
    private IRaumRepository _raumRepository;
    public PersonZuRaumHinzufuegenUseCase(IRaumRepository raumRepository)
    {
        _raumRepository = raumRepository;
    }

    public Ergebnis Hinzufuegen(Guid raumId, Person person)
    {
        var raum = _raumRepository.GetById(raumId);
        if(raum == null)
        {
            return new FehlerErgebnis($"Raum mit ID {raumId} nicht gefunden.");
        }
        
        Raum? raumMitBenutzername = _raumRepository.GetRaumByBenutzername(person.Benutzername);
        if(raumMitBenutzername != null)
            return new FehlerErgebnis($"Benutzername {person.Benutzername} nicht eindeutig.");
        
        Raum? raumMitPerson = _raumRepository.GetRaumByPerson(person.Id);
        if(raumMitPerson != null)
            return new FehlerErgebnis($"Person {person.Id} ist bereits einem anderen Raum zugeordnet.");
        
        raum.Personen.Append(person);
        return new ErfolgsErgebnis(raum);
    }
}