using HelloWorld.Domain;

namespace HelloWorld.Infrastructure.DTOs
{
    public class CreateRaumDTO
    {
        public string RaumNummer { get; }
        public string Name { get; }

        public Raum? ToDomain()
        {
            var raumNummer = Domain.RaumNummer.Create(this.RaumNummer);
            if (raumNummer == null)
            {
                return null;
            }

            return new Raum
            {
                RaumNummer = raumNummer,
                Name = Name
            };
        }
    }
}
