using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHabitacionController : ControllerBase
    {
        private readonly IEstadoHabitacionRepository estadoHabitacionRepository;


        public EstadoHabitacionController(IEstadoHabitacionRepository estadoHabitacionRepository)
        {
            this.estadoHabitacionRepository = estadoHabitacionRepository;
        }

        // GET:
        [HttpGet]
        public IActionResult Get()
        {
            var estadoHabitacions = this.estadoHabitacionRepository.GetEntities();
            return Ok(estadoHabitacions);
        }

        // GET [Id]: 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estadoHabitacion = this.estadoHabitacionRepository.GetEntity(id);
            return Ok(estadoHabitacion);
        }

        // ADD:  
        [HttpPost("{ADD}")]
        public IActionResult Post([FromBody] EstadoHabitacion estadoHabitacion)
        {
            this.estadoHabitacionRepository.Add(estadoHabitacion);
            return Ok();
        }

        // UPDATE 
        [HttpPut("{UPDATE}")]
        public IActionResult Put([FromBody] EstadoHabitacion estadoHabitacion)
        {
            this.estadoHabitacionRepository.Update(estadoHabitacion);
            return Ok();
        }

        // DELETE 
        [HttpDelete("{REMOVE}")]
        public IActionResult Delete([FromBody] EstadoHabitacion estadoHabitacion)
        {
            this.estadoHabitacionRepository.Remove(estadoHabitacion);
            return Ok();
        }
    }
}
