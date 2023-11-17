using HelloWorld.Application.Common;
using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum;

namespace HelloWorld.Application.Raum
{
    public class ZeigeRaumAnUseCase
    {
        private readonly IRaumRepository _raumRepository;
        private readonly IPersonRepository _personRepository;

        public ZeigeRaumAnUseCase(IRaumRepository raumRepository, IPersonRepository personRepository)
        {
            _raumRepository = raumRepository;
            _personRepository = personRepository;
        }

        public Ergebnis HoleRaum(Guid id)
        {
            var raum = _raumRepository.GetById(id);
            if (raum == null)
            {
                return new RaumMitIdNichtVorhanden(id);
            }

            IReadOnlyList<PersonId> idsVonPersonenInRaum = raum.PersonenIdsInRaum();
            var personenKurzschreibweisen = ErmittlePersonenKurzschreibweisen(idsVonPersonenInRaum);
            return new HoleRaumErfolgreich(raum, personenKurzschreibweisen);
        }

        private IEnumerable<string> ErmittlePersonenKurzschreibweisen(IReadOnlyList<PersonId> idsVonPersonenInRaum)
        {
            return idsVonPersonenInRaum
                .Select(x => _personRepository.Get(x)?.Kurzschreibweise)
                .Where(x => x != null)!;
        }
    }
}
