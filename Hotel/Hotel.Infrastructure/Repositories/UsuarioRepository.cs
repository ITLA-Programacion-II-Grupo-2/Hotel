
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public override void Add(Usuario entity)
        {
            try
            {
                string? correo = entity.Correo;
                string? nombre = entity.NombreCompleto;

                this.logger.LogInformation($"Añadiendo Usuario: {nombre}, Correo: {correo}");

                if (this.Exists(u => u.Correo == correo))
                {
                    base.Add(entity);
                    base.SaveChanges();
                }
                else
                {
                    throw new UsuarioException("El correo ingresado se encuentra en uso.");
                }
            }
            catch (UsuarioException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar usuario: " + ex.Message);
            }
            
        }

        public List<UserByRolModel> userByRolModels()
        {
            throw new NotImplementedException();
        }

        public override void Remove(Usuario entity)
        {
            base.Remove(entity);
        }
    }
}
