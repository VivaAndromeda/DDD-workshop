using HelloWorld.Application;
using HelloWorld.Domain;
using HelloWorld.Infrastructure.Controllers.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Infrastructure.Controllers
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
        public IActionResult Post(CreatePersonDTO personDto)
        {
            var erzeugePersonUseCase = new ErzeugePersonUseCase(_personRepository);
            var ergebnis = erzeugePersonUseCase.Erzeuge(personDto.ToDomain());

            return ergebnis switch
            {
                FehlerErgebnis fehlerErgebnis => BadRequest(fehlerErgebnis.Fehlermeldung),
                PersonErfolgsErgebnis personErfolgsErgebnis => Ok(personErfolgsErgebnis.Person),
                _ => BadRequest()
            };
        }
    }
}
