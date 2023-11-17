using HelloWorld.Domain.Person;

namespace HelloWorld.Infrastructure.Person.Dtos;

public record CreatePersonDto(
    string Vorname,
    string Nachname,
    string Benutzername,
    string? Namenszusatz
)
{
    public PersonAggregate? ToDomain()
    {
        return PersonAggregate.Erzeuge(Vorname, Nachname, Benutzername, Namenszusatz);
    }
}
