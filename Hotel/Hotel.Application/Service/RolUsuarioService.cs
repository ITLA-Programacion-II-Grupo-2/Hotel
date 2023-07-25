
using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RolUsuario;
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
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository rolUsuarioRepository;
        private readonly ILogger<RolUsuarioService> logger;

        public RolUsuarioService(IRolUsuarioRepository rolUsuarioRepository,
                                 ILogger<RolUsuarioService> logger)
        {
            this.rolUsuarioRepository = rolUsuarioRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.rolUsuarioRepository.GetRolesUsuario();
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los roles de usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            result = RolUsuarioValidator.ValidateIdRolUsuario(id);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                result.Data = this.rolUsuarioRepository.GetRolUsuario(id);
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los roles de usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetUsuariosByRol(string rol)
        {
            ServiceResult result = new ServiceResult();

            result = RolUsuarioValidator.ValidateRol(rol);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                result.Data = this.rolUsuarioRepository.GetUsuariosByRol(rol);
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el rol: {rol} y sus usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetUsuariosByRoles()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.rolUsuarioRepository.GetUsuariosByRoles();
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo los roles y sus usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Add(RolUsuarioAddDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateRolUsuarioAdd();

            if (!result.Success)
                {
                    return result;
                }
            try
            {
                var rolUsuario = model.ConvertAddDtoToEntity();
                this.rolUsuarioRepository.Add(rolUsuario);

                result.Message = "Rol de usuario agregado correctamente";
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo el rol de usuario: {model.Descripcion}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Add(RolUsuarioAddDto[] models)
        {
            ServiceResult result = new ServiceResult();
           
            try
            {
                List<RolUsuario> rolesUsuario = new List<RolUsuario>();

                foreach (var model in models)
                {
                    result = model.ValidateRolUsuarioAdd();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var rolUsuario = model.ConvertAddDtoToEntity();
                    rolesUsuario.Add(rolUsuario);
                }

                this.rolUsuarioRepository.Add(rolesUsuario.ToArray());

                result.Success = true;
                result.Message = "Roles de usuario agregados correctamente";
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error añadiendo los roles de usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Update(RolUsuarioUpdateDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateRolUsuarioUpdate();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var rolUsuario = model.ConvertUpdateDtoEntity();
                this.rolUsuarioRepository.Update(rolUsuario);

                result.Message = "Rol de usuario actualizado correctamente";
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando el rol de usuario: {model.Descripcion}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Update(RolUsuarioUpdateDto[] models)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<RolUsuario> rolesUsuario = new List<RolUsuario>();

                foreach (var model in models)
                {
                    result = model.ValidateRolUsuarioUpdate();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var rolUsuario = model.ConvertUpdateDtoEntity();
                    rolesUsuario.Add(rolUsuario);
                }

                this.rolUsuarioRepository.Update(rolesUsuario.ToArray());

                result.Message = "Roles de usuario actualizados correctamente.";
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando roles de usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Remove(RolUsuarioRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateRolUsuarioRemove();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var rolUsuario = model.ConvertRemoveEntity();
                this.rolUsuarioRepository.Remove(rolUsuario);

                result.Message = "Rol de usuario removido correctamente";
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo el rol de usuario: {model.IdRolUsuario}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Remove(RolUsuarioRemoveDto[] models)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<RolUsuario> rolesUsuario = new List<RolUsuario>();

                foreach (var model in models)
                {
                    result = model.ValidateRolUsuarioRemove();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var rolUsuario = model.ConvertRemoveEntity();
                    rolesUsuario.Add(rolUsuario);
                }
                
                this.rolUsuarioRepository.Remove(rolesUsuario.ToArray());

                result.Message = "Roles de usuario removidos correctamente";
            }
            catch (RolUsuarioException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo roles de usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
