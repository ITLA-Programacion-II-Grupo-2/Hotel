
using Hotel.Application.Core;
using Hotel.Application.Dtos.Cliente;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Hotel.Application.Service
{
    public class ClienteService : BaseService<ClienteAddDto, ClienteUpdateDto, ClienteRemoveDto>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteService> logger;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger)
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;
        }
        public override ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.clienteRepository.GetCliente();
            }
            catch (ClienteException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los Clientes";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result; 
        }

        public override ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.clienteRepository.GetCliente(id);
            }
            catch (ClienteException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los departamentos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public override ServiceResult Remove(ClienteRemoveDto model)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult Remove(ClienteRemoveDto[] model)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult Save(ClienteAddDto model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.TipoDocumento)) 
            {
                result.Message = "El nombre del cliente es requerido";
                result.Success = false;
                return result;
            }
            if (model.TipoDocumento.Length > 20)
            {
                result.Message = "El nombre del cliente tiene la longitud invalida";
                result.Success = false;
                return result;
            }
            if (model.Documento.) ;
                return result;
        }

        public override ServiceResult Save(ClienteAddDto[] model)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult Update(ClienteUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public override ServiceResult Update(ClienteUpdateDto[] model)
        {
            throw new NotImplementedException();
        }
    }
}

