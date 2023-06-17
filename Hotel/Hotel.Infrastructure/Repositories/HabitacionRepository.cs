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


        public HabitacionRepository(ILogger<HabitacionRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public override void Add(Habitacion entity)
        {

               
                if (this.Exists(H => H.Numero == entity.Numero))
                {
                    base.Add(entity);
                    base.SaveChanges();
                }
                else
                {
                    throw new HabitacionException("La Habitacion Ya se Encuentra Reservada.");
                }
            
        }
       
        public override void Remove(Habitacion entity)
        {
            try
            {

                base.Remove(entity);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al Eliminar Los Datos De la Habitacion: " + ex.Message, ex.ToString());
            }
        }
        
        public override void Update(Habitacion entity)
        {
            try
            {

                base.Update(entity);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar La Habitacion Con ID : " + entity.IdHabitacion + ex.Message, ex.ToString());
            }
        }
        

        public HabitacionModel GetDepartmentById(int id)
        {
            HabitacionModel habitacionModel = new HabitacionModel();


            try
            {
                Habitacion habitacion = this.GetEntity(id);

                habitacionModel.IdHabitacion = habitacion.IdHabitacion;
                habitacionModel.Numero = habitacion.Numero;
                habitacionModel.Detalle = habitacion.Detalle;
                habitacionModel.Precio = habitacion.Precio;
                habitacionModel.IdEstadoHabitacion = habitacion.IdEstadoHabitacion;


            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el department", ex.ToString());
            }

            return habitacionModel;
        }

        public List<HabitacionModel> GetHabitacions()
        {
            List<HabitacionModel> Habitacions = new List<HabitacionModel>();

            try
            {

                this.logger.LogInformation($"Consultando.....");

                Habitacions =  this.context.Habitacion
                                 .Where(cd => !cd.Estado).Select(Ha => new HabitacionModel()
                                {
                                    IdHabitacion = Ha.IdHabitacion,
                                    Detalle = Ha.Detalle,
                                    Numero = Ha.Numero,
                                    IdEstadoHabitacion = Ha.IdEstadoHabitacion,

                                }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error Al Mostrar Las Habitaciones: {ex.Message}", ex.ToString());
            }

            return Habitacions;
        }
    }
}
