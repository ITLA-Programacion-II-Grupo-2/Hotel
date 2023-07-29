using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Hotel.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly ILogger<ClienteRepository> logger;
        private readonly HotelContext context;

        public ClienteRepository(ILogger<ClienteRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }
        // Anadir cliente
        public override void Add(Cliente cliente)
        {

            this.logger.LogInformation("Añadiendo cliente");

            try
            {
                if (cliente == null)
                    throw new ClienteException("El cliente no puede ser nulo");

                string? correo = cliente.Correo;
                string? nombre = cliente.NombreCompleto;

                this.logger.LogInformation($"Añadiendo Cliente: {nombre}, Correo: {correo}...");

                if (this.Exists(u => u.Correo == correo && u.Estado == true))
                    throw new ClienteException($"Este correo: {correo} ya existe");

                cliente.ConvertClienteCreateToEntity();

                base.Add(cliente);
                base.SaveChanges();
            }
            catch (ClienteException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar usuario: " + ex.Message, ex.ToString());
            }

        }
        public override void Add(Cliente[] clientes)
        {
            try
            {
                foreach (var cliente in clientes)
                {
                    if (cliente == null)
                        throw new ClienteException("El cliente no puede ser nulo.");

                    string? correo = cliente.Correo;
                    string? nombre = cliente.NombreCompleto;

                    this.logger.LogInformation($"Añadiendo cliente: {nombre}, Correo: {correo}...");

                    if (this.Exists(u => u.Correo == correo && u.Estado == true))
                        throw new ClienteException($"Este correo: {correo} ya esxiste");

                    cliente.ConvertClienteCreateToEntity();

                    base.Add(cliente);
                }

                base.SaveChanges();
            }
            catch (ClienteException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar cliente: " + ex.Message, ex.ToString());
            }
        }

        // Actualizar cliente
        public override void Update(Cliente cliente)
        {
            try
            {
                logger.LogInformation($"Actualizando Id del cliente: {cliente.IdCliente}");

                Cliente clienteToUpdate = base.GetEntity(cliente.IdCliente);

                if (clienteToUpdate == null)
                    throw new ClienteException("El cliente no puede ser nulo");
                if (!clienteToUpdate.Estado)
                    throw new ClienteException("El cliente esta eliminado");

                clienteToUpdate.ConvertClienteUpdateToEntity(cliente);

                base.Update(clienteToUpdate);
                base.SaveChanges();
            }
            catch (ClienteException uex)
            {
                logger.LogError(uex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError("Error, no se pudo actualizar el cliente" + ex.Message, ex.ToString());
            }
        }
        public override void Update(Cliente[] clientes)
        {
            logger.LogInformation("Actualizando cliente");
            try
            {
                foreach (var cliente in clientes)
                {
                    try
                    {
                        logger.LogInformation($"Actualizando cliente con ID: {cliente.IdCliente}");

                        Cliente clienteToUpdate = base.GetEntity(cliente.IdCliente);

                        if (clienteToUpdate == null)
                            throw new ClienteException("El cliente no puede ser nulo");
                        if (!clienteToUpdate.Estado)
                            throw new ClienteException("El cliente no existe, ha siido eliminado");

                        clienteToUpdate.ConvertClienteUpdateToEntity(cliente);

                        base.Update(clienteToUpdate);
                        base.SaveChanges();
                    }
                    catch (ClienteException uex)
                    {
                        logger.LogError(uex.Message);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar Id del cliente: " + cliente.IdCliente + ex.Message, ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar cliente" + ex.Message, ex.ToString());
            }
        }

        // Remover cliente 
        public override void Remove(Cliente cliente)
        {
            try
            {
                logger.LogInformation($"Eliminando Id del cliente: {cliente.IdCliente}");

                Cliente clienteToRemove = base.GetEntity(cliente.IdCliente);

                if (clienteToRemove == null)
                    throw new ClienteException("El cliente ha eliminar no puede ser nulo");
                if (!clienteToRemove.Estado)
                    throw new ClienteException("Este cliente ya fue eliminado antes");

                clienteToRemove.ConvertClienteRemoveToEntity(cliente);

                base.Update(clienteToRemove);

                base.SaveChanges();
            }
            catch (ClienteException uex)
            {
                logger.LogError(uex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar cliente " + ex.Message, ex.ToString());
            }
        }
        public override void Remove(Cliente[] clientes)
        {
            try
            {
                foreach (var cliente in clientes)
                {
                    try
                    {
                        logger.LogInformation($"Eliminando Id del cliente {cliente.IdCliente}");

                        Cliente clienteToRemove = base.GetEntity(cliente.IdCliente);

                        if (clienteToRemove == null)
                            throw new ClienteException("El cliente no puede ser nulo");
                        if (!clienteToRemove.Estado)
                            throw new ClienteException("Este cliente ya fue eliminado antes");

                        clienteToRemove.ConvertClienteRemoveToEntity(cliente);

                        base.Update(clienteToRemove);

                        base.SaveChanges();
                    }
                    catch (ClienteException uex)
                    {
                        logger.LogError(uex.Message);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error eliminando ID del cliente" + cliente.IdCliente + ex.Message, ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error, no se pudo eliminar cliente: " + ex.Message, ex.ToString());
            }
        }


        // Consultar cliente 
        public ClienteModel GetCliente(int id)
        {
            ClienteModel cliente = new ClienteModel();

            try
            {
                this.logger.LogInformation($"Consultado Id del cliente: {id}...");

                Cliente cl = context.Cliente.FirstOrDefault(t => t.IdCliente == id && t.Estado == true);

                if (cl == null)
                    throw new ClienteException($"El Id del cliente: {id} no existe");


            }
            catch (ClienteException uex)
            {
                this.logger.LogError(uex.Message);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar Id del cliente '" + id + "': " + ex.Message, ex.ToString());
            }

            return cliente;
        }


        // Consultar una lista de clientes
        public List<ClienteModel> GetCliente()
        {

                List<ClienteModel> clientes = new List<ClienteModel>();

                try
                {
                    this.logger.LogInformation($"Consultado Clientes");

                    List<Cliente> clins = base.GetEntities().Where(c => c.Estado == true).ToList();
                    
                    clientes = clins.Select(c => new ClienteModel()
                    {
                        IdCliente = c.IdCliente,
                        NombreCompleto = c.NombreCompleto,
                        Correo = c.Correo,
                        Documento = c.Documento,
                        TipoDocumento = c.TipoDocumento
                    }).ToList();

                    if (clins == null)
                        throw new ClienteException("No existen Clientes");

                }
                catch (ClienteException uex)
                {
                    this.logger.LogError(uex.Message);

                }
                catch (Exception ex)
                {
                    this.logger.LogError("Error, no se pudo consultar clinte" + ex.Message, ex.ToString());
                }

                return clientes;
            }

    }
}
