using HelloWorld.Application;
using HelloWorld.Domain;

namespace HelloWorld.Infrastructure.DTOs;

public class LeseRaumDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string RaumNummer { get; init; }
    public IEnumerable<string> Personen { get; init; } = new List<string>();

    public static LeseRaumDto FromDomain(HoleRaumErfolgsErgebnis ergebnis)
    {
        return new LeseRaumDto
        {
            Id = ergebnis.Raum.Id,
            Name = ergebnis.Raum.Name,
            RaumNummer = ergebnis.Raum.RaumNummer.Nummer,
            Personen = ergebnis.PersonenInKurzschreibweise
        };
    }
}
