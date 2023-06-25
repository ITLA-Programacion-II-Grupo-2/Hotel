using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Extentions;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mail;

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

            try
            {
                if (string.IsNullOrEmpty(model.Descripcion))
                {
                    result.Message = "El Campo Descripcion Es Requerido, No Puede Estar Vacio";
                    result.Success = false;
                    return result;
                }


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
            try
            {
                var estadoHabitacion = model.ConvertDtoUpdateToEntity();

                this.estadoHabitacionRepository.Add(estadoHabitacion);



                result.Message = "EstadoHabitacion Actualizado Sactifotoriamente.";
               

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Al Agregar El EstadoHabitacion.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Remove(EstadoHabitacionRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.estadoHabitacionRepository.Remove(new EstadoHabitacion()
                {
                    IdEstadoHabitacion = model.IdEstadoHabitacion,
                    Estado = model.Estado,
                    FechaEliminacion = model.CambioFecha,
                    UsuarioEliminacion = model.CambioUsuario
                });

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
