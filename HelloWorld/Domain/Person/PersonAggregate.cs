namespace HelloWorld.Domain.Person;

public class PersonAggregate
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Vorname { get; init; }
    public string Nachname { get; init; }
    public Namenszusatz? Namenszusatz { get; init; }
    public string Benutzername { get; init; }

    public static PersonAggregate? Erzeuge(string vorname, string nachname, string benutzername, string? namenszusatz)
    {
        if(PersonIstUngueltig(vorname, nachname, benutzername))
            return null;
        
        Namenszusatz? erzeugterNamenszusatz = null;
        if(!string.IsNullOrEmpty(namenszusatz))
        {
            erzeugterNamenszusatz = Namenszusatz.Erzeuge(namenszusatz);
            if(erzeugterNamenszusatz == null)
            {
                return null;
            }
        }

        return new PersonAggregate
        {
            Vorname = vorname,
            Nachname = nachname,
            Benutzername = benutzername,
            Namenszusatz = erzeugterNamenszusatz
        };
    }

    private static bool PersonIstUngueltig(string vorname, string nachname, string benutzername)
    {
        return string.IsNullOrEmpty(vorname) || string.IsNullOrEmpty(nachname) || string.IsNullOrEmpty(benutzername);
    }

    public string Kurzschreibweise
    {
        get
        {
            string namenszusatz = string.Empty;
            if (!string.IsNullOrEmpty(Namenszusatz?.Value))
            {
                namenszusatz = Namenszusatz.Value + " ";
            }

            return $"{Vorname} {namenszusatz}{Nachname} ({Benutzername})";
        }
    }
}
