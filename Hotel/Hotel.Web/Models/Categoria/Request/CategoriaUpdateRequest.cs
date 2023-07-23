namespace Hotel.Web.Models.Categoria.Request
{
    public class CategoriaUpdateRequest : CategoriaRequest
    {
        public string? UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
