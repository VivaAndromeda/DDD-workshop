namespace HelloWorld.Domain;

public class Namenszusatz
{
    private static readonly string[] _erlaubteNamenszusaetze = {"von", "van", "de"};
    public string? Value { get; }

    private Namenszusatz(string? namenszusatz)
    {
        Value = namenszusatz;
    }

    public static Namenszusatz? Erzeuge(string? namenszusatz)
    {
        if(!_erlaubteNamenszusaetze.Contains(namenszusatz))
        {
            return null;
        }

        return new Namenszusatz(namenszusatz);
    }
}
