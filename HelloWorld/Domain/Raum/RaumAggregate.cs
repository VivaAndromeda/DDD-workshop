using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Domain.Raum;

public class RaumAggregate
{
    public RaumId Id { get; } = new(Guid.NewGuid());
    public RaumName Name { get; } 
    public RaumNummer RaumNummer { get; }
    private readonly IList<PersonId> _personenIds = new List<PersonId>();

    private RaumAggregate(RaumNummer raumNummer, RaumName name)
    {
        RaumNummer = raumNummer;
        Name = name;
    }
    
    public static RaumAggregate? Create(string nummer, string name)
    {
        var raumNummer = RaumNummer.Create(nummer);
        if(raumNummer == null)
        {
            return null;
        }
        
        return new(raumNummer, new(name));
    }

    public void FuegePersonHinzu(PersonId personId)
    {
        if(_personenIds.Contains(personId))
        {
            return;
        }

        _personenIds.Add(personId);
    }

    public IReadOnlyList<PersonId> PersonenIdsInRaum()
    {
        return _personenIds.AsReadOnly();
    }
}
