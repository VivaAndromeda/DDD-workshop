using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Application.Common;

public record Ergebnis;

public sealed record RaumMitIdNichtVorhanden : Ergebnis
{
    public string Fehlermeldung { get; }

    public RaumMitIdNichtVorhanden(RaumId id)
    {
        Fehlermeldung = $"Raum mit Id {id.Value} nicht gefunden.";
    }
}

public sealed record RaumnummerNichtEindeutig : Ergebnis
{
    public string Fehlermeldung { get; }
    public RaumnummerNichtEindeutig(RaumNummer raumNummer)
    {
        Fehlermeldung = $"Raumnummer {raumNummer.Value} ist nicht eindeutig.";
    }
}

public sealed record PersonMitIdNichtVorhanden : Ergebnis
{
    public string Fehlermeldung { get; }

    public PersonMitIdNichtVorhanden(PersonId id)
    {
        Fehlermeldung = $"Person mit Id {id.Value} nicht gefunden.";
    }
}
public sealed record BenutzernameNichtEindeutig : Ergebnis
{
    public string Fehlermeldung { get; }

    public BenutzernameNichtEindeutig(PersonBenutzername benutzername)
    {
        Fehlermeldung = $"Benutzername {benutzername.Value} ist nicht eindeutig.";
    }
}

public sealed record RaumErfolgsErgebnis(RaumAggregate Raum) : Ergebnis;

public sealed record PersonErfolgsErgebnis(PersonAggregate? Person) : Ergebnis;

public sealed record HoleRaumErfolgreich(RaumAggregate Raum, IEnumerable<string> PersonenInKurzschreibweise) : Ergebnis;
