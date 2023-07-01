using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.Extensions.Logging;



namespace Hotel.Infrastructure.Repositories
{
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {
        private readonly ILogger logger;
        private readonly HotelContext context;

        public RecepcionRepository(ILogger<RecepcionRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }



        public override void Add(Recepcion recepciones)
        {

            try
            {
                string? recepcion = recepciones.Descripcion;
                this.logger.LogInformation($"Añadiendo Recepcion: {recepcion}");

                if (!this.Exists(u => u.Descripcion == recepcion))
                {
                    base.Add(recepciones);
                    base.SaveChanges();

                }
                else
                {
                    throw new RecepcionException($" Recepcion: {recepcion} ya existe.");
                }


            }
            catch (RecepcionException ex)
            {
                this.logger.LogError(ex.Message);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar una Recepcion: " + ex.Message, ex.ToString());
            }


        }

        public override void Add(Recepcion[] recepciones)
        {

            try
            {

                foreach (var rec in recepciones)
                {

                    string? recepcion = rec.Descripcion;
                    this.logger.LogInformation($"Añadiendo una Recepcion: {recepcion}");

                    if (!this.Exists(u => u.Descripcion == recepcion))
                    {
                        base.Add(rec);
                    }


                }
                base.SaveChanges();

            }
            catch (RecepcionException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar una Recepcion:" + ex.Message, ex.ToString());
            }


        }

        public override void Update(Recepcion recepcion)
        {

            try
            {
                logger.LogInformation($"actualizando recepcion con id: {recepcion.IdRecepcion}");

                base.Update(recepcion);
                base.SaveChanges();
            }
            catch (RecepcionException ex)
            {

                logger.LogError("error al actualizar recepcion: " + ex.Message, ex.ToString());

            }

        }

        public override void Update(Recepcion[] recepcion)
        {
            try
            {
                logger.LogInformation("Actualizando Recepciones");

                foreach (var cat in recepcion)
                {
                    try
                    {
                        logger.LogInformation($"Actualizando Recepcion con ID: {cat.IdRecepcion}");
                        base.Update(recepcion);

                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar Recepcion con ID: " + cat.IdRecepcion + ex.Message, ex.ToString());
                    }
                    base.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar Recepcion..." + ex.Message, ex.ToString());

            }

        }

        public override void Remove(Recepcion recepcion)
        {
            try
            {
                Recepcion RecepcionRemove = base.GetEntity(Recepcion.IdRecepcion);
                RecepcionRemove.Estado = false;
                RecepcionRemove.FechaEliminacion = DateTime.Now;
                RecepcionRemove.UsuarioEliminacion = recepcion.UsuarioEliminacion;
                base.Update(RecepcionRemove);
                base.SaveChanges();
            }


            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando la recepcion", ex.ToString());
            }
            this.logger.LogInformation("Removerecepcion");

        }

        public override void Remove(Recepcion[] recepcion)
        {
            logger.LogInformation("Eliminando Recepcion");
            try
            {

                foreach (var cat in recepcion)
                {
                    try
                    {
                        logger.LogInformation($"Eliminando Recepcion con ID: {cat.IdRecepcion}");
                        base.Remove(recepcion);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar su Recepcion con ID: " + cat.IdRecepcion + ex.Message, ex.ToString());
                    }
                    base.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar una recepcion: " + ex.Message, ex.ToString());

            }

        }

        public List<RecepcionModels> GetRecepcion(int id)
        {
            List<RecepcionModels> recepcion = new List<RecepcionModels>();

            try
            {

                this.logger.LogInformation($"Pase por aqui: {id}");

                recepcion = (from recepcion in GetEntities()
                              where recepcion.IdRecepcion == id
                              select new RecepcionModels
                              {
                                  IdRecepcion = recepcion.IdRecepcion,
                                  Descripcion = recepcion.IdRecepcion,

                              }).ToList();

            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error en su Recepcion : {ex.Message}", ex.ToString());

            }
            return recepcion;
        }

        public List<RecepcionModels> GetCategoria()
        {
            List<RecepcionModels> categorias = new List<RecepcionModels>();

            try
            {
                this.logger.LogInformation($"Consultado categorias...");

                categorias = (from categoria in GetEntities()
                              select new RecepcionModels
                              {
                                  IdRecepcion = categoria.IdCategoria,
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


