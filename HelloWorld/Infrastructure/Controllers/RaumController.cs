using HelloWorld.Application;
using HelloWorld.Domain;
using HelloWorld.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Infrastructure.Controllers;

[Route("api/room")]
[ApiController]
public class RaumController : ControllerBase
{
    private readonly IRaumRepository _raumRepository;
    private readonly IPersonRepository _personRepository;
    private readonly RaumAnlegenUseCase _raumAnlegenUseCase;
    private readonly PersonZuRaumHinzufuegenUseCase _personHinzufuegenUseCase;

    public RaumController(IRaumRepository raumRepository, IPersonRepository personRepository)
    {
        _raumRepository = raumRepository;
        _personRepository = personRepository;
        _personHinzufuegenUseCase = new PersonZuRaumHinzufuegenUseCase(raumRepository, personRepository);
        _raumAnlegenUseCase = new RaumAnlegenUseCase(raumRepository);
    }

    [HttpGet]
    [Route("[controller]/{id}")]
    public IActionResult Get(Guid id)
    {
        var zeigeRaumAnUseCase = new ZeigeRaumAnUseCase(_raumRepository, _personRepository);
        var ergebnis = zeigeRaumAnUseCase.HoleRaum(id);

        return ergebnis switch
        {
            FehlerErgebnis fehlerErgebnis => BadRequest(fehlerErgebnis.Fehlermeldung),
            HoleRaumErfolgsErgebnis holeRaumErfolgsErgebnis => Ok(LeseRaumDto.FromDomain(holeRaumErfolgsErgebnis)),
            _ => BadRequest()
        };
    }

    [HttpPost]
    public IActionResult Post(CreateRaumDTO raumDto)
    {
        Raum? raum = raumDto.ToDomain();
        if(raum == null)
        {
            return BadRequest();
        }

        var ergebnis = _raumAnlegenUseCase.Create(raum);
        return ergebnis switch
        {
            FehlerErgebnis fehlerErgebnis => BadRequest(fehlerErgebnis.Fehlermeldung),
            RaumErfolgsErgebnis raumErfolgsErgebnis => Ok(raumErfolgsErgebnis.Raum),
            _ => BadRequest()
        };
    }

    [HttpPut]
    [Route("/{id}/person")]
    public IActionResult PutPerson(Guid id, PutPersonDto personDto)
    {
        Raum? raum = _raumRepository.GetById(id);
        if(raum == null)
        {
            return BadRequest();
        }

        Ergebnis ergebnis = _personHinzufuegenUseCase.Hinzufuegen(id, personDto.Id);
        if(ergebnis is FehlerErgebnis fehlerErgebnis)
        {
            return BadRequest(fehlerErgebnis.Fehlermeldung);
        }

        return Ok();
    }
}
