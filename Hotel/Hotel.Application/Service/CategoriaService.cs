using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dto.Categoria;
using Hotel.Application.Extentions;
using Hotel.Application.Validations;
using Hotel.Infrastructure.Exceptions;
using Hotel.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;



namespace Hotel.Application.Service
{
    public  class CategoriaService : ICategoriaService 
    {

        private readonly ICategoriaRepository categoriaRepository;
        private readonly ILogger<CategoriaService> logger;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                 ILogger<CategoriaService> logger)
        {
            this.categoriaRepository = categoriaRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();


            try
            {
                var Categoria = this.categoriaRepository.GetEntities();
                result.Data = Categoria;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error Al Obtener una categoria";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            result = CategoriaValidations.ValidaCategorias(id);
            if ((bool)!result.Success)
            {
                return result;
            }


            try
            {
                var Categoria = this.categoriaRepository.GetEntity(id);
                result.Data = Categoria;
            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al obtener una categoria";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
          
        }

        public ServiceResult Add(CategoriaAddDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.validandocapAdd();
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var categoria = model.ConvertDtoAddToEntity();
                this.categoriaRepository.Add(categoria);

                result.Message = "Rol de usuario agregado correctamente";
            }
            catch (CategoriaException ruex)
            {
                result.Success = false;
                result.Message = ruex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error añadiendo una categoria : {model.Descripcion}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;


        }

        public ServiceResult Update(CategoriaUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            result = CategoriaValidations.validandocapUpdate(model);

            if ((bool)!result.Success)
            {
                return result;
            }
            try
            {
                var categoria = model.ConvertDtoUpdateToEntity();

                this.categoriaRepository.Add(categoria);



                result.Message = "La categoria fue actualizada satisfactoriamente.";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al agregar una categoria.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }


            return result;
        }

        public ServiceResult Remove(CategoriaRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            result = CategoriaValidations.validandocapRemove(model);

            if ((bool)!result.Success)
            {
                return result;
            }

            try
            {
                var categoria = model.ConvertDtoRemoveToEntity();

                this.categoriaRepository.Remove(categoria);

                result.Message = "categoria eliminada correctamente.";

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al eliminar una categoria.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

       
        

    }

}
