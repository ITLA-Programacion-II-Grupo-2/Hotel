using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
       
        private readonly ICategoriaRepository iCategoriaRepository;

       
        public CategoriaController(ICategoriaRepository iCategoriaRepository) 
        {
            this.iCategoriaRepository = iCategoriaRepository;
        }

       
            
        [HttpGet("GetCategoria")]
        public IActionResult Get()
        {
           var categorias = this.iCategoriaRepository.GetCategoria();
            return Ok(categorias);
        }

      
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var categoria = this.iCategoriaRepository.GetCategoria(id);
            return Ok(categoria);
        }


        [HttpPost("SaveCategoria")]
        public void Post([FromBody] Categoria categoria)
        {
            

        }

        
        [HttpPost("UpdateCategoria")]
        public void Put([FromBody] Categoria categoria)
        {


        }

        [HttpPost("Remove ")]
        public void Delete([FromBody] Categoria categori)
        {

        }
    }
}
