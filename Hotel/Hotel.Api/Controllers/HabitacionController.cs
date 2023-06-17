using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Hotel.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class HabitacionController : ControllerBase
        {

            private readonly IHabitacionRepository habitacionRepository;


            public HabitacionController(IHabitacionRepository habitacionRepository)
            {
                this.habitacionRepository = habitacionRepository;
            }

            // GET: 
            [HttpGet]
            public IActionResult Get()
            {
                var habitacions = this.habitacionRepository.GetEntities();
                 return Ok(habitacions);
            }

            // GET
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var habitacion = this.habitacionRepository.GetEntity(id);
                return Ok(habitacion);
            }

            // POST 
            [HttpPost("{ADD}")]
            public IActionResult Post([FromBody] Habitacion habitacion)
            {
                this.habitacionRepository.Add(habitacion);
                return Ok(habitacion);
            }

            // PUT
            [HttpPut("{UPDATE}")]
            public IActionResult Put([FromBody] Habitacion habitacion)
            {
                this.habitacionRepository.Update(habitacion);
                return Ok(habitacion);
            }

            // DELETE
            [HttpDelete("{REMOVE}")]
            public IActionResult Delete([FromBody] Habitacion habitacion)
            {
                this.habitacionRepository.Remove(habitacion);
                return Ok(habitacion);
            }
        }
    }

