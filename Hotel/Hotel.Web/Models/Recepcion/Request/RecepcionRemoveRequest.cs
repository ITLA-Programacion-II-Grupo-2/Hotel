namespace Hotel.Web.Models.Recepcion.Request
{
    public class RecepcionRemoveRequest: BaseRequest
    {
        public int IdRecepcion { get; set; }

        public RecepcionRemoveRequest()
        {

        }

        public RecepcionRemoveRequest(int idRecepcion)
        {
            IdRecepcion = idRecepcion;
        }
    }
}
