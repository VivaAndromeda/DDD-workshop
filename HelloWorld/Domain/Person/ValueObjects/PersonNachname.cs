namespace HelloWorld.Domain.Person.ValueObjects;

public record PersonNachname
{
    public string Value { get; }

    private PersonNachname(string value)
    {
        Value = value;
    }

    public static PersonNachname Erzeuge(string vorname)
    {
        return new PersonNachname(vorname);
    }
}
