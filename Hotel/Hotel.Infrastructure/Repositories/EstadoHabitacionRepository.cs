using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Hotel.Domain.Core;

namespace Hotel.Infrastructure.Repositories
{
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion>, IEstadoHabitacionRepository
    {
        private readonly ILogger<EstadoHabitacionRepository> logger;
        private readonly HotelContext context;

        public EstadoHabitacionRepository(ILogger<EstadoHabitacionRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<EstadoHabitacion> GetAll(int Id, List<EstadoHabitacion> estados)
        {
            List<EstadohabitacionModels> Estados = new List<EstadohabitacionModels>();

            try
            {

                this.logger.LogInformation($"Consultando.....");

                Estados = (from Es in base.GetEntities()
                                join Ha in context.EstadoHabitacion.ToList() on Es.IdEstadoHabitacion equals Ha.IdEstadoHabitacion
                                where Es.IdEstadoHabitacion == Ha.IdEstadoHabitacion
                                select new EstadohabitacionModels()
                                {
                                    IdHabitacion = Ha.IdHabitacion,
                                    IdEstadoHabitacion = Ha.IdEstadoHabitacion,
                                    Descripcion = Es.Descripcion,


                                }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error Al Mostrar Los Estados: {ex.Message}", ex.ToString());
            }

            return estados;
        }
        public override void Add(EstadoHabitacion estadoHabitacion)
        {
            try
            {
                string? Descripcion = estadoHabitacion.Descripcion;

                this.logger.LogInformation($"Añadiendo Estado De habitacion Con ID: {estadoHabitacion.IdEstadoHabitacion}");

                if (!this.Exists(E => E.Descripcion == Descripcion))
                {
                    base.Add(estadoHabitacion);
                    base.SaveChanges();
                }
                else
                {
                    throw new EstadohabitacionExcepcion($"El Estado Habitacion Con Id : {estadoHabitacion.IdEstadoHabitacion} ya existe.");
                }
            }
            catch (EstadohabitacionExcepcion ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar El Estado Habitacion: " + ex.Message, ex.ToString());
            }
        }
        public override void Add(EstadoHabitacion[] estadoHabitacions)
        {
            try
            {

                foreach (var estadoHabitacion in estadoHabitacions)
                {
                    string? Descripcion = estadoHabitacion.Descripcion;

                    this.logger.LogInformation($"Añadiendo Estado De habitacion con ID: {estadoHabitacion.IdEstadoHabitacion}");

                    if (!this.Exists(E => E.Descripcion == Descripcion))
                    {
                        base.Add(estadoHabitacions);
                        base.SaveChanges();
                    }
                    else
                    {
                        throw new EstadohabitacionExcepcion($"El Estado Habitacion Con ID: {estadoHabitacion.IdEstadoHabitacion} ya existe.");
                    }
                }

                base.SaveChanges();
            }
            catch (EstadohabitacionExcepcion ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar El Estado Habitacion: " + ex.Message, ex.ToString());
            }
        }
        public override void Update(EstadoHabitacion estadoHabitacion)
        {
            try
            {
                logger.LogInformation($"Actualizando el Estados De Habitacion con Id : {estadoHabitacion.IdEstadoHabitacion}");

                base.Update(estadoHabitacion);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al Actualizar El Estado De Habitaciones: " + ex.Message, ex.ToString());
            }
        }
        public override void Update(EstadoHabitacion[] estadoHabitacions)
        {
            logger.LogInformation($"Actualizando Los Estados De Habitaciones ");
            try
            {
                foreach (var EstadoHabitacion in estadoHabitacions)
                {
                    try
                    {
                        logger.LogInformation($"Actualizando El Estados De Habitacion Con ID : {EstadoHabitacion.IdEstadoHabitacion}");
                        base.Update(estadoHabitacions);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al Actualizar El Estado De Habitacion Con ID : " +EstadoHabitacion.IdEstadoHabitacion+ ex.Message, ex.ToString());
                    }

                    base.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar Los Estados..." + ex.Message, ex.ToString());
            }
        }
        public override void Remove(EstadoHabitacion estadoHabitacion)
        {
            try
            {
                logger.LogInformation($"Eliminando Estado de Habitacion con ID: {estadoHabitacion.IdEstadoHabitacion}");

                base.Remove(estadoHabitacion);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar El estado De Habitacion: " + ex.Message, ex.ToString());
            }
        }
        public override void Remove(EstadoHabitacion[] estadoHabitacions)
        {
            logger.LogInformation("Eliminando RolesUsuarios");
            try
            {
                foreach (var EstadoHabitacion in estadoHabitacions)
                {
                    try
                    {
                        logger.LogInformation($"Eliminando Estado de Habitacion con ID: {EstadoHabitacion.IdEstadoHabitacion}");
                        base.Remove(estadoHabitacions);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar Estado de Habitacion con ID: " + EstadoHabitacion.IdEstadoHabitacion + ex.Message, ex.ToString());
                    }
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar Estado De Habitacion: " + ex.Message, ex.ToString());
            }
        }

        public List<EstadoHabitacion> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
