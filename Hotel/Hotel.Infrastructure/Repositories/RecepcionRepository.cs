
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Extentions;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Infrastructure.Repositories
{
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<RecepcionRepository> logger;
        public RecepcionRepository(ILogger<RecepcionRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public RecepcionModel GetRecepcion(int id)
        {
            RecepcionModel recepcionModel = new RecepcionModel();

            try
            {
                this.logger.LogInformation($"Consultado recepcion id: {id}...");

                Recepcion recepcion = context.Recepcion.FirstOrDefault(t => t.IdRecepcion == id && t.Estado == true);

                if (recepcion == null)
                    throw new RecepcionException($"La recepcion de id: {id} no existe");

                recepcionModel = recepcion.ConvertRecepcionToModel();

            }
            catch (RecepcionException uex)
            {
                this.logger.LogError(uex.Message);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar la recepcion id '" + id + "': " + ex.Message, ex.ToString());
            }

            return recepcionModel;
        }
        public List<RecepcionModel> GetRecepciones()
        {
            List<RecepcionModel> recepcionModels = new List<RecepcionModel>();

            try
            {
                this.logger.LogInformation($"Consultado recepciones...");

                List<Recepcion> recepciones = base.GetEntities().Where(u => u.Estado == true).ToList();

                if (recepciones == null)
                    throw new RecepcionException("No existen recepciones en la base de datos");

                recepcionModels = recepciones.Select(r => r.ConvertRecepcionToModel()).ToList();
            }
            catch (RecepcionException uex)
            {
                this.logger.LogError(uex.Message);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al consultar las recepciones: " + ex.Message, ex.ToString());
            }

            return recepcionModels;
        }
        public override void Add(Recepcion recepcion)
        {
            this.logger.LogInformation("Añadiendo recepcion");

            try
            {
                if (recepcion == null)
                    throw new RecepcionException("La recepcion ingresada es nula.");

                this.logger.LogInformation($"Añadiendo recepcion de IdCliente: {recepcion.IdCliente}, IdHabitacion: {recepcion.IdHabitacion}...");

                recepcion = recepcion.ConvertRecepcionCreateToEntity();

                base.Add(recepcion);
                base.SaveChanges();
            }
            catch (RecepcionException ex)
            {
                this.logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al agregar recepcion: " + ex.Message, ex.ToString());
            }

        }
        public override void Update(Recepcion recepcion)
        {
            try
            {
                logger.LogInformation($"Actualizando Recepcion con ID: {recepcion.IdRecepcion}");

                Recepcion recepcionToUpdate = base.GetEntity(recepcion.IdRecepcion);

                if (recepcionToUpdate == null)
                    throw new RecepcionException("La Recepcion ha actualizar es nulo.");
                if (!recepcionToUpdate.Estado)
                    throw new RecepcionException("La Recepcion ha actualizar se encuentra eliminado.");

                recepcionToUpdate.ConvertRecepcionUpdateToEntity(recepcion);

                base.Update(recepcionToUpdate);
                base.SaveChanges();
            }
            catch (RecepcionException uex)
            {
                logger.LogError(uex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError("Error al actualizar recepcion..." + ex.Message, ex.ToString());
            }
        }
        public override void Remove(Recepcion recepcion)
        {
            try
            {
                logger.LogInformation($"Eliminando Recepcion con ID: {recepcion.IdRecepcion}");

                Recepcion recepcionToRemove = base.GetEntity(recepcion.IdRecepcion);

                if (recepcionToRemove == null)
                    throw new RecepcionException("La Recepcion ha eliminar es nulo");
                if (!recepcionToRemove.Estado)
                    throw new RecepcionException("La Recepcion ha eliminar ha sido antes eliminado");

                recepcionToRemove.ConvertRecepcionRemoveToEntity(recepcion);

                base.Update(recepcionToRemove);

                base.SaveChanges();
            }
            catch (RecepcionException uex)
            {
                logger.LogError(uex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError("Error al eliminar recepcion: " + ex.Message, ex.ToString());
            }
        }
    }
}
