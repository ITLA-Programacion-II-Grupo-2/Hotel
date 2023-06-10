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


namespace Hotel.Infrastructure.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
    {
        private readonly ILogger<HabitacionRepository> logger;
        private readonly HotelContext context;

        public List<Habitacion> Habitaciones { get; private set; }

        public HabitacionRepository(ILogger<HabitacionRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<Habitacion> GetHabitacions(int Id)
        {
            return GetHabitacions(Id, Habitaciones);
        }

        public List<Habitacion> GetHabitacions(int Id, List<Habitacion> habitaciones)
        {
            List<HabitacionModels> Habitaciones = new List<HabitacionModels>();

            try
            {

                this.logger.LogInformation($"Consultando.....");

                Habitaciones = (from Ha in base.GetEntities()
                          join Es in context.EstadoHabitacion.ToList() on Ha.IdEstadoHabitacion equals Es.IdEstadoHabitacion
                          where Ha.IdEstadoHabitacion == Es.IdEstadoHabitacion
                          select new HabitacionModels()
                          {
                              IdHabitacion = Ha.IdHabitacion,
                              Detalle = Ha.Detalle,
                              Numero = Ha.Numero,
                              IdEstadoHabitacion = Es.IdEstadoHabitacion,
                              
                          }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error Al Mostrar Las Habitaciones: {ex.Message}", ex.ToString());
            }

            return habitaciones;
        }
    
        public override void Add(Habitacion habitacion)
        {
            try
            {
                string? Numero = habitacion.Numero;
                string? Detalle = habitacion.Detalle;

                this.logger.LogInformation($"Reservando Habtitacion Numero: {Numero}, Con los Detalles: {Detalle}");

                if (this.Exists(H => H.Numero == Numero))
                {
                    base.Add(habitacion);
                    base.SaveChanges();
                }
                else
                {
                    throw new HabitacionException("La Habitacion Ya se Encuentra Reservada.");
                }
            }
            catch (HabitacionException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al Reservar la Habitacion: " + ex.Message);
            }
            
        }
        public override void Add(Habitacion[] habitacions)
        {
            try
            {
                foreach (var Habitacion in Habitaciones)
                {
                    string? Numero = Habitacion.Numero;
                    string? Detalle = Habitacion.Detalle;

                    this.logger.LogInformation($"Añadiendo Habitacion Numero: {Numero}, Con Los Siguientes Detalles: {Detalle}...");

                    if (!this.Exists(H => H.Numero == Numero))
                    {
                        base.Add(Habitacion);
                    }
                    else
                    {
                        throw new HabitacionException($"La Habitacion Numero: {Numero} se encuentra en uso.");
                    }
                }

                base.SaveChanges();
            }
            catch (HabitacionException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al Reservar Habitacion: " + ex.Message, ex.ToString());
            }
        }
        public override void Remove(Habitacion habitacion)
        {
            try
            {
                logger.LogInformation($"Borrando Datos de Habitacion con ID: {habitacion.IdHabitacion}");

                base.Remove(habitacion);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al Eliminar Los Datos De la Habitacion: " + ex.Message, ex.ToString());
            }
        }
        public override void Remove(Habitacion[] habitacions)
        {
            try
            {
                foreach (var Habitacion in Habitaciones)
                {
                    try
                    {
                        logger.LogInformation($"Borrando Datos de Habitacion con ID: {Habitacion.IdHabitacion}");
                        base.Remove(Habitacion);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al Eliminar Los Datos De la Habitacion con ID: " +Habitacion.IdHabitacion+ ex.Message, ex.ToString());
                    }
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al Eliminar Los Datos De la Habitacion: " + ex.Message, ex.ToString());
            }
        }
        public override void Update(Habitacion habitacion)
        {
            try
            {
                logger.LogInformation($"Actualizando Habitacion Con ID: {habitacion.IdHabitacion}");

                base.Update(habitacion);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar La Habitacion Con ID : " + habitacion.IdHabitacion + ex.Message, ex.ToString());
            }
        }
        public override void Update(Habitacion[] habitacions)
        {
            logger.LogInformation("Actualizando Habitaciones");
            try
            {
                foreach (var Habitacion in habitacions)
                {
                    try
                    {
                        logger.LogInformation($"Actualizando Habitacion Con ID: {Habitacion.IdHabitacion}");
                        base.Update(Habitacion);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar La Habitacion Con ID : " + Habitacion.IdHabitacion + ex.Message, ex.ToString());
                    }
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar Habitaciones..." + ex.Message, ex.ToString());
            }
        }
        public List<Habitacion> GetHabitacions()
        {
            throw new NotImplementedException();
        }
    }
}
