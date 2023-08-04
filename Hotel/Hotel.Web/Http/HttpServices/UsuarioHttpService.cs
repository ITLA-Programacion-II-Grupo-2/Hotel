using Hotel.Application.Dtos.Usuario;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models;
using Hotel.Web.Models.Usuario.Request;
using Hotel.Web.Models.Usuario.Response;

namespace Hotel.Web.Http.HttpServices
{
    public class UsuarioHttpService : IUsuarioHttpService
    {
        private readonly IHttpCaller httpCaller;
        private readonly ILogger<UsuarioHttpService> logger;
        private string baseUrl = string.Empty;

        public UsuarioHttpService(IHttpCaller apiCaller, 
                                IConfiguration configuration,
                                ILogger<UsuarioHttpService> logger)
        {
            this.httpCaller = apiCaller;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"] + "Usuario/";
        }

        public UsuarioListResponse Get()
        {
            UsuarioListResponse? usuariosList = new UsuarioListResponse();
            string url = $" {baseUrl}GetUsuariosWithRol";

            try
            {
                usuariosList = httpCaller.Get(url, usuariosList);

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
                usuario = httpCaller.Get(url, usuario);

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
                result = httpCaller.Set(url, usuarioAdd, result);
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
                result = httpCaller.Set(url, usuarioUpdate, result);
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
                result = httpCaller.Set(url, usuarioRemove, result);
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
