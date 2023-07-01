using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Cliente;
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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteService> logger;
        private IEnumerable<object> models;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger)
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;
        }

        public object ClienteRepository { get; private set; }

        public ServiceResult Add(ClienteAddDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateClienteAdd();

            if (!result.Success)
            {
                return result;
            }
            try
            {
                var cliente = model.ConvertAddDtoToEntity();

                result.Message = "Cliente añadido correctamente";
            }
            catch (ClienteException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }

            return result;
        }

        public ServiceResult Add(ClienteAddDto[] models)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetCliente()
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

        public ServiceResult GetCliente(int id)
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
                result.Message = "Error obteniendo los clientes";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetClientes()
        {
            throw new NotImplementedException();
        }

        public ServiceResult Remove()
        {
            throw new NotImplementedException();
        }

        public ServiceResult Remove(ClienteRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateClienteRemove();

            if (!result.Success)
            {
                return result;
            }
            try
            {
                var cliente = model.ConvertRemoveDtoToEntity();

                this.clienteRepository.Remove(cliente);

                result.Message = "Cliente eliminado";
            }
            catch (ClienteException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"No fue posible eliminar cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }

        public ServiceResult Remove(ClienteRemoveDto[] models)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<Cliente> clientes = new List<Cliente>();

                foreach (var model in models)
                {
                    result = model.ValidateClienteRemove();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var cliente = model.ConvertRemoveDtoToEntity();
                    clientes.Add(cliente);
                }

                this.clienteRepository.Remove(clientes.ToArray());

                result.Message = "Cliente eliminado";
            }
            catch (ClienteException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"No se pudo eliminar el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }

        public ServiceResult Update(ClienteUpdateDto model)
        {
            ServiceResult result = new ServiceResult();
            result = model.ValidateClienteUpdate();

            if (!result.Success)
            {
                return result;
            }
            try
            {
                var cliente = model.ConvertUpdateDtoToEntity();
                this.clienteRepository.Update(cliente);

                result.Message = "Se actualizo el cliente";
            }
            catch (ClienteException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"No fue posible actualizar el cliente";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(ClienteUpdateDto[] models)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<Cliente> clientes = new List<Cliente>();

                foreach (var model in models)
                {
                    result = model.ValidateClienteUpdate();

                    if (!result.Success)
                    {
                        return result;
                    }

                    var cliente = model.ConvertUpdateDtoToEntity();
                    clientes.Add(cliente);
                }

                this.clienteRepository.Update(clientes.ToArray());

                result.Message = "  Cliente actualizado";
            }
            catch (ClienteException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"El cliente no pudo ser actualizado";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }

}


