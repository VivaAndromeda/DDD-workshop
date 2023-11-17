using HelloWorld.Application.Common;
using HelloWorld.Domain.Person.ValueObjects;

namespace HelloWorld.Domain.Person;

public class PersonAggregate
{
    public PersonId Id { get; } = new(Guid.NewGuid());
    public PersonVorname Vorname { get; init; }
    public PersonNachname Nachname { get; init; }
    public PersonNamenszusatz? Namenszusatz { get; init; }
    public PersonBenutzername Benutzername { get; init; }

    // make constructor private to prevent creating invalid objects
    private PersonAggregate() { }

    public static PersonAggregate? Erzeuge(string vorname, string nachname, string benutzername, string? namenszusatz)
    {
        if(PersonIstUngueltig(vorname, nachname, benutzername))
        {
            return null;
        }

        PersonNamenszusatz? erzeugterNamenszusatz = null;
        if(!string.IsNullOrEmpty(namenszusatz))
        {
            erzeugterNamenszusatz = PersonNamenszusatz.Erzeuge(namenszusatz);
            if(erzeugterNamenszusatz == null)
            {
                return null;
            }
        }

        return new PersonAggregate
        {
            Vorname = PersonVorname.Erzeuge(vorname),
            Nachname = PersonNachname.Erzeuge(nachname),
            Benutzername = PersonBenutzername.Erzeuge(benutzername),
            Namenszusatz = erzeugterNamenszusatz
        };
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
            string kurzschreibweise = $"{Vorname.Value} {Namenszusatz?.Value} {Nachname.Value} ({Benutzername.Value})";
            return kurzschreibweise.Replace("  ", " ").Trim();
        }
    }
}
