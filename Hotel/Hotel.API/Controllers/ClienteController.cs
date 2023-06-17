using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            var cliente = this.clienteRepository.GetCliente();
            return Ok(cliente);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = this.clienteRepository.GetCliente(id);
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost("Save")]
        public void Post([FromBody] Cliente cliente)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPost("Update")]
        public void Put(int id, [FromBody] Cliente cliente)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{Remove}")]
        public void Delete([FromBody] Cliente cliente)
        {
        }
    }
}

//crear metodos de extension en DCO..//