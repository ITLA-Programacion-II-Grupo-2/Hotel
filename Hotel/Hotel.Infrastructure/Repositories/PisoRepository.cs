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
    public class PisoRepository : BaseRepository<Piso>, IPisoRepository
    {
        private readonly ILogger logger;
        private readonly HotelContext context;

        public PisoRepository(ILogger<PisoRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public override void Add(Piso pisos)
        {
            try
            {
                string? piso = pisos.Descripcion;
                this.logger.LogInformation($"Añadiendo rol: {piso}");

                if (!Exists(p => p.Descripcion == pisos.Descripcion))
                {
                    base.Add(pisos);
                    base.SaveChanges();
                }
                else
                {
                    throw new PisoException($"El piso: {pisos.Descripcion} ya existe.");

                }

            }
            catch (PisoException ex)
            {
                this.logger.LogError(ex.Message);
            }

            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar un piso: " + ex.Message, ex.ToString());
            
            }
            
        }

        
        public override void Add(Piso[] pisos)
        {

                 try
                 {
                     foreach (Piso piso in pisos)
                     {
                         string? pisos1 = piso.Descripcion;
                         this.logger.LogInformation($"Añadiendo un Piso: {pisos1}");

                         if (!this.Exists(u => u.Descripcion == pisos1))
                         {
                              base.Add(piso);
                         }

                     }
                    base.SaveChanges();

                 }
                catch (PisoException ex)
                 {
                this.logger.LogError(ex.Message);
                 }
                catch(Exception ex)
                 {
                    this.logger.LogError("Error al agregar un piso: " + ex.Message, ex.ToString());
                 }

        } 




        public override void Update(Piso pisos)
        {

            try 
            {
              logger.LogInformation($"Actualizando Piso con ID: {pisos.IdPiso}");

                base.Update(pisos);
                base.SaveChanges();

            }
            catch (PisoException ex)
            { 
                logger.LogError("Error al actualizar Piso: " + ex.Message, ex.ToString());
            
           
            }
        }


        public override void Update(Piso[] pisos)
        {
            try 
            {
                logger.LogInformation("Actualizando Piso");

                foreach (var piso in pisos)
                {
                    try 
                    {
                        logger.LogInformation($"Actualizando Categoria con ID: {piso.IdPiso}");
                        base.Update(pisos);
                    }
                    catch (Exception ex) 
                    {
                        logger.LogError ("Error al actualizar Piso con ID: " + piso.IdPiso + ex.Message, ex.ToString());
                    
                    }
                    base.SaveChanges() ;  
                
                }
               
            }
            catch (Exception ex) 
            {
                logger.LogError("Error al actualizar Piso..." + ex.Message, ex.ToString());
            
            }
            
        }



        public override void Remove(Piso pisos)
        {
            try 
            {

                logger.LogInformation($"Eliminando Piso con ID: {pisos.IdPiso}");
                base.Remove(pisos);
                base.SaveChanges();

            }
            catch (PisoException ex)
            {
                logger.LogError("Error al eliminar Piso: " + ex.Message, ex.ToString());
            
            }
               
        }


        public override void Remove(Piso[] pisos)
        {

            try
            {
                foreach(var piso in pisos)
                {
                    try 
                    {
                        logger.LogInformation($"Eliminando Piso con ID: {piso.IdPiso}");
                        base.Remove(pisos);
                        base.Remove(pisos);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar Piso con ID: " + piso.IdPiso + ex.Message, ex.ToString());
                    }
                    base.SaveChanges();
                }

            } 
            catch (Exception ex) 
            {
                logger.LogError("Error al eliminar una Piso: " + ex.Message, ex.ToString());
            }
          
        }
        



        public List<PisoModels> GetPiso(int id)
        {
             List<PisoModels> pisos = new List<PisoModels>();
            try
            {
                this.logger.LogInformation($"Pase por aqui: {id}");

                 pisos = (from piso in GetEntities()
                              select new PisoModels
                              {
                                  IdPiso = piso.IdPiso,
                                  Descripcion  = piso.Descripcion

                              }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo los pisos: {ex.Message}", ex.ToString());

            }
            return pisos;


        }

    }

}