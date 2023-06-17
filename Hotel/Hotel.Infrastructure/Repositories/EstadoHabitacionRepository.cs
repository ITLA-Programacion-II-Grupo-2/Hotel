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

        public override void Add(EstadoHabitacion entity)
        {
            if (this.Exists(E => E.Descripcion == entity.Descripcion))
            {
                base.Add(entity);
                base.SaveChanges();
            }
            else
            {
                throw new HabitacionException("La Habitacion Ya se Encuentra Reservada.");
            }
        }
       
        public override void Update(EstadoHabitacion entity)
        {
            try
            {

                base.Update(entity);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al Actualizar El Estado De Habitaciones: " + ex.Message, ex.ToString());
            }
        }
        
        public override void Remove(EstadoHabitacion entity)
        {
            try
            {

                base.Remove(entity);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar El estado De Habitacion: " + ex.Message, ex.ToString());
            }
        }
        
        public List<EstadohabitacionModel> GetEstadohabitacions()
        {
            List<EstadohabitacionModel> Estadohabitacions = new List<EstadohabitacionModel>();

            try
            {

                this.logger.LogInformation($"Consultando.....");

                Estadohabitacions = this.context.EstadoHabitacion
                                 .Where(E => !E.Estado).Select(Es => new EstadohabitacionModel()
                                 {
                               IdHabitacion = Es.IdHabitacion,
                               IdEstadoHabitacion = Es.IdEstadoHabitacion,
                               Descripcion = Es.Descripcion,


                           }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error Al Mostrar Los Estados: {ex.Message}", ex.ToString());
            }

            return Estadohabitacions;
        }

        public EstadohabitacionModel GetEstadohabitacionBy(int id)
        {
            EstadohabitacionModel estadohabitacionModel = new EstadohabitacionModel();


            try
            {
                EstadoHabitacion estadoHabitacion = this.GetEntity(id);

                estadohabitacionModel.IdHabitacion = estadoHabitacion.IdHabitacion;
                estadohabitacionModel.IdEstadoHabitacion = estadoHabitacion.IdEstadoHabitacion;
                estadohabitacionModel.Descripcion = estadoHabitacion.Descripcion;


            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el department", ex.ToString());
            }

            return estadohabitacionModel;
        }
    }
}
