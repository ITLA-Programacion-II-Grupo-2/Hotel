
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

        // Agregar usuario, validacion de correo no existente
        public override void Add(Usuario usuario)
        {
            try
            {
                string? correo = usuario.Correo;
                string? nombre = usuario.NombreCompleto;

                this.logger.LogInformation($"Añadiendo Usuario: {nombre}, Correo: {correo}...");

                if (!this.Exists(u => u.Correo == correo))
                {
                    base.Add(usuario);
                    base.SaveChanges();
                }
                else
                {
                    throw new UsuarioException($"El correo: {correo} se encuentra en uso.");
                }
            }
            catch (UsuarioException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar usuario: " + ex.Message, ex.ToString());
            }
            
        }
        public override void Add(Usuario[] usuarios)
        {
            try
            {
                foreach (var usuario in usuarios)
                {
                    string? correo = usuario.Correo;
                    string? nombre = usuario.NombreCompleto;

                    this.logger.LogInformation($"Añadiendo Usuario: {nombre}, Correo: {correo}...");

                    if (!this.Exists(u => u.Correo == correo))
                    {
                        base.Add(usuario);
                    }
                    else
                    {
                        throw new UsuarioException($"El correo: {correo} se encuentra en uso.");
                    }
                }

                base.SaveChanges();
            }
            catch (UsuarioException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar usuario: " + ex.Message, ex.ToString());
            }
        }
        public override void Update(Usuario usuario)
        {
            try
            {
                logger.LogInformation($"Actualizando Usuario con ID: {usuario.IdUsuario}");

                base.Update(usuario);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar usuario..." + ex.Message, ex.ToString());
            }
        }
        public override void Update(Usuario[] usuarios)
        {
            logger.LogInformation("Actualizando Usuarios");
            try
            {
                foreach (var usuario in usuarios)
                {
                    try
                    {
                        logger.LogInformation($"Actualizando Usuario con ID: {usuario.IdUsuario}");
                        base.Update(usuario);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar Usuario con ID: " + usuario.IdUsuario + ex.Message, ex.ToString());
                    }    
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar usuarios..." + ex.Message, ex.ToString());
            }
        }
        public override void Remove(Usuario usuario)
        {
            try
            {
                logger.LogInformation($"Eliminando Usuario con ID: {usuario.IdUsuario}");

                base.Remove(usuario);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar usuario: " + ex.Message, ex.ToString());
            }
        }
        public override void Remove(Usuario[] usuarios)
        {
            try
            {
                foreach (var usuario in usuarios)
                {
                    try
                    {
                        logger.LogInformation($"Eliminando Usuario con ID: {usuario.IdUsuario}");
                        base.Remove(usuario);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar Usuario con ID: " + usuario.IdUsuario + ex.Message, ex.ToString());
                    }  
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar usuarios: " + ex.Message, ex.ToString());
            }
        }
        
        // Consulta de Usuario, atraves del UsuarioModel (Usuario sin clave).
        public UsuarioModel GetUsuario(int id)
        {
            UsuarioModel usuario = new UsuarioModel();

            
            try
            {
                this.logger.LogInformation($"Consultado Usuario id: {id}...");

                Usuario user = base.GetEntity(id);

                usuario = new UsuarioModel()
                {
                    IdUsuario = user.IdUsuario,
                    NombreCompleto = user.NombreCompleto,
                    Correo = user.Correo
                };

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar el usuario id '" + id + "': " + ex.Message, ex.ToString());
            }

            return usuario;
        }

        // Consulta de Usuario con su rol, atraves del UsuarioByRolModel (Usuario sin clave).
        public UserWithRolModel GetUsuarioWithRol(int id)
        {
            UserWithRolModel usuario = new UserWithRolModel();

            try
            {
                this.logger.LogInformation($"Consultado Usuario con rol id: {id}...");

                usuario = (from user in base.GetEntities()
                          join rol in context.RolUsuario.ToList() on user.IdRolUsuario equals rol.IdRolUsuario
                          where user.IdRolUsuario == rol.IdRolUsuario
                          select new UserWithRolModel()
                          {
                              IdUsuario = user.IdUsuario,
                              NombreCompleto = user.NombreCompleto,
                              Correo = user.Correo,
                              Rol = rol.Descripcion
                          }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar el usuario id '" + id + "': " + ex.Message, ex.ToString());
            }

            return usuario;
        }

        // Consulta de Lista de Usuarios, atraves del UsuarioModel (Usuarios sin clave).
        public List<UsuarioModel> GetUsuarios()
        {

            List<UsuarioModel> usuarios = new List<UsuarioModel>();

            try
            {
                this.logger.LogInformation($"Consultado Usuarios...");

                List<Usuario> users = base.GetEntities();

                foreach (Usuario user in users)
                {
                    UsuarioModel usuario = new UsuarioModel()
                    {
                        IdUsuario = user.IdUsuario,
                        NombreCompleto = user.NombreCompleto,
                        Correo = user.Correo
                    };

                    usuarios.Add(usuario);
                }

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar los usuarios: " + ex.Message, ex.ToString());
            }

            return usuarios;
        }

        // Consulta de Usuarios con su rol, atraves del UsuarioByRolModel (Usuarios sin clave).
        public List<UserWithRolModel> GetUsuariosWithRol()
        {
            List<UserWithRolModel> usuarios = new List<UserWithRolModel>();

            try
            {
                this.logger.LogInformation($"Consultado Usuarios con sus roles...");

                usuarios = (from user in base.GetEntities()
                           join rol in context.RolUsuario.ToList() on user.IdRolUsuario equals rol.IdRolUsuario
                           where user.IdRolUsuario == rol.IdRolUsuario
                           select new UserWithRolModel()
                           {
                               IdUsuario = user.IdUsuario,
                               NombreCompleto = user.NombreCompleto,
                               Correo = user.Correo,
                               Rol = rol.Descripcion
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
