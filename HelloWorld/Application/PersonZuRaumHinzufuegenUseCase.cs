using HelloWorld.Domain;

namespace HelloWorld.Application;

public class PersonZuRaumHinzufuegenUseCase
{
    private IRaumRepository _raumRepository;
    private IPersonRepository _personRepository;

    public PersonZuRaumHinzufuegenUseCase(IRaumRepository raumRepository, IPersonRepository personRepository)
    {
        _raumRepository = raumRepository;
        _personRepository = personRepository;
    }

    public Ergebnis Hinzufuegen(Guid raumId, Guid personId)
    {
        var raum = _raumRepository.GetById(raumId);
        if(raum == null)
        {
            return new FehlerErgebnis($"Raum mit ID {raumId} nicht gefunden.");
        }

        var person = _personRepository.GetById(personId);
        if (person == null)
        {
            return new FehlerErgebnis($"Person mit ID {personId} nicht gefunden.");
        }

        raum.FuegePersonHinzu(personId);

        return new RaumErfolgsErgebnis(raum);
    }
}