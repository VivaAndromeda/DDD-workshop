using HelloWorld.Application.Common;
using HelloWorld.Application.Raum;
using HelloWorld.Domain.Person;
using HelloWorld.Domain.Raum;
using HelloWorld.Domain.Raum.ValueObjecs;
using HelloWorld.Infrastructure.Person.Dtos;
using HelloWorld.Infrastructure.Raum.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Infrastructure.Raum;

[Route("api/[controller]")]
[ApiController]
public class RaumController : ControllerBase
{
    private readonly IRaumRepository _raumRepository;
    private readonly IPersonRepository _personRepository;

    public RaumController(IRaumRepository raumRepository, IPersonRepository personRepository)
    {
        _raumRepository = raumRepository;
        _personRepository = personRepository;
    }

    [HttpGet("{raumId:guid}")]
    public IActionResult Get(Guid raumId)
    {
        var zeigeRaumAnUseCase = new ZeigeRaumAnUseCase(_raumRepository, _personRepository);
        var ergebnis = zeigeRaumAnUseCase.HoleRaum(new(raumId));

        return ergebnis switch
        {
            RaumErmittelt erfolg => Ok(LeseRaumDto.FromDomain(erfolg)),
            RaumMitIdNichtVorhanden fehler => BadRequest(fehler.Fehlermeldung),
            var _ => BadRequest()
        };
    }

    [HttpPost]
    public IActionResult Post(CreateRaumDto raumDto)
    {
        var raum = raumDto.ToDomain();
        if(raum == null)
        {
            return BadRequest();
        }

        var raumAnlegenUseCase = new RaumAnlegenUseCase(_raumRepository);
        var ergebnis = raumAnlegenUseCase.Create(raum);
        return ergebnis switch
        {
            RaumAngelegt erfolg => Ok(erfolg.Raum),
            RaumnummerNichtEindeutig fehler => BadRequest(fehler.Fehlermeldung),
            var _ => BadRequest()
        };
    }

    [HttpPut("{raumId:guid}/person")]
    public IActionResult PutPerson(Guid raumId, PutPersonDto personDto)
    {
        var raum = _raumRepository.Get(new RaumId(raumId));
        if(raum == null)
        {
            return BadRequest();
        }

        var personHinzufuegenUseCase = new PersonZuRaumHinzufuegenUseCase(_raumRepository, _personRepository);
        var ergebnis = personHinzufuegenUseCase.Hinzufuegen(new(raumId), new(personDto.Id));

        return ergebnis switch
        {
            PersonHinzugefuegt erfolg => Ok(erfolg.Raum),
            RaumMitIdNichtVorhanden fehler => BadRequest(fehler.Fehlermeldung),
            PersonMitIdNichtVorhanden fehler => BadRequest(fehler.Fehlermeldung),
            var _ => BadRequest()
        };
    }
}
