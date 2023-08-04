using Hotel.Application.Dtos.RolUsuario;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;

namespace Hotel.Web.Http.HttpServices
{
    public class RolUsuarioHttpService : IRolUsuarioHttpService
    {
        private readonly IHttpCaller httpCaller;
        private readonly ILogger<RolUsuarioHttpService> logger;
        private string baseUrl = string.Empty;

        public RolUsuarioHttpService(ILogger<RolUsuarioHttpService> logger,
                                    IConfiguration configuration,
                                    IHttpCaller httpCaller)
        {
            this.logger = logger;
            this.httpCaller = httpCaller;
            this.baseUrl = configuration["ApiConfig:baseUrl"] + "RolUsuario/";
        }

        public RolUsuarioListResponse Get()
        {
            RolUsuarioListResponse? rolUsuarioList = new RolUsuarioListResponse();
            string url = $" {baseUrl}GetRolesUsuario";

            try
            {
                rolUsuarioList = httpCaller.Get(url, rolUsuarioList);

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
                rolUsuario = httpCaller.Get(url, rolUsuario);

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
                result = httpCaller.Set(url, rolUsuarioAdd, result);
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
                result = httpCaller.Set(url, rolUsuarioUpdate, result);
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
                result = httpCaller.Set(url, rolUsuarioRemove, result);
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
