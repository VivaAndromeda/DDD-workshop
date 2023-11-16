namespace HelloWorld.Domain
{
    public class Raum
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public RaumNummer RaumNummer { get; init; }
        /* Personen nicht zugänglich machen, sondern über Methode benutzbar.
        Personen nur als Kurzschreibweise rausgeben*/ 
        public IEnumerable<Person> Personen { get; } = new List<Person>();

        public Raum()
        {
            Id = Guid.NewGuid();
        }
    }
}
