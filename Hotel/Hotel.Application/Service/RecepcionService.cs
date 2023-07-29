
using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;
using Hotel.Application.Extentions;
using Hotel.Application.Validations;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Hotel.Application.Service
{
    public class RecepcionService : IRecepcionService
    {
        private readonly IRecepcionRepository recepcionRepository;
        private readonly ILogger<RecepcionService> logger;

        public RecepcionService(IRecepcionRepository recepcionRepository,
            ILogger<RecepcionService> logger)
        {
            this.recepcionRepository = recepcionRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.recepcionRepository.GetRecepciones();
            }
            catch (RecepcionException rex)
            {
                result.Success = false;
                result.Message = rex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los usuarios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.recepcionRepository.GetRecepcion(id);
            }
            catch (RecepcionException rex)
            {
                result.Success = false;
                result.Message = rex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el usuario de id: {id}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Add(RecepcionAddDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.ValidateRecepcionDto();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var recepcion = model.ConvertAddDtoToEntity();

                this.recepcionRepository.Add(recepcion);

                result.Message = "Recepcion agregada correctamente";
            }
            catch (RecepcionException rex)
            {
                result.Success = false;
                result.Message = rex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo la Recepcion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Update(RecepcionUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.ValidateRecepcionDto();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var recepcion = model.ConvertUpdateDtoToEntity();

                this.recepcionRepository.Update(recepcion);

                result.Message = "Recepcion actualizada correctamente";
            }
            catch (RecepcionException rex)
            {
                result.Success = false;
                result.Message = rex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando la Recepcion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Remove(RecepcionRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.ValidateRecepcionDto();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var recepcion = model.ConvertRemoveDtoToEntity();

                this.recepcionRepository.Remove(recepcion);

                result.Message = "Recepcion removida correctamente";
            }
            catch (RecepcionException rex)
            {
                result.Success = false;
                result.Message = rex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo la Recepcion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Add(RecepcionAddDto[] models)
        {
            throw new NotImplementedException();
        }
        public ServiceResult Update(RecepcionUpdateDto[] models)
        {
            throw new NotImplementedException();
        }
        public ServiceResult Remove(RecepcionRemoveDto[] models)
        {
            throw new NotImplementedException();
        }
    }
}
