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

        [HttpGet("GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = this.iUsuarioRepository.GetUsuario(id);
            return Ok(usuario);
        }

        [HttpGet("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            var usuarios = this.iUsuarioRepository.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioWithRol")]
        public IActionResult GetUsuarioWithRol(int id)
        {
            var usuarios = this.iUsuarioRepository.GetUsuarioWithRol(id);
            return Ok(usuarios);
        }

        [HttpGet("GetUsuariosWithRol")]
        public IActionResult GetUsuariosWithRol()
        {
            var usuarios = this.iUsuarioRepository.GetUsuariosWithRol();
            return Ok(usuarios);
        }
              
        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            this.iUsuarioRepository.Add(usuario);
            return Ok();
        }


        [HttpPost("UpdateUsuario")]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            this.iUsuarioRepository.Add(usuario);
            return Ok();
        }

        /*
        [HttpPost("RemoveUsuario")]
        public IActionResult Delete([FromBody] Usuario usuario)
        {
            return Ok();
        }
        */
    }
}
