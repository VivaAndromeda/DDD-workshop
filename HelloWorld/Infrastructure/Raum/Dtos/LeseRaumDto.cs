using HelloWorld.Application;
using HelloWorld.Application.Common;

namespace HelloWorld.Infrastructure.Raum.Dtos;

public record LeseRaumDto(
    Guid Id,
    string Name,
    string Nummer,
    IEnumerable<string> Personen
)
{
    public static LeseRaumDto FromDomain(RaumErmittelt ergebnis)
    {
        return new(ergebnis.Raum.Id.Value,
            ergebnis.Raum.Name.Value,
            ergebnis.Raum.RaumNummer.Value,
            ergebnis.PersonenInKurzschreibweise);
    }
}
