
using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RolUsuario;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

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

        public ServiceResult GetRolUsuarios()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult GetUsuariosByRol(string rol)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.rolUsuarioRepository;
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

        public ServiceResult GetUsuariosByRoles()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Save(RolUsuarioAddDto model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Save(RolUsuarioAddDto[] model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Update(RolUsuarioUpdateDto model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Update(RolUsuarioUpdateDto[] model)
        {
            throw new System.NotImplementedException();
        }
        public ServiceResult Remove(RolUsuarioRemoveDto model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Remove(RolUsuarioRemoveDto[] model)
        {
            throw new System.NotImplementedException();
        }
    }
}
