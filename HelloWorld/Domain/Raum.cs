namespace HelloWorld.Domain
{
    public class Raum
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public RaumNummer RaumNummer { get; init; }
        /* Personen nicht zugänglich machen, sondern über Methode benutzbar.
        Personen nur als Kurzschreibweise rausgeben*/ 
        private IList<Guid> PersonenIds = new List<Guid>();

        public Raum()
        {
            Id = Guid.NewGuid();
        }

        public void FuegePersonHinzu(Guid personId)
        {
            if (PersonenIds.Contains(personId))
            {
                return;
            }

            PersonenIds.Add(personId);
        }

        public IReadOnlyList<Guid> PersonenIdsInRaum()
        {
            return PersonenIds.AsReadOnly();
        }
    }
}
