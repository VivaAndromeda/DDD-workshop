namespace HelloWorld.Domain.Person.ValueObjects;

public record PersonVorname
{
    public string Value { get; }

    private PersonVorname(string value)
    {
        Value = value;
    }

    public static PersonVorname Erzeuge(string vorname)
    {
        return new PersonVorname(vorname);
    }
}
