using HelloWorld.Domain;

namespace HelloWorld.Application
{
    public class RaumAnlegenUseCase
    {
        private readonly IRaumRepository raumRepository;

        public RaumAnlegenUseCase(IRaumRepository raumRepository)
        {
            this.raumRepository = raumRepository;
        }

        public Ergebnis Create(Raum raum)
        {
            if (!VerfifyRaumNummerEindeutig(raum.RaumNummer))
            {
                return new RaumnummerNichtEindeutig(raum.RaumNummer);
            }

            this.raumRepository.Save(raum);
            return new RaumErfolgsErgebnis(raum);
        }

        private bool VerfifyRaumNummerEindeutig(RaumNummer raumNummer)
        {
            return this.raumRepository.GetByRaumNummer(raumNummer) == null;
        }
    }
}
