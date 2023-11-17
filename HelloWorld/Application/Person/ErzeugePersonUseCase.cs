using HelloWorld.Application.Common;
using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;

namespace HelloWorld.Application.Person
{
    public class ErzeugePersonUseCase
    {
        private readonly IPersonRepository _personRepository;


        public ErzeugePersonUseCase(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Ergebnis Erzeuge(PersonAggregate person)
        {
            var existierendePerson = _personRepository.Get(person.Benutzername);
            if (existierendePerson != null)
            {
                return new BenutzernameNichtEindeutig(person.Benutzername);
            }

            _personRepository.Save(person);
            return new PersonErfolgsErgebnis(person);
        }
    }
}
