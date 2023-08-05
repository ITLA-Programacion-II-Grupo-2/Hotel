using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Contract;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;



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
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = this.estadoHabitacionService.Get();
            return Ok(result);
        }

        // GET [Id]: 
        [HttpGet("{id}")]
        public IActionResult Get( int id)
        {
            var result = this.estadoHabitacionService.GetById(id);
            return Ok(result);
        }

        // ADD:  
        [HttpPost("Add")]
        public IActionResult Post([FromBody] EstadoHabitacionAddDto estadoHabitacionAdd)
        {
            this.estadoHabitacionService.Add(estadoHabitacionAdd);
            return Ok();
        }

        // UPDATE 
        [HttpPut("Update")]
        public IActionResult Put([FromBody] EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            var result = this.estadoHabitacionService.Update(estadoHabitacionUpdate);

            return Ok(result);
        }

        // DELETE 
        [HttpDelete]
        public IActionResult Delete([FromBody] EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {
            var result = this.estadoHabitacionService.Remove(estadoHabitacionRemove);
            return Ok(result);
        }
    }
}
