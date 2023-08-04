using Hotel.Web.Models;

namespace Hotel.Web.Http

{
    public interface IHttpCaller
    {
       Response? Get<Response>(string url, Response response) where Response : BaseResponse;
       Response? Set<Request, Response>(string url, Request request, Response response) where Response : BaseResponse;
    }
}
