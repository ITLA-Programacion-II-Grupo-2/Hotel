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

      
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


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
