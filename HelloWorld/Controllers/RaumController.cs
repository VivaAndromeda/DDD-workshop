using HelloWorld.Application;
using HelloWorld.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RaumController : ControllerBase
    {
        private readonly IRaumRepository _raumRepository;
        private RaumAnlegenUseCase _raumAnlegenUseCase;

        public RaumController(IRaumRepository raumRepository)
        {
            _raumRepository = raumRepository;
            _raumAnlegenUseCase = new RaumAnlegenUseCase(raumRepository);
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult Get(string id)
        {
            _raumRepository.GetByRaumNummer(Raum);
            return Ok("Hello World!");
        }
    }
}
