namespace HelloWorld.Domain
{
    public class Raum
    {
        public Raum()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public RaumNummer RaumNummer { get; set; }
    }
}
