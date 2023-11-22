namespace HelloWorld.Domain.Person.ValueObjects;

public class PersonNamenszusatz
{
    private static readonly string[] ErlaubteNamenszusaetze = {"von", "van", "de"};

    public string? Value { get; }

    private PersonNamenszusatz(string? namenszusatz)
    {
        Value = namenszusatz;
    }

    public static PersonNamenszusatz? Erzeuge(string namenszusatz)
    {
        if(NamenszusatzNichtVorhandenOderUngueltig(namenszusatz))
        {
            return null;
        }

        return new(namenszusatz);
    }

    private static bool NamenszusatzNichtVorhandenOderUngueltig(string namenszusatz)
    {
        return string.IsNullOrEmpty(namenszusatz) || !ErlaubteNamenszusaetze.Contains(namenszusatz);
    }
}
