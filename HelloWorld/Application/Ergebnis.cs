using HelloWorld.Domain;

namespace HelloWorld.Application;

public record Ergebnis;

public record FehlerErgebnis(
    string? Fehlermeldung
) : Ergebnis;

public record RaumErfolgsErgebnis(Raum Raum) : Ergebnis;
public record PersonErfolgsErgebnis(Person Person) : Ergebnis;
public record HoleRaumErfolgsErgebnis(Raum Raum, IEnumerable<string> PersonenInKurzschreibweise) : Ergebnis;