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
using System.Linq.Expressions;

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

        // Agg cliente, y que no exista

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


        //Actualizar el cliente//

        public override void Update(Cliente cliente)
        {
            logger.LogInformation("Actualizando clientes");
            try
            {
                Cliente clienteToUpdate = this.GetEntity(cliente.IdCliente);
                clienteToUpdate.IdCliente = cliente.IdCliente;
                clienteToUpdate.NombreCompleto = cliente.NombreCompleto;
                clienteToUpdate.FechaModificacion= cliente.FechaModificacion;
                clienteToUpdate.TipoDocumento = cliente.TipoDocumento;
                clienteToUpdate.Documento = cliente.Documento;
                clienteToUpdate.Correo = cliente.Correo;
                clienteToUpdate.Estado = cliente.Estado;

                this.context.Cliente.Update(clienteToUpdate);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando el cliente", ex.ToString());
                this.context.SaveChanges();
            }
        }

        //Remover cliente//
        public override void Remove(Cliente cliente)
        {
            try
            {
                Cliente clienteToRemove = this.GetEntity(cliente.IdCliente);

                clienteToRemove.ClienteEliminacion = cliente.ClienteEliminacion;
                clienteToRemove.FechaEliminacion = cliente.FechaEliminacion;

                this.context.Cliente.Update(clienteToRemove);
                this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error eliminando el departamento", ex.ToString());
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
                // this.logger.LogInformation($"Consultado id del cliente {id} ");

                Cliente clien = base.GetEntity(id);

                cliente = new ClienteModel()
                {
                    IdCliente = clien.IdCliente,
                    NombreCompleto = clien.NombreCompleto,
                    Correo = clien.Correo,
                    TipoDocumento = clien.TipoDocumento,
                    Documento = clien.Documento,
                };

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al obtener cliente '" + id + "': " + ex.Message, ex.ToString());
            }

            return cliente;
        }


        // Consultar lista de Cliente
        public List<ClienteModel> GetCliente()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            try
            {
                this.logger.LogInformation($"Consultado Clientes: ");

                List<Cliente> users = base.GetEntities();

                foreach (Cliente user in users)
                {
                    ClienteModel cliente = new ClienteModel()
                    {
                        IdCliente = user.IdCliente,
                        NombreCompleto = user.NombreCompleto,
                        Correo = user.Correo,
                        TipoDocumento = user.TipoDocumento,
                        Documento = user.Documento,
                    };

                    clientes.Add(cliente);
                }

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar clientes " + ex.Message, ex.ToString());
            }

            return clientes;
        }
        
        
    }
}
