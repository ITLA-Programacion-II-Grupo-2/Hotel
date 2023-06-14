using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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


        //añade y verifica si existe 
        public override void Add(Categoria categorias)
        {

            try
            {
                string? categoria = categorias.Descripcion;
                this.logger.LogInformation($"Añadiendo Categoria: {categoria}");

                if (!this.Exists(u => u.Descripcion == categoria))
                {
                    base.Add(categorias);
                    base.SaveChanges();

                }
                else
                {
                    throw new CategoriaException($" Categoria: {categoria} ya existe.");
                }


            }
            catch (CategoriaException ex)
            {
                this.logger.LogError(ex.Message);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar una Categoria: " + ex.Message, ex.ToString());
            }


        }

        //verifica si existe y elimina 
        public override void Add(Categoria[] categorias)
        {

            try
            {

                foreach (var cat in categorias)
                {

                    string? categoria = cat.Descripcion;
                    this.logger.LogInformation($"Añadiendo una Categoria: {categoria}");

                    if (!this.Exists(u => u.Descripcion == categoria))
                    {
                        base.Add(cat);
                    }


                }
                base.SaveChanges();

            }
            catch (CategoriaException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar una Categoria:" + ex.Message, ex.ToString());
            }


        }


        public override void Update(Categoria categoria)
        {

            try 
            {
               logger.LogInformation($"Actualizando Categoria con ID: {categoria.IdCategoria}");

                base.Update(categoria);
                base.SaveChanges(); 
            }
            catch (CategoriaException ex) 
            {
            
               logger.LogError("Error al actualizar Categoria: " + ex.Message, ex.ToString());
                
            }
         
        }

        public override void Update(Categoria[] categoria)
        {
            try
            {
                logger.LogInformation("Actualizando Categorias");

                foreach (var cat in categoria)
                {
                    try 
                    {
                        logger.LogInformation($"Actualizando Categoria con ID: {cat.IdCategoria}");
                        base.Update(categoria);

                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar RolUsuario con ID: " + cat.IdCategoria + ex.Message, ex.ToString());
                    }
                    base.SaveChanges();
                }
                 
            }
            catch (Exception ex) 
            {
                logger.LogError("Error al actualizar Categoria..." + ex.Message, ex.ToString());

            }
           
        }

        public override void Remove(Categoria categoria)
        {
            try
            {
                logger.LogInformation($"Eliminando Categoria con ID: {categoria.IdCategoria}");
                base.SaveChanges();
                base.Remove(categoria);
            }


            catch (Exception ex)
            {
                logger.LogError("Error al eliminar Categoria: " + ex.Message, ex.ToString());
            }
           
        }

        public override void Remove(Categoria[] categoria)
        {
            logger.LogInformation("Eliminando Categoria");
            try
            {

                foreach (var cat in categoria)
                {
                    try
                    {
                        logger.LogInformation($"Eliminando Categoria con ID: {cat.IdCategoria}");
                        base.Remove(categoria);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar Categoria con ID: " + cat.IdCategoria + ex.Message, ex.ToString());
                    }
                    base.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar una categoria: " + ex.Message, ex.ToString());
            
            }   
           
        }


        //lista de descripcion por id 
        public List<CategoriaModels> GetCategoria(int id)
        {
            List<CategoriaModels> categorias = new List<CategoriaModels>();

            try
            {

                this.logger.LogInformation($"Pase por aqui: {id}");

                categorias = (from categoria in GetEntities()
                              where categoria.IdCategoria == id
                              select new CategoriaModels
                              {
                                  IdCategoria = categoria.IdCategoria,
                                  Descripcion = categoria.Descripcion,

                              }).ToList();

            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo las Categorias: {ex.Message}", ex.ToString());

            }
            return categorias;
        }


    }


}


