using Hotel.Domain.Entities;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Core;
using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Hotel.Infrastructure.Repositories
{
    public class PisoRepository : BaseRepository<Piso>, IPisoRepository
    {
        private readonly ILogger logger;
        private readonly HotelContext context;

        public PisoRepository(ILogger<PisoRepository> logger, HotelContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }
        public List<PisoModels> GetPiso(int id)
        {
             List<PisoModels> pisos = new List<PisoModels>();
            try
            {
                this.logger.LogInformation($"Pase por aqui: {id}");

                var pisos1 = (from piso in GetEntities()
                              select new PisoModels
                              {
                                  IdPiso = piso.IdPiso,


                              }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo los pisos: {ex.Message}", ex.ToString());

            }
            return pisos;


        }

    }

}