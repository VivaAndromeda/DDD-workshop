using HelloWorld.Domain;

namespace HelloWorld.Application
{
    public class ErzeugePersonUseCase
    {
        private readonly IPersonRepository _personRepository;


        public ErzeugePersonUseCase(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Ergebnis Erzeuge(Person person)
        {
            var existierendePerson = _personRepository.GetByBenutzername(person.Benutzername);
            if (existierendePerson != null)
            {
                return new FehlerErgebnis($"Benutzername {person.Benutzername} ist nicht eindeutig.");
            }

            _personRepository.Save(person);
            return new PersonErfolgsErgebnis(person);
        }
    }
}
