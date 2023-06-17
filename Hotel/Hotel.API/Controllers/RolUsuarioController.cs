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

        [HttpGet("GetRolUsuario")]
        public IActionResult Get()
        {
            var rolusuario = this.iRolUsuarioRepository.GetUsuariosByRoles();

            return Ok(rolusuario);
        }


        [HttpGet("UserByRol")]
        public IActionResult get(string rol)
        {
            var usuarios = this.iRolUsuarioRepository.GetUsuariosByRol(rol);
            return Ok(usuarios);
        }

        [HttpPost("SaveRolUsuario")]
        public void Post([FromBody] RolUsuario rolusuario)
        {
        }


        [HttpPost("UpdateRolUsuario")]
        public void Put([FromBody] RolUsuario rolusuario)
        {
        }

        [HttpPost("Remove ")]
        public void Delete([FromBody] RolUsuario rolusuario)
        {
        }
    }
}
