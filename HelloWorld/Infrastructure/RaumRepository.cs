using HelloWorld.Domain;

namespace HelloWorld.Infrastructure
{
    public class RaumRepository : IRaumRepository
    {
        List<Raum> raums = new();

        public Raum? GetByRaumNummer(RaumNummer raumNummer)
        {
            return raums.FirstOrDefault(x => x.RaumNummer == raumNummer);
        }

        public void Save(Raum raum)
        {
            raums.Add(raum);
        }

        public Raum? GetById(Guid id)
        {
            return raums.FirstOrDefault(x => x.Id == id);
        }
    }
}
