using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Dtos.Habitacion;
using Hotel.Application.Extentions;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Hotel.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository habitacionRepository;
        private readonly ILogger<HabitacionService> logger;

        public HabitacionService(IHabitacionRepository habitacionRepository,
                                  ILogger<HabitacionService> logger)
        {
            this.habitacionRepository = habitacionRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var Habitacion = this.habitacionRepository.GetEntities();
                result.Data = Habitacion;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Obtener Las Habitaciones";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var habitacion = this.habitacionRepository.GetEntity(id);
                result.Data = habitacion;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Obtener Las Habitaciones";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Add(HabitacionAddDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.Numero))
            {
                result.Message = "El Campo Es Requirido.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Detalle))
            {
                result.Message = "El Campo Es Requirido";
                result.Success = false;
                return result;
            }

            if (!model.Precio.HasValue)
            {
                result.Message = "El Campo de Precio No Puede Ser Cero .";
                result.Success = false;
                return result;
            }

            if (!model.IdEstadoHabitacion.HasValue)
            {
                result.Message = "El Campo de IdEstadoHabitacion No Puede Ser Cero .";
                result.Success = false;
                return result;
            }

            if (!model.IdCategoria.HasValue)
            {
                result.Message = "El Campo de IdCategoria No Puede Ser Cero ";
                result.Success = false;
                return result;
            }

            if (!model.IdPiso.HasValue)
            {
                result.Message = "El Campo de IdPiso No Puede Ser Cero ";
                result.Success = false;
                return result;
            }


            try
            {
                var habitacion = model.ConvertDtoAddToEntity();

                this.habitacionRepository.Add(habitacion);


                result.Message = "Habitacion Agregada correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Agregar Habitacion.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Update(HabitacionUpdateDto model)
        {
            ServiceResult result = new ServiceResult();


            try
            {
                var habitacion = model.ConvertDtoUpdateToEntity();

                this.habitacionRepository.Add(habitacion);

                result.Message = "Habiatcion Actualizada Sactifotoriamente.";
                this.habitacionRepository.SaveChanges();
            } 
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Al Agregar Habitacion.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
           

                



            return result;
        }
        public ServiceResult Remove(HabitacionRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.habitacionRepository.Remove(new Habitacion()
                {
                    IdHabitacion = model.IdHabitacion,
                    Estado = model.Estado,
                    FechaEliminacion = model.CambioFecha,
                    UsuarioEliminacion = model.CambioUsuario
                });

                result.Message = "Habitacion eliminada correctamente.";

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Eliminar Habitacion.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
