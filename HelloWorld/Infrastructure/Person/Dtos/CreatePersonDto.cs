using HelloWorld.Domain.Person;

namespace HelloWorld.Infrastructure.Person.Dtos;

public class CreatePersonDto
{
    public string Vorname { get; set; } = string.Empty;

    public string Nachname { get; set; } = string.Empty;

    public string Benutzername { get; set; } = string.Empty;

    public string? Namenszusatz { get; set; }

    public PersonAggregate? ToDomain()
    {
        return PersonAggregate.Erzeuge(Vorname, Nachname, Benutzername, Namenszusatz);
    }
}