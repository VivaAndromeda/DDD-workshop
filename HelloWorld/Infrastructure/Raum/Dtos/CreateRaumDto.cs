using System.Reflection.Metadata.Ecma335;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Infrastructure.Raum.Dtos
{
    public class CreateRaumDto
    {
        public string Nummer { get; init; }
        public string Name { get; init; }

        public RaumAggregate? ToDomain()
        {
            var raumNummer = RaumNummer.Create(Nummer);
            if (raumNummer == null)
            {
                return null;
            }

            return new RaumAggregate
            {
                RaumNummer = raumNummer,
                Name = new RaumName(Name)
            };
        }
    }
}
