using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Application.Common;

public record RaumMitIdNichtVorhanden : Ergebnis
{
    public string Fehlermeldung { get; }

    public RaumMitIdNichtVorhanden(RaumId id)
    {
        Fehlermeldung = $"Raum mit Id {id.Value} nicht gefunden.";
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

    public PersonMitIdNichtVorhanden(PersonId id)
    {
        Fehlermeldung = $"Person mit Id {id.Value} nicht gefunden.";
    }
}

public record Ergebnis;

public record FehlerErgebnis(
    string? Fehlermeldung
) : Ergebnis;

public record RaumErfolgsErgebnis(RaumAggregate Raum) : Ergebnis;

public record PersonErfolgsErgebnis(PersonAggregate? Person) : Ergebnis;

public record HoleRaumErfolgreich(RaumAggregate Raum, IEnumerable<string> PersonenInKurzschreibweise) : Ergebnis;
