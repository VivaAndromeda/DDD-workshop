﻿using HelloWorld.Domain;

namespace HelloWorld.Application
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
                return new FehlerErgebnis($"Raum mit Id {id} nicht gefunden.");
            }

            var personenKurzschreibweisen = raum.PersonenIdsInRaum().Select(x => _personRepository.GetById(x)?.Kurzschreibweise);
            return new HoleRaumErfolgsErgebnis(raum, personenKurzschreibweisen);
        }
    }
}
