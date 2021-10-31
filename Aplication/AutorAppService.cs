using Aplication.Contracts;
using Aplication.Dtos;
using AutoMapper;
using Domain.Common;
using Domain.Common.Base;
using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aplication
{
    public class AutorAppService : AppService, IAutorAppService
    {
        #region Fields
        private readonly IAutorDomainService _autorService;
        private readonly IMapper _mapper;
        private readonly IRepository<Autor> _repository;
        #endregion

        #region C'tor
        public AutorAppService(DbContext context, IMapper mapper) : base(context)
        {
            _autorService = context.GetDomainService<IAutorDomainService>();
            _repository = context.GetRepository<IRepository<Autor>>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public int DeleteAutor(int id)
        {
            try
            {
                int result = _autorService.DeleteAutor(id);
                Context.SaveChanges();
                return result;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<AutorDto> GetAllAutor()
        {
            try
            {
                IEnumerable<Autor> autors = _repository.List();
                return _mapper.Map<IEnumerable<AutorDto>>(autors);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public AutorDto GetAutorById(int id)
        {
            try
            {
                Autor autor = _autorService.GetAutorById(id);
                if (!string.IsNullOrWhiteSpace(autor.Nombre))
                {
                    return _mapper.Map<AutorDto>(autor);
                }
                return new AutorDto { };
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public AutorDto Save(AutorDto autor)
        {
            try
            {
                Autor entity = _mapper.Map<Autor>(autor);
                entity = _autorService.Save(entity);
                Context.SaveChanges();
                return _mapper.Map<AutorDto>(entity);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public AutorDto UpdateAutor(AutorDto autor)
        {
            try
            {
                Autor entity = _mapper.Map<Autor>(autor);
                entity = _autorService.UpdateAutor(entity);
                Context.SaveChanges();
                return _mapper.Map<AutorDto>(entity);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }
        #endregion
    }
}
