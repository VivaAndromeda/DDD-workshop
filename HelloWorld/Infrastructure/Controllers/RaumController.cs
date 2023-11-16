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
    private readonly RaumAnlegenUseCase _raumAnlegenUseCase;
    private readonly PersonZuRaumHinzufuegenUseCase _personHinzufuegenUseCase;

    public RaumController(IRaumRepository raumRepository)
    {
        _raumRepository = raumRepository;
        _personHinzufuegenUseCase = new PersonZuRaumHinzufuegenUseCase(raumRepository);
        _raumAnlegenUseCase = new RaumAnlegenUseCase(raumRepository);
    }

    [HttpGet]
    [Route("[controller]/{id}")]
    public IActionResult Get(Guid id)
    {
        Raum? raum = _raumRepository.GetById(id);
        if(raum == null)
        {
            return BadRequest();
        }

        LeseRaumDto raumErgebnis = LeseRaumDto.FromDomain(raum);
        return Ok(raumErgebnis);
    }

    [HttpPost]
    public IActionResult Post(CreateRaumDTO raumDto)
    {
        Raum? raum = raumDto.ToDomain();
        if(raum == null)
        {
            return BadRequest();
        }

        _raumAnlegenUseCase.Create(raum);
        return Ok(raum);
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

        Person? person = personDto.ToDomain();
        if(person == null)
        {
            return BadRequest();
        }

        Ergebnis ergebnis = _personHinzufuegenUseCase.Hinzufuegen(id, person);
        if(ergebnis is FehlerErgebnis fehlerErgebnis)
        {
            return BadRequest(fehlerErgebnis.Fehlermeldung);
        }

        return Ok();
    }
}
