using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext()
        {

        }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<Piso>? Piso { get; set; }
    }
}
