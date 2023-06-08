
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Hotel.Infrastructure.Repositories
{
    public class RolUsuarioRepository : BaseRepository<RolUsuario>, IRolUsuarioRepository
    {
        private readonly ILogger<RolUsuarioRepository> logger;
        private readonly HotelContext context;

        public RolUsuarioRepository(ILogger<RolUsuarioRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<RolUsuarioModel> getUsuariobyRoles()
        {
            throw new System.NotImplementedException();
        }
    }
}
