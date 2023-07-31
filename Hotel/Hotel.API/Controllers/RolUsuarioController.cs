using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RolUsuario;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IRolUsuarioService iRolUsuarioService;

        public RolUsuarioController(IRolUsuarioService iRolUsuarioService)
        {
            this.iRolUsuarioService = iRolUsuarioService;
        }

        [HttpGet("GetRolUsuario")]
        public IActionResult GetRolUsuario(int id)
        {
            var result = this.iRolUsuarioService.GetById(id);

            return HandleResponse(result);
        }

        [HttpGet("GetRolesUsuario")]
        public IActionResult GetRolesUsuario()
        {
            var result = this.iRolUsuarioService.Get();

            return HandleResponse(result);
        }

        [HttpGet("GetUsuariosByRol")]
        public IActionResult GetUsuariosByRol(string rol)
        {
            var result= this.iRolUsuarioService.GetUsuariosByRol(rol);

            return HandleResponse(result);
        }

        [HttpGet("GetUsuariosByRoles")]
        public IActionResult GetUsuariosByRoles()
        {
            var result = this.iRolUsuarioService.GetUsuariosByRoles();

            return HandleResponse(result);
        }

        [HttpPost("SaveRolUsuario")]
        public IActionResult Post([FromBody]RolUsuarioAddDto rolUsuarioAddDto)
        {
            var result = this.iRolUsuarioService.Add(rolUsuarioAddDto);

            return HandleResponse(result);
        }

        [HttpPost("UpdateRolUsuario")]
        public IActionResult Put([FromBody] RolUsuarioUpdateDto model)
        {
            var result = this.iRolUsuarioService.Update(model);
            return HandleResponse(result);
        }

        [HttpPost("RemoveRolUsuario")]
        public IActionResult Delete([FromBody] RolUsuarioRemoveDto model)
        {
            var result = this.iRolUsuarioService.Remove(model);
            return HandleResponse(result);
        }

        private IActionResult HandleResponse(ServiceResult result)
        {
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

    }

}
