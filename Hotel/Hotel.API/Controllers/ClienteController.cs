using Hotel.Application.Dtos.Cliente;
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
        public IActionResult GetCliente()
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


        // POST api/<ClienteController/ min36.04>
        [HttpPost("Save Cliente")]
        public IActionResult Post([FromBody] ClienteAddDto clienteAdd)
        {
            this.clienteRepository.Add(new Cliente() 
            {
             TipoDocumento = clienteAdd.TipoDocumento,
             Documento = clienteAdd.Documento,
             ClienteCreacion = clienteAdd.ClienteChange,
             FechaCreacion = clienteAdd.FechaChange
            });

            return Ok();
        }

        [HttpPost("Save Clientes")]
        public IActionResult Post([FromBody] Cliente[] clientes)
        {
            this.clienteRepository.Add(clientes);
            return Ok();
        }


        // PUT api/<ClienteController>/5
        [HttpPost("Update Cliente")]
        public IActionResult Put([FromBody] ClienteUpdateDto clienteUpdate)
        {
            Cliente clienteToUpdate = new Cliente()
            {
                IdCliente = clienteUpdate.IdCliente,
                TipoDocumento = clienteUpdate.TipoDocumento,
                Documento = clienteUpdate.Documento,
                ClienteModificacion = clienteUpdate.ClienteChange,
                FechaModificacion = clienteUpdate.FechaChange
            };
            this.clienteRepository.Update(clienteToUpdate);
            return Ok();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{Remove}")]
        public void Delete([FromBody] ClienteRemoveDto clienteRemoveDto)
        {
            //Cliente clienteToRemoveDto = new Cliente()
            //{
            //    IdCliente = clienteToRemoveDto.IdCliente,
            //    TipoDocumento = clienteToRemoveDto.TipoDocumento,
            //    Documento = clienteToRemoveDto.Documento,
            //    ClienteModificacion = clienteToRemoveDto.ClienteChange,
            //    FechaModificacion = clienteToRemoveDto.FechaChange
            //};
            //this.clienteRepository.Remove(clienteToRemove);
            //return Ok();
        }
    }
}


//crear metodos de extension en DCO.MIN 31.37.//