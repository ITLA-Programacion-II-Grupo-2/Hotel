
using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;
using Hotel.Application.Extentions;
using Hotel.Application.Validations;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Hotel.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              ILogger<UsuarioService> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            result = UsuarioValidator.ValidateIdUsuario(id);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                result.Data = this.usuarioRepository.GetUsuario(id);
            }
            catch (UsuarioException uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el usuario de id: {id}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.usuarioRepository.GetUsuarios();
            }
            catch (UsuarioException uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los usuarios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetUsuarioWithRol(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.usuarioRepository.GetUsuarioWithRol(id);
            }
            catch (UsuarioException uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el usuario con rol de IdUsuario: {id} ";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetUsuariosWithRol()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.usuarioRepository.GetUsuariosWithRol();
            }
            catch (UsuarioException uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los usuarios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Add(UsuarioAddDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateUsuarioAdd();

            if (!result.Success)
            {
                return result;
            }
            try
            {
                var usuario = model.ConvertAddDtoToEntity();

                this.usuarioRepository.Add(usuario);

                result.Message = "Usuario agregado correctamente";
            }
            catch (UsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo el usuario de correo: {model.Correo}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Add(UsuarioAddDto[] models)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                foreach (var model in models)
                {
                    result = model.ValidateUsuarioAdd();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var usuario = model.ConvertAddDtoToEntity();
                    usuarios.Add(usuario);
                }

                this.usuarioRepository.Add(usuarios.ToArray());

                result.Message = "Usuarios agregados correctamente.";
            }
            catch (UsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Update(UsuarioUpdateDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateUsuarioUpdate();

            if (!result.Success)
            {
                return result;
            }
            try
            {
                var usuario = model.ConvertUpdateDtoToEntity();
                this.usuarioRepository.Update(usuario);

                result.Message = "Usuario Actualizado correctamente";
            }
            catch (UsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Update(UsuarioUpdateDto[] models)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                foreach (var model in models)
                {
                    result = model.ValidateUsuarioUpdate();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var usuario = model.ConvertUpdateDtoToEntity();
                    usuarios.Add(usuario);
                }

                this.usuarioRepository.Update(usuarios.ToArray());

                result.Message = "Usuarios Actualizados correctamente.";
            }
            catch (UsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Remove(UsuarioRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateUsuarioRemove();

            if (!result.Success)
            {
                return result;
            }
            try
            {
                var usuario = model.ConvertRemoveDtoToEntity();

                this.usuarioRepository.Remove(usuario);

                result.Message = "Usuario removido correctamente";
            }
            catch (UsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        
        }
        public ServiceResult Remove(UsuarioRemoveDto[] models)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                foreach (var model in models)
                {
                    result = model.ValidateUsuarioRemove();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var usuario = model.ConvertRemoveDtoToEntity();
                    usuarios.Add(usuario);
                }

                this.usuarioRepository.Remove(usuarios.ToArray());

                result.Message = "Usuarios removidos correctamente";
            }
            catch (UsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }
    }
}
