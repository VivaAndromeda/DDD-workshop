using HelloWorld.Domain;

namespace HelloWorld.Application;

public record Ergebnis;

public record FehlerErgebnis(
    string? Fehlermeldung
) : Ergebnis;

public record ErfolgsErgebnis(Raum raum) : Ergebnis;