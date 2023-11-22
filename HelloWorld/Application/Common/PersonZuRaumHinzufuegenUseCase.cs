using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

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

    public Ergebnis Hinzufuegen(RaumId raumId, PersonId personId)
    {
        var raum = _raumRepository.Get(raumId);
        if(RaumExistiertNicht(raum))
        {
            return new RaumMitIdNichtVorhanden(raumId);
        }

        if (PersonExistiertNicht(personId))
        {
            return new PersonMitIdNichtVorhanden(personId);
        }

        raum!.FuegePersonHinzu(personId);

        return new PersonHinzugefuegt(raum);
    }

    private bool PersonExistiertNicht(PersonId personId)
    {
        var person = _personRepository.Get(personId);
        var personExistiertNicht = person == null;
        return personExistiertNicht;
    }

    private static bool RaumExistiertNicht(RaumAggregate? raum)
    {
        var raumExistiertNicht = raum == null;
        return raumExistiertNicht;
    }
}