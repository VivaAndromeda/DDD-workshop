using HelloWorld.Domain;

namespace HelloWorld.Infrastructure.DTOs;

public class LeseRaumDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string RaumNummer { get; init; }
    public IEnumerable<string> Personen { get; init; } = new List<string>();

    public static LeseRaumDto FromDomain(Raum raum)
    {
        return new LeseRaumDto
        {
            Id = raum.Id,
            Name = raum.Name,
            RaumNummer = raum.RaumNummer.Nummer,
            Personen = raum.Personen.Select(x => x.InKurzschreibweise())
        };
    }
}
