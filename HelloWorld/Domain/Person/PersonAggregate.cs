using HelloWorld.Domain.Person.ValueObjects;

namespace HelloWorld.Domain.Person;

public class PersonAggregate
{
    public PersonId Id { get; } = new(Guid.NewGuid());
    private PersonVorname Vorname { get; }
    private PersonNachname Nachname { get; }
    private PersonNamenszusatz? Namenszusatz { get; }
    public PersonBenutzername Benutzername { get; }

    // make constructor private to prevent creating invalid objects
    private PersonAggregate(PersonVorname vorname, PersonNachname nachname, PersonBenutzername benutzername, PersonNamenszusatz? namenszusatz)
    {
        Vorname = vorname;
        Nachname = nachname;
        Benutzername = benutzername;
        Namenszusatz = namenszusatz;
    }

    public static PersonAggregate? Erzeuge(string vorname, string nachname, string benutzername, string? namenszusatz)
    {
        if(PersonIstUngueltig(vorname, nachname, benutzername))
        {
            return null;
        }

        PersonNamenszusatz? erzeugterNamenszusatz = null;
        if(NamenszusatzVorhanden(namenszusatz))
        {
            erzeugterNamenszusatz = PersonNamenszusatz.Erzeuge(namenszusatz!);

            if(NamenszusatzUngueltig(erzeugterNamenszusatz))
            {
                return null;
            }
        }

        var result = new PersonAggregate(PersonVorname.Erzeuge(vorname),
            PersonNachname.Erzeuge(nachname),
            PersonBenutzername.Erzeuge(benutzername),
            erzeugterNamenszusatz);
        return result;
    }

    private static bool NamenszusatzUngueltig(PersonNamenszusatz? erzeugterNamenszusatz)
    {
        return erzeugterNamenszusatz == null;
    }

    private static bool NamenszusatzVorhanden(string? namenszusatz)
    {
        return !string.IsNullOrEmpty(namenszusatz);
    }

    private static bool PersonIstUngueltig(string vorname, string nachname, string benutzername)
    {
        return string.IsNullOrEmpty(vorname)
            || string.IsNullOrEmpty(nachname)
            || string.IsNullOrEmpty(benutzername);
    }

    public string Kurzschreibweise
    {
        get
        {
            var kurzschreibweise = $"{Vorname.Value} {Namenszusatz?.Value} {Nachname.Value} ({Benutzername.Value})";
            return kurzschreibweise.Replace("  ", " ").Trim();
        }
    }
}
