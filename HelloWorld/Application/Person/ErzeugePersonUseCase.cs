using HelloWorld.Application.Common;
using HelloWorld.Domain.Person;

namespace HelloWorld.Application.Person;

public class ErzeugePersonUseCase
{
    private readonly IPersonRepository _personRepository;


    public ErzeugePersonUseCase(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Ergebnis Create(PersonAggregate? person)
    {
        if(PersonIstUngueltig(person))
        {
            return new PersonIstUngueltig();
        }

        if(PersonExistiertNicht(person!))
        {
            return new BenutzernameNichtEindeutig(person!.Benutzername);
        }

        _personRepository.Save(person);
        return new PersonErfolgsErgebnis(person);
    }

    private static bool PersonIstUngueltig(PersonAggregate? person)
    {
        return person == null;
    }

    private bool PersonExistiertNicht(PersonAggregate person)
    {
        var existierendePerson = _personRepository.Get(person.Benutzername);
        var personExistiertNicht = existierendePerson == null;
        return personExistiertNicht;
    }
}
