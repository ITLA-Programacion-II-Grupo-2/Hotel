using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Hotel.Infrastructure.Repositories
    {
        public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
        {
            private readonly ILogger logger;
            private readonly HotelContext context;

            public CategoriaRepository(ILogger<CategoriaRepository> logger, HotelContext context) : base(context)
            {
                this.logger = logger;
                this.context = context;
            }
            public List<CategoriaModels> GetCategoria(int id)
            {
                List<CategoriaModels> categorias = new List<CategoriaModels>();

                try
                {

                    this.logger.LogInformation($"Pase por aqui: {id}");

                    var categorias1 = (from categoria in GetEntities()
                                       where categoria.IdCategoria == id
                                       select new CategoriaModels
                                       {
                                           IdCategoria = categoria.IdCategoria,
                                           Descripcion = categoria.Descripcion,

                                       }).ToList();

                }
                catch (Exception ex)
                {

                    this.logger.LogError($"Error obeteniendo las categorias: {ex.Message}", ex.ToString());

                }
                return categorias;
            }


        }

    
}
      

