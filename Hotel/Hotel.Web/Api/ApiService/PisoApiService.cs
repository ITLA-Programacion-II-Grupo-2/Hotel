﻿using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;

namespace Hotel.Web.Api.ApiService
{
    public class PisoApiService : IPisoApiService
    {
        private readonly IApicaller apicaller;
        private readonly ILogger<PisoApiService> logger;
        private string baseUrl = "http://localhost:5286/api/Piso/";


        public PisoApiService(IApicaller apicaller, ILogger<PisoApiService> logger)
        {
            this.apicaller = apicaller;
            this.logger = logger;
        }


        public PisoListResponse Get()
        {
            PisoListResponse? pisosList = new PisoListResponse();
            string url = $" {baseUrl}GetPiso";

            try
            {
                pisosList = apicaller.Get(url, pisosList);

                if (pisosList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                pisosList = new PisoListResponse();
                pisosList.Success = false;
                pisosList.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(pisosList.Message, ex.ToString());
            }

            return pisosList;
        }

        public PisoDetailsResponse GetById(int id)
        {
            PisoDetailsResponse? piso = new PisoDetailsResponse();
            string url = $" {baseUrl}GetPisoid={id}";

            try
            {
                piso = apicaller.Get(url, piso);

                if (piso == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                piso = new PisoDetailsResponse();
                piso.Success = false;
                piso.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(piso.Message, ex.ToString());
            }

            return piso;
        }
        public BaseResponse Add(PisoAddRequest add)
        {
            BaseResponse? result = new BaseResponse();

            PisoAddDto pisoAdd = add.ConvertAddRequestToAddDto();

            string url = $" {baseUrl}SavePiso";

            try
            {
                result = apicaller.Set(url, pisoAdd, result);
                if (result == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        public BaseResponse Update(PisoUpdateRequest update)
        {
            BaseResponse? result = new BaseResponse();

            PisoUpdateDto pisoUpdate = update.ConvertirUpdateRequestToUpdateDto();
            string url = $" {baseUrl}UpdatePiso";

            try
            {
                result = apicaller.Set(url, pisoUpdate, result);
                if (result == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
