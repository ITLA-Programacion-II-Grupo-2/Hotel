using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Extentions;
using Hotel.Domain.Entities;
using Hotel.Application.Validaciones;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Hotel.Application.Services
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly IEstadoHabitacionRepository estadoHabitacionRepository;
        private readonly ILogger<EstadoHabitacionService> logger;

        public EstadoHabitacionService(IEstadoHabitacionRepository estadoHabitacionRepository,
                                  ILogger<EstadoHabitacionService> logger)
        {
            this.estadoHabitacionRepository = estadoHabitacionRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();
           

            try
            {
                var EstadoHabitacion = this.estadoHabitacionRepository.GetEntities();
                result.Data = EstadoHabitacion;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Obtener Los EstadoHabitacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            result = EstadoHabitacionValidacion.ValidateIdEstadoHabitacion(id);
            if ((bool)!result.Success)
            {
                return result;
            }


            try
            {
                var EstadoHabitacion = this.estadoHabitacionRepository.GetEntity(id);
                result.Data = EstadoHabitacion;
            }
           
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Obtener Los EstadoHabitacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Add(EstadoHabitacionAddDto model)
        {
            ServiceResult result = new ServiceResult();
            result = EstadoHabitacionValidacion.ValidateEstadoHabitacionoAdd(model);
            if ((bool)!result.Success)
            {
                return result;
            }

            try
            {
                var estadoHabitacion = model.ConvertDtoAddToEntity();

                this.estadoHabitacionRepository.Add(estadoHabitacion);

                result.Message = "EstadoHabitacion Agregado Sactifotoriamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Agregar El EstadoHabitacion.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }
        public ServiceResult Update(EstadoHabitacionUpdateDto model)
        {
            ServiceResult result = new ServiceResult();
            result = EstadoHabitacionValidacion.ValidateEstadoHabitacionUpdate(model);

            if ((bool)!result.Success)
            {
                return result;
            }
            try
            {
                var estadoHabitacion = model.ConvertDtoUpdateToEntity();

                this.estadoHabitacionRepository.Update(estadoHabitacion);



                result.Message = "EstadoHabitacion Actualizado Sactifotoriamente.";
               

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Al Actualizar El EstadoHabitacion.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Remove(EstadoHabitacionRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            result = EstadoHabitacionValidacion.ValidateEstadoHabitacionRemove(model);

            if ((bool)!result.Success)
            {
                return result;
            }

            try
            {
                var estadoHabitacion = model.ConvertDtoRemoveToEntity();

                this.estadoHabitacionRepository.Remove(estadoHabitacion);

                result.Message = "Estadohabitacion eliminado correctamente.";

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Eliminar El EstadoHabitacion.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
