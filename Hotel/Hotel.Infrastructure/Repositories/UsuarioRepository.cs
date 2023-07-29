
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

            this.logger.LogInformation("Añadiendo Usuario");

            try
            {
                if (usuario == null)
                    throw new UsuarioException("El Usuario ingresado es nulo.");

                string? correo = usuario.Correo;
                string? nombre = usuario.NombreCompleto;

                this.logger.LogInformation($"Añadiendo Usuario: {nombre}, Correo: {correo}...");

                if (this.Exists(u => u.Correo == correo && u.Estado == true))
                    throw new UsuarioException($"El correo: {correo} se encuentra en uso.");

                usuario = usuario.ConvertUsuarioCreateToEntity();

                base.Add(usuario);
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
        public override void Add(Usuario[] usuarios)
        {
            try
            {
                foreach (var usuario in usuarios)
                {
                    if (usuario == null)
                        throw new UsuarioException("El Usuario ingresado es nulo.");

                    string? correo = usuario.Correo;
                    string? nombre = usuario.NombreCompleto;

                    this.logger.LogInformation($"Añadiendo Usuario: {nombre}, Correo: {correo}...");

                    if (this.Exists(u => u.Correo == correo && u.Estado == true))
                        throw new UsuarioException($"El correo: {correo} se encuentra en uso.");

                    base.Add(usuario.ConvertUsuarioCreateToEntity());
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

                Usuario usuarioToUpdate = base.GetEntity(usuario.IdUsuario);

                if (usuarioToUpdate == null)
                    throw new UsuarioException("El Usuario ha actualizar es nulo");
                if (!usuarioToUpdate.Estado)
                    throw new UsuarioException("El Usuario ha actualizar se encuentra eliminado");

                usuarioToUpdate.ConvertUsuarioUpdateToEntity(usuario);

                base.Update(usuarioToUpdate);
                base.SaveChanges();
            }
            catch (UsuarioException uex)
            {
                logger.LogError(uex.Message);
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

                        Usuario usuarioToUpdate = base.GetEntity(usuario.IdUsuario);

                        if (usuarioToUpdate == null)
                            throw new UsuarioException("El Usuario ha actualizar es nulo");
                        if (!usuarioToUpdate.Estado)
                            throw new UsuarioException("El Usuario ha actualizar se encuentra eliminado");

                        usuarioToUpdate.ConvertUsuarioUpdateToEntity(usuario);

                        base.Update(usuarioToUpdate);
                        base.SaveChanges();
                    }
                    catch (UsuarioException uex)
                    {
                        logger.LogError(uex.Message);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar Usuario con ID: " + usuario.IdUsuario + ex.Message, ex.ToString());
                    }    
                }
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

                Usuario usuarioToRemove = base.GetEntity(usuario.IdUsuario);

                if (usuarioToRemove == null)
                    throw new UsuarioException("El Usuario ha eliminar es nulo");
                if (!usuarioToRemove.Estado)
                    throw new UsuarioException("El Usuario ha eliminar ha sido antes eliminado");

                usuarioToRemove.ConvertUsuarioRemoveToEntity(usuario);

                base.Update(usuarioToRemove);

                base.SaveChanges();
            }
            catch (UsuarioException uex)
            {
                logger.LogError(uex.Message);
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

                        Usuario usuarioToRemove = base.GetEntity(usuario.IdUsuario);

                        if (usuarioToRemove == null)
                            throw new UsuarioException("El Usuario ha eliminar es nulo");
                        if (!usuarioToRemove.Estado)
                            throw new UsuarioException("El Usuario ha eliminar ha sido antes eliminado");

                        usuarioToRemove.ConvertUsuarioRemoveToEntity(usuario);

                        base.Update(usuarioToRemove);

                        base.SaveChanges();
                    }
                    catch (UsuarioException uex)
                    {
                        logger.LogError(uex.Message);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar Usuario con ID: " + usuario.IdUsuario + ex.Message, ex.ToString());
                    }  
                }
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

                Usuario user = context.Usuario.FirstOrDefault(t => t.IdUsuario == id && t.Estado == true);

                if (user == null)
                    throw new UsuarioException($"El usuario de id: {id} no existe");

                usuario = user.ConvertUsuarioEntityToModel();

            }
            catch(UsuarioException uex)
            {
                this.logger.LogError(uex.Message);

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

                usuario = (from user in base.GetEntities() where user.IdUsuario == id
                           join rol in context.RolUsuario.ToList() on user.IdRolUsuario equals rol.IdRolUsuario
                          where user.Estado == true && rol.Estado == true
                          select user.ConvertUsuarioWithRolToModel(rol)).FirstOrDefault();

                if (usuario == null)
                    throw new UsuarioException($"El usuario con id: {id} no existe.");

            }
            catch (UsuarioException uex)
            {
                this.logger.LogError(uex.Message);
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

                List<Usuario> users = base.GetEntities().Where(u => u.Estado == true).ToList();

                if (users == null)
                    throw new UsuarioException("No existen Usuarios en la base de datos");

                foreach (Usuario user in users)
                {
                    UsuarioModel usuario = user.ConvertUsuarioEntityToModel();
                    usuarios.Add(usuario);
                }

            }
            catch (UsuarioException uex)
            {
                this.logger.LogError(uex.Message);

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
                           where user.Estado == true && rol.Estado == true
                            select user.ConvertUsuarioWithRolToModel(rol)).ToList();

                if (usuarios == null)
                    throw new UsuarioException("No existen Usuarios en la base de datos");
            }
            catch (UsuarioException uex)
            {
                this.logger.LogError(uex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar usuarios" + ex.Message, ex.ToString());
            }

            return usuarios;
        }
    }
}
