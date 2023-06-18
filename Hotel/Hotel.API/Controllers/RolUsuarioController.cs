using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IRolUsuarioRepository iRolUsuarioRepository;

        public RolUsuarioController(IRolUsuarioRepository iRolUsuarioRepository)
        {
            this.iRolUsuarioRepository = iRolUsuarioRepository;

        }

        [HttpGet("GetRolesUsuario")]
        public IActionResult GetRolUsuarios()
        {
            var rolusuario = this.iRolUsuarioRepository.GetRolUsuarios();

            return Ok(rolusuario);
        }

        [HttpGet("GetUsuariosByRol")]
        public IActionResult GetUsuariosByRol(string rol)
        {
            var usuarios = this.iRolUsuarioRepository.GetUsuariosByRol(rol);
            return Ok(usuarios);
        }

        [HttpGet("GetUsuariosByRoles")]
        public IActionResult GetUsuariosByRoles()
        {
            var usuarios = this.iRolUsuarioRepository.GetUsuariosByRoles();
            return Ok(usuarios);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] RolUsuario rolusuario)
        {
            this.iRolUsuarioRepository.Add(rolusuario);
            return Ok();
        }

        [HttpPost("UpdateRolUsuario")]
        public IActionResult Put([FromBody] RolUsuario rolusuario)
        {
            this.iRolUsuarioRepository.Update(rolusuario);
            return Ok();
        }

        /*
        [HttpPost("RemoveRolUsuario")]
        public void Delete([FromBody] RolUsuario rolusuario)
        {

        }
        */
    }
}
