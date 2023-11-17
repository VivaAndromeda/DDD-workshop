namespace HelloWorld.Domain.Person.ValueObjects;

public class PersonNamenszusatz
{
    private static readonly string[] _erlaubteNamenszusaetze = {"von", "van", "de"};
    public string? Value { get; }

    private PersonNamenszusatz(string? namenszusatz)
    {
        Value = namenszusatz;
    }

    public static PersonNamenszusatz? Erzeuge(string namenszusatz)
    {
        if(!_erlaubteNamenszusaetze.Contains(namenszusatz))
        {
            return null;
        }

        return new PersonNamenszusatz(namenszusatz);
    }
}
