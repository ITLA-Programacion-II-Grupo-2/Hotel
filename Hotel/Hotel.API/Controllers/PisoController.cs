using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoRepository iPisoRepository;

        public PisoController(IPisoRepository iPisoRepository) 
        {
            this.iPisoRepository = iPisoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var piso = this.iPisoRepository.GetPiso();
            return Ok(piso);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var piso = this.iPisoRepository.GetPiso(id);
            return Ok (piso);
        }


        [HttpPost("SavePiso")]
        public void Post([FromBody] Piso piso)
        {
        }


        [HttpPost("UpdatePiso")]
        public void Put([FromBody] Piso piso)
        {
        }


        [HttpPost("Remove ")]
        public void Delete([FromBody] Piso piso)
        {
        }
    }
}
