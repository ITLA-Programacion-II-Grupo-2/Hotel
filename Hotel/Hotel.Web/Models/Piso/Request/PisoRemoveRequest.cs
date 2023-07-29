using Hotel.Domain.Entities;

namespace Hotel.Web.Models.Piso.Request
{
    public class PisoRemoveRequest 
    {
        public int IdPiso { get; set; }

        public PisoRemoveRequest()
        {
        }

        public PisoRemoveRequest(int id)
        {
            IdPiso = id;
        }
    }
}
