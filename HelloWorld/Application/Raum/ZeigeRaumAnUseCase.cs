using HelloWorld.Application.Common;
using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

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

        public Ergebnis HoleRaum(RaumId id)
        {
            var raum = _raumRepository.Get(id);
            if (RaumExistiertNicht(raum))
            {
                return new RaumMitIdNichtVorhanden(id);
            }

            var idsVonPersonenInRaum = raum!.PersonenIdsInRaum();
            var personenKurzschreibweisen = ErmittlePersonenKurzschreibweisen(idsVonPersonenInRaum);
            return new RaumErmittelt(raum, personenKurzschreibweisen);
        }

        private static bool RaumExistiertNicht(RaumAggregate? raum)
        {
            return raum == null;
        }

        private IEnumerable<string> ErmittlePersonenKurzschreibweisen(IReadOnlyList<PersonId> idsVonPersonenInRaum)
        {
            return idsVonPersonenInRaum
                .Select(x => _personRepository.Get(x)?.Kurzschreibweise)
                .Where(x => x != null)!;
        }
    }
}
