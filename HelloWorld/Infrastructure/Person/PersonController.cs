using HelloWorld.Application;
using HelloWorld.Application.Common;
using HelloWorld.Application.Person;
using HelloWorld.Domain.Person;
using HelloWorld.Infrastructure.Person.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Infrastructure.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        public IActionResult Post(CreatePersonDto personDto)
        {
            var erzeugePersonUseCase = new ErzeugePersonUseCase(_personRepository);
            var ergebnis = erzeugePersonUseCase.Erzeuge(personDto.ToDomain());

            return ergebnis switch
            {
                BenutzernameNichtEindeutig fehlerErgebnis => BadRequest(fehlerErgebnis.Fehlermeldung),
                PersonErfolgsErgebnis personErfolgsErgebnis => Ok(personErfolgsErgebnis.Person),
                _ => BadRequest()
            };
        }
    }
}
