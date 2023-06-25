using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RolUsuario;
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
        private readonly IRolUsuarioService iRolUsuarioService;

        public RolUsuarioController(IRolUsuarioService iRolUsuarioService)
        {
            this.iRolUsuarioService = iRolUsuarioService;
        }

        [HttpGet("GetRolesUsuario")]
        public IActionResult GetRolUsuarios()
        {
            var result = this.iRolUsuarioService.GetRolUsuarios();

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

        [HttpPost("SaveRolesUsuario")]
        public IActionResult Post([FromBody] RolUsuarioAddDto[] models)
        {
            var result = this.iRolUsuarioService.Add(models);

            return HandleResponse(result);
        }

        [HttpPost("UpdateRolUsuario")]
        public IActionResult Put([FromBody] RolUsuarioUpdateDto model)
        {
            var result = this.iRolUsuarioService.Update(model);
            return HandleResponse(result);
        }

        [HttpPost("UpdateRolesUsuario")]
        public IActionResult Put([FromBody] RolUsuarioUpdateDto[] models)
        {
            var result = this.iRolUsuarioService.Update(models);
            return HandleResponse(result);
        }

        
        [HttpPost("RemoveRolUsuario")]
        public IActionResult Delete([FromBody] RolUsuarioRemoveDto model)
        {
            var result = this.iRolUsuarioService.Remove(model);
            return HandleResponse(result);
        }

        [HttpPost("RemoveRolesUsuario")]
        public IActionResult Delete([FromBody] RolUsuarioRemoveDto[] models)
        {
            var result = this.iRolUsuarioService.Remove(models);
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
