using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Interfaces
{
   public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        List<CategoriaModels> GetCategoriasByBaseEntity();

    }
}
