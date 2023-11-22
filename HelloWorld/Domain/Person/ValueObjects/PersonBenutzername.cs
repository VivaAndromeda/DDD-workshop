namespace HelloWorld.Domain.Person.ValueObjects;

public record PersonBenutzername
{
    public string Value { get; }

    private PersonBenutzername(string value)
    {
        Value = value;
    }

    public static PersonBenutzername Erzeuge(string benutzername)
    {
        return new(benutzername);
    }
}
