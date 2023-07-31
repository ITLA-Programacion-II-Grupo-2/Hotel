using Hotel.Application.Dtos.Usuario;
using Hotel.Web.Api.ApiServices.Interfaces;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models;
using Hotel.Web.Models.Usuario.Request;
using Hotel.Web.Models.Usuario.Response;

namespace Hotel.Web.Api.ApiServices
{
    public class UsuarioApiService : IUsuarioApiService
    {
        private readonly IApiCaller apiCaller;
        private readonly ILogger<UsuarioApiService> logger;
        private string baseUrl = "http://localhost:5286/api/Usuario/";

        public UsuarioApiService(IApiCaller apiCaller, ILogger<UsuarioApiService> logger)
        {
            this.apiCaller = apiCaller;
            this.logger = logger;
        }

        public UsuarioListResponse Get()
        {
            UsuarioListResponse? usuariosList = new UsuarioListResponse();
            string url = $" {baseUrl}GetUsuariosWithRol";

            try
            {
                usuariosList = apiCaller.Get(url, usuariosList);

                if (usuariosList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                usuariosList = new UsuarioListResponse();
                usuariosList.Success = false;
                usuariosList.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(usuariosList.Message, ex.ToString());
            }

            return usuariosList;
        }
        public UsuarioDetailsResponse GetById(int id)
        {
            UsuarioDetailsResponse? usuario = new UsuarioDetailsResponse();
            string url = $" {baseUrl}GetUsuarioWithRol?id={id}";

            try
            {
                usuario = apiCaller.Get(url, usuario);

                if (usuario == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                usuario = new UsuarioDetailsResponse();
                usuario.Success = false;
                usuario.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(usuario.Message, ex.ToString());
            }

            return usuario;
        }
        public BaseResponse Add(UsuarioAddRequest add)
        {
            BaseResponse? result = new BaseResponse();

            UsuarioAddDto usuarioAdd = add.ConvertAddRequestToAddDto();

            string url = $" {baseUrl}SaveUsuario";

            try
            {
                result = apiCaller.Set(url, usuarioAdd, result);
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
        public BaseResponse Update(UsuarioUpdateRequest update)
        {
            BaseResponse? result = new BaseResponse();

            UsuarioUpdateDto usuarioUpdate = update.ConvertUpdateRequestToUpdateDto();
            string url = $" {baseUrl}UpdateUsuario";

            try
            {
                result = apiCaller.Set(url, usuarioUpdate, result);
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
        public BaseResponse Remove(UsuarioRemoveRequest remove)
        {
            BaseResponse? result = new BaseResponse();

            UsuarioRemoveDto usuarioRemove = remove.ConvertRemoveDtoToRemoveRequest();
            string url = $" {baseUrl}RemoveUsuario";

            try
            {
                result = apiCaller.Set(url, usuarioRemove, result);
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
