using System.Reflection.Metadata.Ecma335;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Infrastructure.Raum.Dtos;

public record CreateRaumDto(string Nummer, string Name)
{
    public RaumAggregate? ToDomain()
    {
        var raumNummer = RaumNummer.Create(Nummer);
        if(raumNummer == null)
        {
            return null;
        }

        return new()
        {
            RaumNummer = raumNummer,
            Name = new(Name)
        };
    }
}
