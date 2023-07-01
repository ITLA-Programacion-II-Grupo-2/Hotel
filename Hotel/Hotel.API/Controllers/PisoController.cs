using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoRepository iPisoRepository;

        public PisoController(IPisoRepository iPisoRepository) 
        {
            this.iPisoRepository = iPisoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var piso = this.iPisoRepository.GetPiso();
            return Ok(piso);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var piso = this.iPisoRepository.GetPiso(id);
            return Ok (piso);
        }


        [HttpPost("SavePiso")]
        public IActionResult Post([FromBody] PisoAddDto pisoAddDto)
        {
            this.iPisoRepository.Add(new Piso()
            {
             Descripcion=pisoAddDto.Descripcion,
             UsuarioCreacion=pisoAddDto.ChangeUser

            }); 
            return Ok();

        }


        [HttpPost("UpdatePiso")]
        public IActionResult Put([FromBody] PisoUpdateDto pisoUpdateDto)
        {
            this.iPisoRepository.Update(new Piso()
            {
                IdPiso=pisoUpdateDto.Idpiso,
                UsuarioModificacion=pisoUpdateDto.ChangeUser,
                FechaModificacion=pisoUpdateDto.ChangeDate,
                Descripcion=pisoUpdateDto.Descripcion

            });
            return Ok();

        }


        [HttpPost("RemovePiso")]
        public IActionResult Delete([FromBody] PisoRemoveDto pisoRemoveDto)
        {
            Piso PisoToDelete = new Piso()
            {
                IdPiso = pisoRemoveDto.Idpiso,
                UsuarioEliminacion=pisoRemoveDto.ChangeUser,
                FechaCreacion=pisoRemoveDto.ChangeDate,
                Estado=pisoRemoveDto.Estado

            };
            this.iPisoRepository.Remove(PisoToDelete);
            return Ok();
        }
    }
}
