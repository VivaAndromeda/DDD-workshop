using HelloWorld.Domain.Raum;

namespace HelloWorld.Infrastructure.Raum.Dtos;

public record CreateRaumDto(string Nummer, string Name)
{
    public RaumAggregate? ToDomain()
    {
        return RaumAggregate.Create(Nummer, Name);
    }
}
