using Hotel.Application.Contract;
using Hotel.Application.Dtos.EstadoHabitacion;
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
        private readonly IEstadoHabitacionService estadoHabitacionService;


        public EstadoHabitacionController(IEstadoHabitacionService estadoHabitacionService)
        {
            this.estadoHabitacionService = estadoHabitacionService;
        }

        // GET:
        [HttpGet]
        public IActionResult Get()
        {
            var estadoHabitacions = this.estadoHabitacionService.GetEntities();
            return Ok(estadoHabitacions);
        }

        // GET [Id]: 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estadoHabitacion = this.estadoHabitacionService.Get(id);
            return Ok(estadoHabitacion);
        }

        // ADD:  
        [HttpPost("{ADD}")]
        public IActionResult Post([FromBody] EstadoHabitacionAddDto estadoHabitacionAdd)
        {
            this.estadoHabitacionService.Add(estadoHabitacionAdd);
            return Ok();
        }

        // UPDATE 
        [HttpPut("{UPDATE}")]
        public IActionResult Put([FromBody] EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            this.estadoHabitacionService.Update(estadoHabitacionUpdate);
            return Ok();
        }

        // DELETE 
        [HttpDelete("{REMOVE}")]
        public IActionResult Delete([FromBody] EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {
            this.estadoHabitacionService.Remove(estadoHabitacionRemove);
            return Ok();
        }
    }
}
