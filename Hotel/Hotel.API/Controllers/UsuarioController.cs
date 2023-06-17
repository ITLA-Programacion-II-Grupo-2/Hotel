using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository iUsuarioRepository;


        public UsuarioController(IUsuarioRepository iUsuarioRepository)
        {
            this.iUsuarioRepository = iUsuarioRepository;

        }


        [HttpGet]
        //public IActionResult Get()
        //{
        //    var usuario = this.iUsuarioRepository.GetUsuario(()
        //    return Ok(usuario); 
        //}

      
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        [HttpPost("SaveUsuario")]
        public void Post([FromBody] Usuario usuario)
        {
        }


        [HttpPost("UpdateUsuario")]
        public void Put([FromBody] Usuario usuario)
        {
        }

        [HttpPost("Remove ")]
        public void Delete([FromBody] Usuario usuario)
        {
        }
    }
}
