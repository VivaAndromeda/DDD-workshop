using HelloWorld.Domain;

namespace HelloWorld.Infrastructure.Controllers.DTOs
{
    public class CreateRaumDTO
    {
        public string RaumNummer { get; set; }
        public string Name { get; set; }

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
