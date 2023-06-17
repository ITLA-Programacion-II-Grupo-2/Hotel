using Hotel.Domain.Entities;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
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

        public ClienteRepository(ILogger<ClienteRepository>logger,HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        // Agg cliente, datos y validar correo
        public override void Add(Cliente cliente)
        {
            try
            {
                string? nombre = cliente.NombreCompleto;
                string? correo = cliente.Correo;
                string? TipoDocumento = cliente.TipoDocumento;
                int Documento = cliente.Documento;

                this.logger.LogInformation($"Cliente añadido: {nombre}, Correo: {correo}, Tipo de Documento: {TipoDocumento}, Documento: {Documento}...");

                if (!this.Exists(c => c.Correo == correo))
                {
                    base.Add(cliente);
                    base.SaveChanges();
                }
                else
                {
                    throw new ClienteException($"El correo: {correo} ya existe.");
                }
            }
            catch (ClienteException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al añadir Cliente " + ex.ToString());
            }
        }
        public override void Add(Cliente[] clientes)
        {
            try
            {
                foreach (var cliente in clientes)
                {
                    string? correo = cliente.Correo;
                    string? nombre = cliente.NombreCompleto;
                    string? TipoDocumento = cliente.TipoDocumento;
                    int Documento = cliente.Documento;


                    this.logger.LogInformation($"Añadiendo cliente: {nombre}, Correo: {correo}...");

                    if (!this.Exists(c => c.Correo == correo))
                    {
                        base.Add(cliente);
                    }
                    else
                    {
                        throw new ClienteException($"El correo: {correo} ya existe.");
                    }

                    //Validar si el documento existe
                    try
                    {
                        if (!this.Exists(d => d.Documento == Documento))
                        {
                            base.Add(cliente);
                            base.SaveChanges();
                        }
                        else
                        {
                            throw new ClienteException($"El Docummento: {Documento} ya existe.");
                        }
                    
                    }
                    catch (ClienteException ex)
                    {

                        this.logger.LogError("Error al añadir Documento " + ex.ToString());
                    }
                }

                base.SaveChanges();
            }
            catch (ClienteException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar cliente" + ex.Message, ex.ToString());
            }
        }
        public override void Update(Cliente cliente)
        {
            try
            {
                logger.LogInformation($"Actualizando cliente {cliente.IdCliente}");

                base.Update(cliente);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar cliente" + ex.Message, ex.ToString());
            }
        }
        public override void Update(Cliente[] clientes)
        {
            logger.LogInformation("Actualizando clientes");
            try
            {
                foreach (var cliente in clientes)
                {
                    try
                    {
                        logger.LogInformation($"Actualizando Id del cliente {cliente.IdCliente}");
                        base.Update(cliente);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al actualizar Id del cliente" + ex.Message, ex.ToString());
                    }
                }
                base.SaveChanges();
            }

            catch (Exception ex)
            {
                logger.LogError("Error al actualizar cliente" + ex.Message, ex.ToString());
            }
        }
        public override void Remove(Cliente cliente)
        {
            try
            {
                logger.LogInformation($"Eliminando id cliente: {cliente.IdCliente}");

                base.Remove(cliente);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar cliente: " + ex.Message, ex.ToString());
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
                        logger.LogInformation($"Eliminando id Cliente: {cliente.IdCliente}");
                        base.Remove(cliente);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error al eliminar id cliente: " + cliente.IdCliente + ex.Message, ex.ToString());
                    }
                }
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar cliente: " + ex.Message, ex.ToString());
            }
        }

        // Consultando Cliente
        public ClienteModel GetCliente(int id)
        {
            ClienteModel cliente = new ClienteModel();


            try
            {
                this.logger.LogInformation($"Consultado id del cliente {id} ");

                Cliente user = base.GetEntity(id);

                cliente = new ClienteModel()
                {
                    IdCliente = user.IdCliente,
                    NombreCompleto = user.NombreCompleto,
                    Correo = user.Correo,
                    TipoDocumento = user.TipoDocumento,
                    Documento = user.Documento,
            };

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar cliente '" + id + "': " + ex.Message, ex.ToString());
            }

            return cliente;
        }

        public List<ClienteModel> GetCliente()
        {
            throw new NotImplementedException();
        }

        ClienteModel IClienteRepository.GetCliente(int id)
        {
            throw new NotImplementedException();
        }

        List<ClienteModel> IClienteRepository.GetCliente()
        {
            throw new NotImplementedException();
        }
    }

}
