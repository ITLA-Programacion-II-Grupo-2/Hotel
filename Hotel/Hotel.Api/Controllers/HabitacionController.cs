using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Contract;
using Hotel.Application.Dtos.Habitacion;

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
        [HttpGet("Get")]
        public IActionResult Get()
            {
                var habitacions = this.habitacionService.Get();
                 return Ok(habitacions);
            }

            // GET
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var habitacion = this.habitacionService.GetById(id);
                return Ok(habitacion);
            }

            // POST 
            [HttpPost("Post")]
            public IActionResult Post([FromBody] HabitacionAddDto habitacionAdd)
            {
                var result = this.habitacionService.Add(habitacionAdd);
                return Ok(result);
            }

            // PUT
            [HttpPut("Put")]
            public IActionResult Put([FromBody] HabitacionUpdateDto habitacionUpdate)
            {
            var result = this.habitacionService.Update(habitacionUpdate);

            return Ok(result);
        }

            // DELETE
            [HttpDelete]
            public IActionResult Delete([FromBody] HabitacionRemoveDto habitacionRemove)
            {
            var result = this.habitacionService.Remove(habitacionRemove);
            return Ok(result);
        }
        }
    }

