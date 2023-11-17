﻿using HelloWorld.Application;
using HelloWorld.Application.Common;
using HelloWorld.Application.Raum;
using HelloWorld.Domain.Person;
using HelloWorld.Domain.Person.ValueObjects;
using HelloWorld.Domain.Raum;
using HelloWorld.Infrastructure.Person.Dtos;
using HelloWorld.Infrastructure.Raum.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Infrastructure.Raum;

[Route("api/room")]
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

    [HttpGet]
    [Route("[controller]/{id}")]
    public IActionResult Get(Guid id)
    {
        var zeigeRaumAnUseCase = new ZeigeRaumAnUseCase(_raumRepository, _personRepository);
        var ergebnis = zeigeRaumAnUseCase.HoleRaum(id);

        return ergebnis switch
        {
            RaumMitIdNichtVorhanden fehlerErgebnis => BadRequest(fehlerErgebnis.Fehlermeldung),
            HoleRaumErfolgreich holeRaumErfolgsErgebnis => Ok(LeseRaumDto.FromDomain(holeRaumErfolgsErgebnis)),
            _ => BadRequest()
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
            RaumnummerNichtEindeutig fehlerErgebnis => BadRequest(fehlerErgebnis.Fehlermeldung),
            RaumErfolgsErgebnis raumErfolgsErgebnis => Ok(raumErfolgsErgebnis.Raum),
            _ => BadRequest()
        };
    }

    [HttpPut]
    [Route("/{id}/person")]
    public IActionResult PutPerson(Guid id, PutPersonDto personDto)
    {
        var raum = _raumRepository.GetById(id);
        if(raum == null)
        {
            return BadRequest();
        }
        var personHinzufuegenUseCase = new PersonZuRaumHinzufuegenUseCase(_raumRepository, _personRepository);
        Ergebnis ergebnis = personHinzufuegenUseCase.Hinzufuegen(id, new PersonId(personDto.Id));

        return ergebnis switch
        {
            RaumMitIdNichtVorhanden raumNichtVorhanden => BadRequest(raumNichtVorhanden.Fehlermeldung),
            PersonMitIdNichtVorhanden personNichtVorhanden => BadRequest(personNichtVorhanden.Fehlermeldung),
            _ => Ok()
        };
    }
}
