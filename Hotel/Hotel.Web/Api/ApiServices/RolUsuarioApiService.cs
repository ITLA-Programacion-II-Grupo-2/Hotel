using Hotel.Application.Dtos.RolUsuario;
using Hotel.Web.Api.ApiServices.Interfaces;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;

namespace Hotel.Web.Api.ApiServices
{
    public class RolUsuarioApiService : IRolUsuarioApiService
    {
        private readonly IApiCaller apiCaller;
        private readonly ILogger<RolUsuarioApiService> logger;
        private string baseUrl = "http://localhost:5286/api/RolUsuario/";

        public RolUsuarioApiService(ILogger<RolUsuarioApiService> logger, IApiCaller apiCaller)
        {
            this.logger = logger;
            this.apiCaller = apiCaller;
        }

        public RolUsuarioListResponse Get()
        {
            RolUsuarioListResponse? rolUsuarioList = new RolUsuarioListResponse();
            string url = $" {baseUrl}GetRolesUsuario";

            try
            {
                rolUsuarioList = apiCaller.Get(url, rolUsuarioList);

                if (rolUsuarioList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                rolUsuarioList = new RolUsuarioListResponse();
                rolUsuarioList.Success = false;
                rolUsuarioList.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(rolUsuarioList.Message, ex.ToString());
            }

            return rolUsuarioList;
        }
        public RolUsuarioDetailsResponse GetById(int id)
        {
            RolUsuarioDetailsResponse? rolUsuario = new RolUsuarioDetailsResponse();
            string url = $" {baseUrl}GetRolUsuario?id={id}";

            try
            {
                rolUsuario = apiCaller.Get(url, rolUsuario);

                if (rolUsuario == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                rolUsuario = new RolUsuarioDetailsResponse();
                rolUsuario.Success = false;
                rolUsuario.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(rolUsuario.Message, ex.ToString());
            }

            return rolUsuario;
        }
        public BaseResponse Add(RolUsuarioAddRequest rolUsuario)
        {
            BaseResponse? result = new BaseResponse();

            RolUsuarioAddDto rolUsuarioAdd = rolUsuario.ConvertAddRequestToDto();
            string url = $" {baseUrl}SaveRolUsuario";

            try
            {
                result = apiCaller.Set(url, rolUsuarioAdd, result);
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
        public BaseResponse Update(RolUsuarioUpdateRequest rolUsuario)
        {
            BaseResponse? result = new BaseResponse();

            RolUsuarioUpdateDto rolUsuarioUpdate = rolUsuario.ConvertUpdateRequestToDto();
            string url = $" {baseUrl}UpdateRolUsuario";

            try
            {
                result = apiCaller.Set(url, rolUsuarioUpdate, result);
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
        public BaseResponse Remove(RolUsuarioRemoveRequest rolUsuario)
        {
            BaseResponse? result = new BaseResponse();

            RolUsuarioRemoveDto rolUsuarioRemove = rolUsuario.ConvertRemoveRequestToDto();
            string url = $" {baseUrl}RemoveRolUsuario";

            try
            {
                result = apiCaller.Set(url, rolUsuarioRemove, result);
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
