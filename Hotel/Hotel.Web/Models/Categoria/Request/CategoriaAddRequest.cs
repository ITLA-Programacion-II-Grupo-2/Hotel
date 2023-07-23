namespace Hotel.Web.Models.Categoria.Request
{
    public class CategoriaAddRequest : CategoriaRequest
    {
        public string? UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
