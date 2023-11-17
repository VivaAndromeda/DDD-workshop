using HelloWorld.Domain.Raum;

namespace HelloWorld.Infrastructure.Raum.Dtos
{
    public class CreateRaumDto
    {
        public string RaumNummer { get; init; }
        public string Name { get; init; }

        public RaumAggregate? ToDomain()
        {
            var raumNummer = Domain.Raum.RaumNummer.Create(RaumNummer);
            if (raumNummer == null)
            {
                return null;
            }

            return new RaumAggregate
            {
                RaumNummer = raumNummer,
                Name = Name
            };
        }
    }
}
