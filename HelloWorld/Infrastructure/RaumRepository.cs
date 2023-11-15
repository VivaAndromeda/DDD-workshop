using HelloWorld.Domain;

namespace HelloWorld.Infrastructure
{
    public class RaumRepository : IRaumRepository
    {
        List<Raum> raums = new List<Raum>();
        public Raum? GetByRaumNummer(RaumNummer raumNummer)
        {
            return raums.FirstOrDefault(x => x.RaumNummer == raumNummer);  
        }

        public IEnumerable<RaumNummer> GetRaumNummern()
        {
            return raums.Select(x => x.RaumNummer);
        }

        public void Save(Raum raum)
        {
            raums.Add(raum);
        }
    }
}
