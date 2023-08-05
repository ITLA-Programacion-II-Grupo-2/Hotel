using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
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


        
        public override void Add(Categoria categorias)
        {

            try
            {
                string? categoria = categorias.Descripcion;
                this.logger.LogInformation($"Añadiendo Categoria: {categoria}");

                if (!this.Exists(u => u.Descripcion == categoria && u.Estado == true))
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
                logger.LogInformation($"actualizando categoria con id: {categoria.IdCategoria}");

                Categoria CategoriaUpdate = base.GetEntity(categoria.IdCategoria);

                CategoriaUpdate.FechaModificacion = DateTime.Now;
                CategoriaUpdate.UsuarioModificacion = categoria.UsuarioModificacion;
                CategoriaUpdate.Descripcion = categoria.Descripcion;

                base.Update(CategoriaUpdate);
                base.SaveChanges();
            }catch (Exception ex)
            {
                logger.LogError("error al actualizar categoria: " + ex.Message, ex.ToString());
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
                logger.LogInformation($"eliminando categoria con id: {categoria.IdCategoria}");
                Categoria CategoriaRemove = base.GetEntity(categoria.IdCategoria);

                CategoriaRemove.Estado = false; 
                CategoriaRemove.FechaEliminacion = DateTime.Now;
                CategoriaRemove.UsuarioEliminacion = categoria.UsuarioEliminacion;

                base.Update(CategoriaRemove);
                base.SaveChanges();
             }


             catch (Exception ex)
             {
                 this.logger.LogError("Ocurrió un error actualizando la categoria" + ex.Message, ex.ToString());
             } 
           

        }

        public override void Remove(Categoria[] categorias)
        {
            logger.LogInformation("Eliminando Categoria");
            try
            {

                foreach (var categoria in categorias)
                {
                    try
                    {
                        logger.LogInformation($"Eliminando Categoria con ID: {categoria.IdCategoria}");

                        Categoria CategoriaRemove = base.GetEntity(categoria.IdCategoria);

                        CategoriaRemove.Estado = false;
                        CategoriaRemove.FechaEliminacion = DateTime.Now;
                        CategoriaRemove.UsuarioEliminacion = categoria.UsuarioEliminacion;
                        
                        base.Update(categoria);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar Categoria con ID: " + categoria.IdCategoria + ex.Message, ex.ToString());
                    }
                    
                    base.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar una categoria: " + ex.Message, ex.ToString());

            }

        }
       
        public CategoriaModels GetCategoria(int id)
        {
            CategoriaModels categoria = new CategoriaModels();

            try
            {
                this.logger.LogInformation($"Pase por aqui: {id}");

                categoria = (from cat in GetEntities()
                              where cat.IdCategoria == id && cat.Estado == true
                              select new CategoriaModels()
                              {
                                  IdCategoria = cat.IdCategoria,
                                  Descripcion = cat.Descripcion
                              }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error obeteniendo las Categorias: {ex.Message}", ex.ToString());
            }
            return categoria;
        }

        public List<CategoriaModels> GetCategoria()
        {
            List<CategoriaModels> categorias = new List<CategoriaModels>();

            try 
            {
                this.logger.LogInformation($"Consultado categorias...");

                categorias = (from categoria in GetEntities()
                              where categoria.Estado == true
                              select new CategoriaModels()
                              {
                                  IdCategoria = categoria.IdCategoria,
                                  Descripcion = categoria.Descripcion
                              }).ToList();



            }
            catch (Exception ex) 
            {
                this.logger.LogError($"Error al obtener las categorías: {ex.Message}", ex.ToString());

            }
            return categorias;






        }
    }


}


