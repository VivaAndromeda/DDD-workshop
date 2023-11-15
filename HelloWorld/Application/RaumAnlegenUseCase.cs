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

        public void Create(Raum raum)
        {
            if (!VerfifyRaumNummerEindeutig(raum.RaumNummer))
            {
                throw new ArgumentException(nameof(raum));
            }
            this.raumRepository.Save(raum);
        }

        private bool VerfifyRaumNummerEindeutig(RaumNummer raumNummer)
        {
            var raumNummern = this.raumRepository.GetRaumNummern();
            return !raumNummern.Any(x => x.Nummer == raumNummer.Nummer);
        }
    }
}
