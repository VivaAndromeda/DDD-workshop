using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum;

namespace HelloWorld.Application.Common;

public class PersonZuRaumHinzufuegenUseCase
{
    private IRaumRepository _raumRepository;
    private IPersonRepository _personRepository;

    public PersonZuRaumHinzufuegenUseCase(IRaumRepository raumRepository, IPersonRepository personRepository)
    {
        _raumRepository = raumRepository;
        _personRepository = personRepository;
    }

    public Ergebnis Hinzufuegen(Guid raumId, PersonId personId)
    {
        var raum = _raumRepository.GetById(raumId);
        if(raum == null)
        {
            return new RaumMitIdNichtVorhanden(raumId);
        }

        var person = _personRepository.Get(personId);
        if (person == null)
        {
            return new PersonMitIdNichtVorhanden(personId);
        }

        raum.FuegePersonHinzu(personId);

        return new RaumErfolgsErgebnis(raum);
    }
}