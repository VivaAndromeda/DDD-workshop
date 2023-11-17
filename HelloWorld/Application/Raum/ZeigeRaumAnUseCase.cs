using HelloWorld.Application.Common;
using HelloWorld.Domain.Person;
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

            var personenKurzschreibweisen = raum.PersonenIdsInRaum().Select(x => _personRepository.GetById(x)?.Kurzschreibweise);
            return new HoleRaumErfolgreich(raum, personenKurzschreibweisen);
        }
    }
}
