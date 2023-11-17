using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Domain.Raum
{
    public class RaumAggregate
    {
        public RaumId Id { get; }
        public RaumName Name { get; set; }
        public RaumNummer RaumNummer { get; init; }
        private readonly IList<PersonId> _personenIds = new List<PersonId>();

        public RaumAggregate()
        {
            Id = new RaumId(Guid.NewGuid());
        }

        public void FuegePersonHinzu(PersonId personId)
        {
            if (_personenIds.Contains(personId))
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
}
