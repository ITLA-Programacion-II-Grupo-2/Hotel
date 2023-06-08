
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> logger;
        private readonly HotelContext context;

        public UsuarioRepository(ILogger<UsuarioRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


    }
}
