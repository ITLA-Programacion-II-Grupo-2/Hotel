
using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext()
        {

        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<RolUsuario>? RolUsuario { get; set; }

    }
}
    