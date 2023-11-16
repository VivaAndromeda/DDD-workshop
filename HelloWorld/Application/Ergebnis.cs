using HelloWorld.Domain;

namespace HelloWorld.Application;

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

public record RaumErfolgsErgebnis(Raum Raum) : Ergebnis;

public record PersonErfolgsErgebnis(Person Person) : Ergebnis;

public record HoleRaumErfolgreich(Raum Raum, IEnumerable<string> PersonenInKurzschreibweise) : Ergebnis;
