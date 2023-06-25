using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Validaciones;
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
            result = HabitacioValidacion.ValidateIdHabitacion(id);
            if ((bool)!result.Success)
            {
                return result;
            }



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

            result = HabitacioValidacion.ValidateHabitacionoAdd(model);
            if ((bool)!result.Success)
            {
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
            result = HabitacioValidacion.ValidateHabitacionUpdate(model);
            if ((bool)!result.Success)
            {
                return result;
            }



            try
            {
                var habitacion = model.ConvertDtoUpdateToEntity();

                this.habitacionRepository.Update(habitacion);

                result.Message = "Habiatcion Actualizada Sactifotoriamente.";
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
            result = HabitacioValidacion.ValidateEstadoHabitacionRemove(model);
            if ((bool)!result.Success)
            {
                return result;
            }

            try
            {
                var habitacion = model.ConvertDtoRemoveToEntity();

                this.habitacionRepository.Remove(habitacion);

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
