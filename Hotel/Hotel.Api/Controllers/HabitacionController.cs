using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Contract;
using Hotel.Application.Dtos.Habitacion;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;

namespace Hotel.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class HabitacionController : ControllerBase
        {

            private readonly IHabitacionService habitacionService;


            public HabitacionController(IHabitacionService habitacionService)
            {
                this.habitacionService = habitacionService;
            }

            // GET: 
            [HttpGet]
            public IActionResult Get()
            {
                var habitacions = this.habitacionService.GetEntities();
                 return Ok(habitacions);
            }

            // GET
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var habitacion = this.habitacionService.Get(id);
                return Ok(habitacion);
            }

            // POST 
            [HttpPost]
            public IActionResult Post([FromBody] HabitacionAddDto habitacionAdd)
            {
                var result = this.habitacionService.Add(habitacionAdd);
                return Ok(result);
            }

            // PUT
            [HttpPut]
            public IActionResult Put([FromBody] HabitacionUpdateDto habitacionUpdate)
            {
                this.habitacionService.Update(habitacionUpdate);
                return Ok(habitacionUpdate);
            }

            // DELETE
            [HttpDelete]
            public IActionResult Delete([FromBody] HabitacionRemoveDto habitacionRemove)
            {
                this.habitacionService.Remove(habitacionRemove);
                return Ok(habitacionRemove);
            }
        }
    }

