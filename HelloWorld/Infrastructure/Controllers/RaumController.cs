using HelloWorld.Application;
using HelloWorld.Domain;
using HelloWorld.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Infrastructure.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RaumController : ControllerBase
    {
        private readonly IRaumRepository _raumRepository;
        private readonly RaumAnlegenUseCase _raumAnlegenUseCase;

        public RaumController(IRaumRepository raumRepository)
        {
            _raumRepository = raumRepository;
            _raumAnlegenUseCase = new RaumAnlegenUseCase(raumRepository);
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult Get(Guid id)
        {
            var raum = _raumRepository.GetById(id);
            if (raum == null)
            {
                return BadRequest();
            }

            return Ok(raum);
        }

        [HttpPost]
        public IActionResult Post(CreateRaumDTO raumDto)
        {
            var raum = raumDto.ToDomain();
            if (raum == null)
            {
                return BadRequest();
            }

            _raumAnlegenUseCase.Create(raum);
            return Ok(raum);
        }
    }
}
