using HelloWorld.Domain;

namespace HelloWorld.Infrastructure.DTOs;

public class CreatePersonDTO
{
    public string Vorname { get; set; } = string.Empty;

    public string Nachname { get; set; } = string.Empty;

    public string Benutzername { get; set; } = string.Empty;

    public string? Namenszusatz { get; set; }

    public Person ToDomain()
    {
        return Person.Erzeuge(Vorname, Nachname, Benutzername, Namenszusatz);
    }
}