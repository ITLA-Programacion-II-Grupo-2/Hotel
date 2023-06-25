
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Extentions;
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

                if (this.Exists(u => u.Descripcion == rol && u.Estado == true))
                    throw new RolUsuarioException($"El rol: {rol} ya existe.");
               
                rolUsuario.ConvertRolUsuarioCreateToEntity();

                base.Add(rolUsuario);
                base.SaveChanges();

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

                    if (this.Exists(u => u.Descripcion == rol && u.Estado == true))
                        throw new RolUsuarioException($"El rol: {rol} ya existe.");

                    rolUsuario.ConvertRolUsuarioCreateToEntity();

                    base.Add(rolUsuario);
                    base.SaveChanges();
                }      

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

                RolUsuario rolUsuarioToUpdate = base.GetEntity(rolUsuario.IdRolUsuario);

                if (rolUsuarioToUpdate == null)
                    throw new RolUsuarioException("El RolUsuario ha actualizar es nulo");
                if (!rolUsuarioToUpdate.Estado)
                    throw new RolUsuarioException("El RolUsuario ha actualizar ha sido antes eliminado");

                rolUsuarioToUpdate.ConvertRolUsuarioUpdateToEntity(rolUsuario);

                base.Update(rolUsuarioToUpdate);
                base.SaveChanges();

            }
            catch (RolUsuarioException ruex)
            {
                logger.LogError(ruex.Message);
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

                        RolUsuario rolUsuarioToUpdate = base.GetEntity(rolUsuario.IdRolUsuario);

                        if (rolUsuarioToUpdate == null)
                            throw new RolUsuarioException("El RolUsuario ha actualizar es nulo");
                        if (!rolUsuarioToUpdate.Estado)
                            throw new RolUsuarioException("El RolUsuario ha actualizar ha sido antes eliminado");

                        rolUsuarioToUpdate.ConvertRolUsuarioUpdateToEntity(rolUsuario);

                        base.Update(rolUsuarioToUpdate);

                        base.SaveChanges();
                    }
                    catch (RolUsuarioException ruex)
                    {
                        logger.LogError(ruex.Message);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar RolUsuario con ID: "+ rolUsuario.IdRolUsuario + ex.Message, ex.ToString());
                    }      
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

                RolUsuario rolUsuarioToRemove = base.GetEntity(rolUsuario.IdRolUsuario);

                if (rolUsuarioToRemove == null)
                    throw new RolUsuarioException("El RolUsuario ha eliminar es nulo");
                if (!rolUsuarioToRemove.Estado)
                    throw new RolUsuarioException("El RolUsuario ha eliminar ha sido antes eliminado");

                rolUsuarioToRemove.ConvertRolUsuarioRemoveToEntity(rolUsuario);

                base.Update(rolUsuarioToRemove);

                base.SaveChanges();
            }
            catch (RolUsuarioException ruex)
            {
                logger.LogError(ruex.Message);
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

                        RolUsuario rolUsuarioToRemove = base.GetEntity(rolUsuario.IdRolUsuario);

                        if (rolUsuarioToRemove == null)
                            throw new RolUsuarioException("El RolUsuario ha eliminar es nulo");
                        if (!rolUsuarioToRemove.Estado)
                            throw new RolUsuarioException("El RolUsuario ha eliminar ha sido antes eliminado");

                        rolUsuarioToRemove.ConvertRolUsuarioRemoveToEntity(rolUsuario);

                        base.Update(rolUsuarioToRemove);

                        base.SaveChanges();
                    }
                    catch (RolUsuarioException ruex)
                    {
                        logger.LogError(ruex.Message);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar RolUsuario: " + ex.Message, ex.ToString());
                    }
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar RolesUsuario: " + ex.Message, ex.ToString());
            }
        }

        public List<RolUsuarioModel> GetRolUsuarios()
        {
            List<RolUsuarioModel> rolesusuario = new List<RolUsuarioModel>();

            try
            {
                this.logger.LogInformation($"Consultado Roles...");

                List<RolUsuario> roles = base.GetEntities().Where(r => r.Estado == true).ToList();

                if (roles == null)
                    throw new RolUsuarioException("No existen roles en la base de datos");

                foreach (RolUsuario rolusuario in roles)
                {
                    RolUsuarioModel rol = rolusuario.ConvertRolUsuarioEntityToModel();

                    rolesusuario.Add(rol);
                }

            }
            catch (RolUsuarioException ruex)
            {
                this.logger.LogError(ruex.Message);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar los roles: " + ex.Message, ex.ToString());
            }

            return rolesusuario;
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
                            where rl.Estado == true && user.Estado == true
                            select user.ConvertUsuarioWithRolToModel(rl)).ToList();

                if (usuarios == null)
                    throw new RolUsuarioException($"Error al consultar los usuarios del rol: {rol}");
            }
            catch (RolUsuarioException ruex)
            {
                this.logger.LogError(ruex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar usuarios con rol " + ex.Message, ex.ToString());
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
                            where rl.Estado == true && user.Estado == true
                            select user.ConvertUsuarioWithRolToModel(rl)).ToList();

                if (usuarios == null)
                    throw new RolUsuarioException("No existen roles en la base de datos");

            }
            catch (RolUsuarioException ruex)
            {
                this.logger.LogError(ruex.Message);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar usuarios" + ex.Message, ex.ToString());
            }

            return usuarios;
        }

        
    }
}
