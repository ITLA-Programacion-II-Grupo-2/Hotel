namespace Hotel.Web.Models.Categoria.Request
{
    public class CategoriaRemoveRequet : BaseRequest
    {
        public int IdCategoria { get; set; }

        public CategoriaRemoveRequet ()      
        {
        }

        public CategoriaRemoveRequet(int id)
        {
            IdCategoria = id;
        }
    }
}
