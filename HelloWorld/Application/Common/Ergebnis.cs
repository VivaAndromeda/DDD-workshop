using HelloWorld.Domain.Person;
using HelloWorld.Domain.Raum;

namespace HelloWorld.Application.Common;

public record RaumMitIdNichtVorhanden : Ergebnis
{
    public string Fehlermeldung { get; }

    public RaumMitIdNichtVorhanden(Guid id)
    {
        Fehlermeldung = $"Raum mit Id {id} nicht gefunden.";
    }
}

public record RaumnummerNichtEindeutig : Ergebnis
{
    public string Fehlermeldung { get; }
    public RaumnummerNichtEindeutig(RaumNummer raumNummer)
    {
        Fehlermeldung = $"Raumnummer {raumNummer.Value} ist nicht eindeutig.";
    }
}

public record PersonMitIdNichtVorhanden : Ergebnis
{
    public string Fehlermeldung { get; }

    public PersonMitIdNichtVorhanden(Guid id)
    {
        Fehlermeldung = $"Person mit Id {id} nicht gefunden.";
    }
}

public record Ergebnis;

public record FehlerErgebnis(
    string? Fehlermeldung
) : Ergebnis;

public record RaumErfolgsErgebnis(Domain.Raum.RaumAggregate Raum) : Ergebnis;

public record PersonErfolgsErgebnis(PersonAggregate? Person) : Ergebnis;

public record HoleRaumErfolgreich(Domain.Raum.RaumAggregate Raum, IEnumerable<string> PersonenInKurzschreibweise) : Ergebnis;
