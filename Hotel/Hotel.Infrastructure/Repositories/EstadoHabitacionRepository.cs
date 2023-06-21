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
            if (this.Exists(E => E.IdEstadoHabitacion == entity.IdEstadoHabitacion))
            {
                throw new HabitacionException("La Habitacion Ya se Encuentra Reservada.");

            }
            
            base.Add(entity);
            base.SaveChanges();
        }
       
        public override void Update(EstadoHabitacion entity)
        {
            EstadoHabitacion EstadoHabitacionUpdate = this.GetEntity(entity.IdEstadoHabitacion);

            EstadoHabitacionUpdate.IdEstadoHabitacion = entity.IdEstadoHabitacion;
            EstadoHabitacionUpdate.Descripcion = entity.Descripcion;

            base.Update(EstadoHabitacionUpdate);
            base.SaveChanges();
        }
        
        public override void Remove(EstadoHabitacion entity)
        {
            EstadoHabitacion EstadoHabitacionRemove = base.GetEntity(entity.IdEstadoHabitacion) ?? throw new EstadohabitacionExcepcion("El curso no existe.");
            EstadoHabitacionRemove.Estado = false;
            EstadoHabitacionRemove.FechaEliminacion = DateTime.Now;
            EstadoHabitacionRemove.UsuarioEliminacion = entity.UsuarioEliminacion;

            base.Update(EstadoHabitacionRemove);
            base.SaveChanges();
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
