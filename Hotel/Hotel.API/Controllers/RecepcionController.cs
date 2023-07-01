using Hotel.Application.Dto.Recepcion;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {

        private readonly IRecepcionRepository iRecepcionRepository;


        public RecepcionController(IRecepcionRepository iRecepcionRepository)
        {
            this.iRecepcionRepository = iRecepcionRepository;
        }


        [HttpGet("GetRecepcion")]
        public IActionResult Get()
        {
            var recepcion = this.iRecepcionRepository.GetRecepcion();
            return Ok(recepcion);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recepcion = this.iRecepcionRepository.GetRecepcion(id);
            return Ok(recepcion);
        }


        [HttpPost("SaveRecepcion")]
        public IActionResult Post([FromBody] RecepcionAddDto recepcionAddDto)
        {
            this.iCategoriaRepository.Add(new Recepcion()
            {
                Descripcion = recepcionAddDto.Descripcion,
                UsuarioCreacion = recepcionAddDto.ChangeUser,

            });
            return Ok();

        }


        [HttpPost("UpdateRecepcion")]
        public IActionResult Put([FromBody] RecepcionUpdateDto recepcionUpdate)
        {
            this.iRecepcionRepository.Update(new Recepcion()
            {
                IdRecepcion = recepcionUpdate.IdRecepcion,
                UsuarioModificacion = recepcionUpdate.IdRecepcion,
                FechaModificacion = recepcionUpdate.IdRecepcion


            });
            return Ok();

        }

        [HttpPost("RemoveRecepcion ")]
        public IActionResult Delete([FromBody] RecepcionRemoveDto recepcionRemove)
        {
            this.iRecepcionRepository.Remove(new Recepcion()
            {
                IdRecepcion = recepcionRemove.IdRecepcion,
                Estado = recepcionRemove.Estado,

            });
            return Ok();
        }
    }
}