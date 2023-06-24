
using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

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

        public ServiceResult GetUsuario(int id)
        {
            ServiceResult result = new ServiceResult();

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
                result.Message = "Error obteniendo los usuarios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetUsuariosWithRol()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetUsuarioWithRol(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Remove(UsuarioRemoveDto model)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Remove(UsuarioRemoveDto[] model)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Save(UsuarioAddDto model)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Save(UsuarioAddDto[] model)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(UsuarioUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(UsuarioUpdateDto[] model)
        {
            throw new NotImplementedException();
        }
    }
}
