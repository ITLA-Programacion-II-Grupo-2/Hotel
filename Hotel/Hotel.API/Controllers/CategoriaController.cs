﻿using Hotel.Application.Dto.Categoria;
using Hotel.Domain.Entities;
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
        public IActionResult Post([FromBody] CategoriaAddDto categoriaAddDto)
        {
            this.iCategoriaRepository.Add(new Categoria()
            { 
              Descripcion=categoriaAddDto.Descripcion,
              UsuarioCreacion=categoriaAddDto.ChangeUser,

            });
            return Ok();

        }


        [HttpPost("UpdateCategoria")]
        public IActionResult Put([FromBody] CategoriaUpdateDto categoriaUpdate)
        {
            
            this.iCategoriaRepository.Update(new Categoria() 
            {
                IdCategoria=categoriaUpdate.IdCategoria,
                Descripcion=categoriaUpdate.Descripcion,
                UsuarioModificacion=categoriaUpdate.ChangeUser,
                FechaModificacion=categoriaUpdate.ChangeDate,

            });
            return Ok();

        }

        [HttpPost("RemoveCategoria ")]
        public IActionResult Delete([FromBody] CategoriaRemoveDto categoriaRemove)
        {
            this.iCategoriaRepository.Remove(new Categoria()
            {
                IdCategoria=categoriaRemove.IdCategoria,
               Estado=categoriaRemove.Estado,
                UsuarioEliminacion=categoriaRemove.ChangeUser,
                FechaEliminacion=categoriaRemove.ChangeDate

            });
            return Ok();
        }
    }
}
