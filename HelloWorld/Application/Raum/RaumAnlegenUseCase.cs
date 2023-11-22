using HelloWorld.Application.Common;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;

namespace HelloWorld.Application.Raum;

public class RaumAnlegenUseCase
{
    private readonly IRaumRepository _raumRepository;

    public RaumAnlegenUseCase(IRaumRepository raumRepository)
    {
        _raumRepository = raumRepository;
    }

    public Ergebnis Create(RaumAggregate raum)
    {
        if(RaumnummerExistiertBereits(raum.RaumNummer))
        {
            return new RaumnummerNichtEindeutig(raum.RaumNummer);
        }

        _raumRepository.Save(raum);
        return new RaumAngelegt(raum);
    }

    private bool RaumnummerExistiertBereits(RaumNummer raumNummer)
    {
        return _raumRepository.Get(raumNummer) != null;
    }
}
