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

        //        // Agg cliente, y que no exista//

        //        public override void Add(Cliente cliente)
        //        {
        //            try
        //            {
        //        string? nombre = cliente.NombreCompleto;
        //        string? correo = cliente.Correo;
        //        string? TipoDocumento = cliente.TipoDocumento;
        //        string? Documento = cliente.Documento;

        //                this.logger.LogInformation($"Cliente añadido: {nombre}, Correo: {correo}, Tipo de Documento: {TipoDocumento}, Documento: {Documento}...");

        //                if (!this.Exists(c => c.Correo == correo))
        //                {
        //                    base.Add(cliente);
        //                    base.SaveChanges();
        //    }
        //                else
        //                {
        //                    throw new ClienteException($"El correo: {correo} ya existe.");
        //}
        //            }
        //            catch (ClienteException ex)
        //            {
        //    this.logger.LogError(ex.Message);
        //}
        //            catch (Exception ex)
        //            {
        //    this.logger.LogError("Error al añadir Cliente " + ex.ToString());
        //}
        //        }
        //        public override void Add(Cliente[] clientes)
        //        {
        //            try
        //            {
        //                foreach (var cliente in clientes)
        //                {
        //                    string? correo = cliente.Correo;
        //                    string? nombre = cliente.NombreCompleto;
        //                    string? TipoDocumento = cliente.TipoDocumento;
        //                    string? Documento = cliente.Documento;


        //                    this.logger.LogInformation($"Añadiendo cliente: {nombre}, Correo: {correo}...");

        //                    if (!this.Exists(c => c.Correo == correo))
        //                    {
        //                        base.Add(cliente);
        //                    }
        //                    else
        //                    {
        //                        throw new ClienteException($"El correo: {correo} ya existe.");
        //                    }

        //                    //Validar si el documento existe
        //                    try
        //                    {
        //                        if (!this.Exists(d => d.Documento == Documento))
        //                        {
        //                            base.Add(cliente);
        //                            base.SaveChanges();
        //                        }
        //                        else
        //                        {
        //                            throw new ClienteException($"El Docummento: {Documento} ya existe.");
        //                        }

        //                    }
        //                    catch (ClienteException ex)
        //                    {

        //                        this.logger.LogError("Error al añadir Documento " + ex.ToString());
        //                    }
        //                }

        //                base.SaveChanges();
        //            }
        //            catch (ClienteException ex)
        //            {
        //                this.logger.LogError(ex.Message);
        //            }
        //            catch (Exception ex)
        //            {
        //                this.logger.LogError("Error al agregar cliente" + ex.Message, ex.ToString());
        //            }
        //        }


        //Actualizar el cliente//


        // Agregar el cliente y su correo
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


        ////Actualizar el cliente//
        //public override void Update(Cliente cliente)
        //{
        //    logger.LogInformation("Actualizando clientes");
        //    try
        //    {
        //        Cliente clienteToUpdate = this.GetEntity(cliente.IdCliente);
        //        clienteToUpdate.IdCliente = cliente.IdCliente;
        //        clienteToUpdate.NombreCompleto = cliente.NombreCompleto;
        //        clienteToUpdate.FechaModificacion= cliente.FechaModificacion;
        //        clienteToUpdate.TipoDocumento = cliente.TipoDocumento;
        //        clienteToUpdate.Documento = cliente.Documento;
        //        clienteToUpdate.Correo = cliente.Correo;
        //        clienteToUpdate.Estado = cliente.Estado;

        //        this.context.Cliente.Update(clienteToUpdate);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.LogError("Error actualizando el cliente", ex.ToString());
        //        this.context.SaveChanges();
        //    }
        //}

        //Remover cliente//

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

        //public override void Remove(Cliente cliente)
        //{
        //    try
        //    {
        //        Cliente clienteToRemove = this.GetEntity(cliente.IdCliente);

        //        clienteToRemove.ClienteEliminacion = cliente.ClienteEliminacion;
        //        clienteToRemove.FechaEliminacion = cliente.FechaEliminacion;

        //        this.context.Cliente.Update(clienteToRemove);
        //        this.context.SaveChanges();
        //    }
        //    catch(Exception ex)
        //    {
        //        this.logger.LogError("Error eliminando el departamento", ex.ToString());
        //    }
        //}
        //public override void Remove(Cliente[] clientes)
        //{
        //    try
        //    {
        //        foreach (var cliente in clientes)
        //        {
        //            try
        //            {
        //                logger.LogInformation($"Eliminando id Cliente: {cliente.IdCliente}");
        //                base.Remove(cliente);
        //            }
        //            catch (Exception ex)
        //            {
        //                logger.LogError("Error al eliminar id cliente: " + cliente.IdCliente + ex.Message, ex.ToString());
        //            }
        //        }
        //        base.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError("Error al eliminar cliente: " + ex.Message, ex.ToString());
        //    }
        //}

        // Consultando Cliente

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


        // Consulta de cliente, atraves del clienteModel 
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


        // Consulta de Lista de cliente, atraves del ClienteModel 
       
        public List<ClienteModel> GetCliente()
        {

                List<ClienteModel> clientes = new List<ClienteModel>();

                try
                {
                    this.logger.LogInformation($"Consultado Clientes");

                    List<Cliente> clins = base.GetEntities().Where(c => c.Estado == true).ToList();

                    if (clins == null)
                        throw new ClienteException("No existe clientes en la base de datos");

                }
                catch (ClienteException uex)
                {
                    this.logger.LogError(uex.Message);

                }
                catch (Exception ex)
                {
                    this.logger.LogError("Error al consultar clientes " + ex.Message, ex.ToString());
                }

                return clientes;
            }



        //Consultar cliente



        //public ClienteModel GetCliente(int id)
        //{
        //    ClienteModel cliente = new ClienteModel();


        //    try
        //    {
        //        // this.logger.LogInformation($"Consultado id del cliente {id} ");

        //        Cliente clien = base.GetEntity(id);

        //        cliente = new ClienteModel()
        //        {
        //            IdCliente = clien.IdCliente,
        //            NombreCompleto = clien.NombreCompleto,
        //            Correo = clien.Correo,
        //            TipoDocumento = clien.TipoDocumento,
        //            Documento = clien.Documento,
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.LogError("Error al obtener cliente '" + id + "': " + ex.Message, ex.ToString());
        //    }

        //    return cliente;
        //}

        //// Consultar lista de Cliente
        //public List<ClienteModel> GetCliente()
        //{
        //    List<ClienteModel> clientes = new List<ClienteModel>();

        //    try
        //    {
        //        this.logger.LogInformation($"Consultado Clientes: ");

        //        List<Cliente> users = base.GetEntities();

        //        foreach (Cliente user in users)
        //        {
        //            ClienteModel cliente = new ClienteModel()
        //            {
        //                IdCliente = user.IdCliente,
        //                NombreCompleto = user.NombreCompleto,
        //                Correo = user.Correo,
        //                TipoDocumento = user.TipoDocumento,
        //                Documento = user.Documento,
        //            };

        //            clientes.Add(cliente);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.LogError("Error al consultar clientes " + ex.Message, ex.ToString());
        //    }

        //    return clientes;
        //}


    }
}
