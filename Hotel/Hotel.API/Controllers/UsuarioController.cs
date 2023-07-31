using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService iUsuarioService;

        public UsuarioController(IUsuarioService iUsuarioService)
        {
            this.iUsuarioService = iUsuarioService;
        }

        [HttpGet("GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            var result = this.iUsuarioService.GetById(id);

            return HandleResponse(result);
        }

        [HttpGet("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            var result = this.iUsuarioService.Get();

            return HandleResponse(result);
        }

        [HttpGet("GetUsuarioWithRol")]
        public IActionResult GetUsuarioWithRol(int id)
        {
            var result = this.iUsuarioService.GetUsuarioWithRol(id);

            return HandleResponse(result);
        }

        [HttpGet("GetUsuariosWithRol")]
        public IActionResult GetUsuariosWithRol()
        {
            var result = this.iUsuarioService.GetUsuariosWithRol();

            return HandleResponse(result);
        }
              
        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioAddDto model)
        {
            var result = this.iUsuarioService.Add(model);

            return HandleResponse(result);
        }

        [HttpPost("UpdateUsuario")]
        public IActionResult Put([FromBody] UsuarioUpdateDto model)
        {
            var result = this.iUsuarioService.Update(model);

            return HandleResponse(result);
        }

        [HttpPost("RemoveUsuario")]
        public IActionResult Delete([FromBody] UsuarioRemoveDto model)
        {
            var result = this.iUsuarioService.Remove(model);

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
