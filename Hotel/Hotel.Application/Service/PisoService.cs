using Hotel.Application.Contract;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Service
{
    public class PisoService //:// IPisoServece
    {

        private readonly IPisoRepository categoriaRepository;
        private readonly ILogger<PisoService> logger;

    public PisoService(IPisoRepository pisoRepository,
                             ILogger<PisoService> logger)
    {
        this.categoriaRepository = pisoRepository;
        this.logger = logger;
    }
    


    }
}
