using Hotel.Application.Contract;
using Hotel.Application.Dto.Categoria;
using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure.Models;
using Hotel.Application.Extentions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
       
        private readonly ICategoriaService iCategoriaService;

       
        public CategoriaController(ICategoriaService iCategoriaService) 
        {
            this.iCategoriaService = iCategoriaService;
        }
            
        [HttpGet("GetCategoria")]
        public IActionResult GetCategoria()
        {
            var result = this.iCategoriaService.Get();
            return Ok(result);
        }
      
        [HttpGet("{id?}")]
        public IActionResult GetById(int id)
        {
            var result = this.iCategoriaService.GetById(id);
            return Ok(result);

        }

        [HttpPost("SaveCategoria")]
        public IActionResult Post([FromBody] CategoriaAddDto categoriaAddDto)
        {
            this.iCategoriaService.Add(categoriaAddDto);
            return Ok();

        }

        [HttpPost("UpdateCategoria")]
        public IActionResult Put([FromBody] CategoriaUpdateDto categoriaUpdate)
        {
            
           var result = this.iCategoriaService.Update(categoriaUpdate);
            return Ok(result);

        }
        
       [HttpPost("RemoveCategoria")]
        public IActionResult Delete([FromBody] CategoriaRemoveDto categoriaRemove)
        {
          var result = this.iCategoriaService.Remove(categoriaRemove);
            return Ok(result);  
        }
    }
}
