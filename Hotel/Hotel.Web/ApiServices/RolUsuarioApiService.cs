using Hotel.Application.Dtos.RolUsuario;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.Web.ApiServices
{
    public class RolUsuarioApiService : IRolUsuarioApiService
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<RolUsuarioApiService> logger;
        private string baseUrl = "http://localhost:5286/api/RolUsuario/";

        public RolUsuarioApiService(ILogger<RolUsuarioApiService> logger)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.logger = logger;
        }

        public RolUsuarioListResponse Get()
        {
            RolUsuarioListResponse? rolUsuarioList = new RolUsuarioListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    string url = $" {this.baseUrl}GetRolesUsuario";

                    using (var response = httpClient.GetAsync(url).Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            rolUsuarioList = JsonConvert.DeserializeObject<RolUsuarioListResponse>(apiResponse);

                            if (rolUsuarioList == null)
                                throw new Exception("Deserializacion nula");
                        }
                    }
                }
            }
            catch(Exception ex){
                rolUsuarioList = new RolUsuarioListResponse();
                rolUsuarioList.Success = false;
                rolUsuarioList.Message = "Error al solicitar rol usuarios";
                this.logger.LogError(rolUsuarioList.Message, ex.ToString());
            }

            return rolUsuarioList;
        }
        public RolUsuarioDetailsResponse GetById(int id)
        {
            RolUsuarioDetailsResponse? rolUsuario = new RolUsuarioDetailsResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    string url = $" {this.baseUrl}GetRolUsuario?id={id}";

                    using (var response = httpClient.GetAsync(url).Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            rolUsuario = JsonConvert.DeserializeObject<RolUsuarioDetailsResponse>(apiResponse);

                            if (rolUsuario == null)
                                throw new Exception("Deserializacion nula");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rolUsuario = new RolUsuarioDetailsResponse();
                rolUsuario.Success = false;
                rolUsuario.Message = "Error al solicitar rol usuarios";
                this.logger.LogError(rolUsuario.Message, ex.ToString());
            }

            return rolUsuario;
        }
        public BaseResponse Add(RolUsuarioAddRequest rolUsuario)
        {
            BaseResponse? result = new BaseResponse();

            RolUsuarioAddDto rolUsuarioAdd = rolUsuario.ConvertAddRequestToDto();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(rolUsuarioAdd), Encoding.UTF8, "application/json");

                    string url = $" {this.baseUrl}SaveRolUsuario";

                    using (var response = httpClient.PostAsync(url, content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        result = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                        if (result == null)
                            throw new Exception("Deserializacion Nula");
                    }
                }
            }
            catch (Exception ex)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        public BaseResponse Update(RolUsuarioUpdateRequest rolUsuario)
        {
            BaseResponse? result = new BaseResponse();

            RolUsuarioUpdateDto rolUsuarioUpdate = rolUsuario.ConvertUpdateRequestToDto();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(rolUsuarioUpdate), Encoding.UTF8, "application/json");

                    string url = $" {this.baseUrl}UpdateRolUsuario";

                    using (var response = httpClient.PostAsync(url, content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        result = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                        if (result == null)
                            throw new Exception("Deserializacion Nula");
                    }
                }
            }
            catch (Exception ex)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        public BaseResponse Remove(RolUsuarioRemoveRequest rolUsuario)
        {
            BaseResponse? result = new BaseResponse();

            RolUsuarioRemoveDto rolUsuarioRemove = rolUsuario.ConvertRemoveRequestToDto();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(rolUsuarioRemove), Encoding.UTF8, "application/json");

                    string url = $" {this.baseUrl}RemoveRolUsuario";

                    using (var response = httpClient.PostAsync(url, content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        result = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                        if (result == null)
                            throw new Exception("Deserializacion Nula");
                    }
                }
            }
            catch (Exception ex)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
