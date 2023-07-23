using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dto.Piso;
using Hotel.Application.Extentions;
using Hotel.Application.Validations;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Hotel.Application.Service
{
    public class PisoService : IPisoService
    {

        private readonly IPisoRepository pisoRepository;
        private readonly ILogger<PisoService> logger;

    public PisoService(IPisoRepository pisoRepository,
                             ILogger<PisoService> logger)
    {
        this.pisoRepository = pisoRepository;
        this.logger = logger;
    }

       

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var Piso = this.pisoRepository.GetPiso();
                result.Data = Piso;
            }
            catch (Exception ex )
            {

                result.Success = false;
                result.Message = "Error al obtener una piso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }


        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var piso = this.pisoRepository.GetPiso(id);
                result.Data = piso;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al obtener un piso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }


        public ServiceResult Add(PisoAddDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidandopisAdd();
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var piso = model.ConvertDtoAddToEntity();
                this.pisoRepository.Add(piso);

                result.Message = "piso agregado de forma correcta";
            }
            catch (PisoException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo un piso : {model.Descripcion}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(PisoUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            result = PisoValidations.ValidandopisUpdate(model);

            if ((bool)!result.Success)
            {
                return result;
            }
            try
            {
                var piso = model.ConvertDtoUpdateToEntity();

                this.pisoRepository.Update(piso);



                result.Message = "El piso fue actualizada satisfactoriamente.";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al agregar un piso.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(PisoRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            result = PisoValidations.ValidandopisRemove(model);

            if ((bool)!result.Success)
            {
                return result;
            }

            try
            {
                var piso = model.ConvertDtoRemoveToEntity();

                this.pisoRepository.Remove(piso);

                result.Message = "el piso eliminada correctamente.";

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al eliminar una piso.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }








        
    }
}
