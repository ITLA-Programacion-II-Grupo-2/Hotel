

using Hotel.API.Controllers;


namespace Hotel.Application.Dto.Categoria
{
  public class CategoriaUpdateDto : DtoBase
  {

      public int IdCategoria { get; set; }
       public string? Descripcion { get; set; }
     

  }
}
