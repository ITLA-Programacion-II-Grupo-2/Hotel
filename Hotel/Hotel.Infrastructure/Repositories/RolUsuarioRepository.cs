
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public override void Add(RolUsuario rolUsuario)
        {
            try
            {
                string? rol = rolUsuario.Descripcion;

                this.logger.LogInformation($"Añadiendo rol: {rol}");

                if (!this.Exists(u => u.Descripcion == rol))
                {
                    base.Add(rolUsuario);
                    base.SaveChanges();
                }
                else
                {
                    throw new RolUsuarioException($"El rol: {rol} ya existe.");
                }
            }
            catch (RolUsuarioException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar usuario: " + ex.Message, ex.ToString());
            }
        }
        public override void Add(RolUsuario[] rolesUsuario)
        {
            try
            {
                foreach (var rolUsuario in rolesUsuario)
                {
                    string? rol = rolUsuario.Descripcion;

                    this.logger.LogInformation($"Añadiendo rol: {rol}");

                    if (!this.Exists(u => u.Descripcion == rol))
                    {
                        base.Add(rolUsuario);
                    }
                    else
                    {
                        throw new RolUsuarioException($"El rol: {rol} ya existe.");
                    }
                }
                base.SaveChanges();

            }
            catch (RolUsuarioException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar usuarios: " + ex.Message, ex.ToString());
            }
        }
        public override void Update(RolUsuario rolUsuario)
        {
            try
            {
                logger.LogInformation($"Actualizando RolUsuario con ID: {rolUsuario.IdRolUsuario}");

                base.Update(rolUsuario);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar RolUsuario: " + ex.Message, ex.ToString());
            }
        }
        public override void Update(RolUsuario[] rolesUsuario)
        {
            logger.LogInformation("Actualizando RolesUsuarios");
            try
            {
                foreach (var rolUsuario in rolesUsuario)
                {
                    try
                    {
                        logger.LogInformation($"Actualizando RolUsuario con ID: {rolUsuario.IdRolUsuario}");
                        base.Update(rolUsuario);   
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar RolUsuario con ID: "+ rolUsuario.IdRolUsuario + ex.Message, ex.ToString());
                    }

                    base.SaveChanges();
                }        
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar RolesUsuario..." + ex.Message, ex.ToString());
            }
        }
        public override void Remove(RolUsuario rolUsuario)
        {
            try
            {
                logger.LogInformation($"Eliminando RolUsuario con ID: {rolUsuario.IdRolUsuario}");

                base.Remove(rolUsuario);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar RolUsuario: " + ex.Message, ex.ToString());
            }
        }
        public override void Remove(RolUsuario[] rolesUsuario)
        {
            logger.LogInformation("Eliminando RolesUsuarios");
            try
            {
                foreach (var rolUsuario in rolesUsuario)
                {
                    try
                    {
                        logger.LogInformation($"Eliminando RolUsuario con ID: {rolUsuario.IdRolUsuario}");
                        base.Remove(rolUsuario);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar RolUsuario con ID: " + rolUsuario.IdRolUsuario + ex.Message, ex.ToString());
                    }
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar RolesUsuario: " + ex.Message, ex.ToString());
            }
        }

        // Consulta de un rol y todos sus usuarios
        public List<UserWithRolModel> GetUsuariosByRol(string rol)
        {
            List<UserWithRolModel> usuarios = new List<UserWithRolModel>();

            try
            {
                this.logger.LogInformation($"Consultado Usuarios con sus roles...");

                usuarios = (from rl in base.GetEntities() where rl.Descripcion == rol
                            join user in context.Usuario.ToList() on rl.IdRolUsuario equals user.IdRolUsuario
                            where rl.IdRolUsuario == user.IdRolUsuario
                            select new UserWithRolModel()
                            {
                                IdUsuario = user.IdUsuario,
                                NombreCompleto = user.NombreCompleto,
                                Correo = user.Correo,
                                Rol = rl.Descripcion
                            }).ToList();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar usuarios" + ex.Message, ex.ToString());
            }

            return usuarios;
        }

        // Consultas de todos los roles y todos sus usuarios
        public List<UserWithRolModel> GetUsuariosByRoles()
        {
            List<UserWithRolModel> usuarios = new List<UserWithRolModel>();

            try
            {
                this.logger.LogInformation($"Consultado Usuarios con sus roles...");

                usuarios = (from rl in base.GetEntities()
                            join user in context.Usuario.ToList() on rl.IdRolUsuario equals user.IdRolUsuario
                            where rl.IdRolUsuario == user.IdRolUsuario
                            select new UserWithRolModel()
                            {
                                IdUsuario = user.IdUsuario,
                                NombreCompleto = user.NombreCompleto,
                                Correo = user.Correo,
                                Rol = rl.Descripcion
                            }).ToList();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar usuarios" + ex.Message, ex.ToString());
            }

            return usuarios;
        }
    }
}
