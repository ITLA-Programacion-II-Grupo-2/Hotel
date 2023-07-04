using Hotel.Application.Contract;
using Hotel.Application.Dto.Categoria;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
       
        private readonly ICategoriaService iCategoriaservice;

       
        public CategoriaController(ICategoriaService iCategoriaservice) 
        {
            this.iCategoriaservice = iCategoriaservice;
        }

       
            
        [HttpGet("GetCategoria")]
        public IActionResult Get()
        {
            var result = this.iCategoriaservice.Get();
            return Ok(result);
        }

      
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
              var result = this.iCategoriaservice.GetById(id);
              return Ok(result);
        }


        [HttpPost("SaveCategoria")]
        public IActionResult Post([FromBody] CategoriaAddDto categoriaAddDto)
        {
            this.iCategoriaservice.Add(categoriaAddDto);
            return Ok();

        }


        [HttpPost("UpdateCategoria")]
        public IActionResult Put([FromBody] CategoriaUpdateDto categoriaUpdate)
        {
            
           var result = this.iCategoriaservice.Update(categoriaUpdate);
            return Ok(result);

        }

        
       [HttpPost("RemoveCategoria")]
        public IActionResult Delete([FromBody] CategoriaRemoveDto categoriaRemove)
        {
          var result = this.iCategoriaservice.Remove(categoriaRemove);
            return Ok(result);  
        }
    }
}
