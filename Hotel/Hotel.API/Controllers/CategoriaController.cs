using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Repositories;
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

        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var categorias = this.iCategoriaRepository.GetEntities();

            return new string[] { "value1", "value2" };
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
