namespace Hotel.Web.Models
{
    public abstract class BaseRequest
    {
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
