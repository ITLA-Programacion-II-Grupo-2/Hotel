using Hotel.Application.Contract;
using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoServece ipisoServece;

        public PisoController(IPisoServece ipisoServece) 
        {
            this.ipisoServece = ipisoServece;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.ipisoServece.Get();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.ipisoServece.GetById(id);
            return Ok (result);
        }


        [HttpPost("SavePiso")]
        public IActionResult Post([FromBody] PisoAddDto pisoAddDto)
        {
            this.ipisoServece.Add(pisoAddDto);
            return Ok();
          
        }


        [HttpPost("UpdatePiso")]
        public IActionResult Put([FromBody] PisoUpdateDto pisoUpdateDto)
        {
            var result = this.ipisoServece.Update(pisoUpdateDto);
            return Ok(result);
           

        }


        [HttpPost("RemovePiso")]
        public IActionResult Delete([FromBody] PisoRemoveDto pisoRemoveDto)
        {
           var result = this.ipisoServece.Remove(pisoRemoveDto);
            return Ok(result);
        }
    }
}
