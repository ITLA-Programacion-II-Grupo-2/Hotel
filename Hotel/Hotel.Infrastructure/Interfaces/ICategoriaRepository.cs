using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;


namespace Hotel.Infrastructure.Interfaces
{
   public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        CategoriaModels GetCategoria(int id);
        List<CategoriaModels> GetCategoria();

    }
}
