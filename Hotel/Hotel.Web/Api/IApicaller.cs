using Hotel.Web.Models;

namespace Hotel.Web.Api
{
    public interface IApicaller
    {
        ObjIn? Get<ObjIn>(string url, ObjIn objIn) where ObjIn : BaseResponse;
        ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn objIn, ObjOut objOut) where ObjOut : BaseResponse;
    }
}
