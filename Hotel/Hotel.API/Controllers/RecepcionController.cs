using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private IRecepcionService iRecepcionService;

        public RecepcionController(IRecepcionService recepcionService)
        {
            this.iRecepcionService = recepcionService;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = this.iRecepcionService.GetById(id);

            return HandleResponse(result);
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = this.iRecepcionService.Get();

            return HandleResponse(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] RecepcionAddDto model)
        {
            var result = this.iRecepcionService.Add(model);

            return HandleResponse(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] RecepcionUpdateDto model)
        {
            var result = this.iRecepcionService.Update(model);

            return HandleResponse(result);
        }

        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] RecepcionRemoveDto model)
        {
            var result = this.iRecepcionService.Remove(model);

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
