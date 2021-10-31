using Aplication.Contracts;
using Aplication.Dtos;
using AutoMapper;
using Domain.Common;
using Domain.Common.Base;
using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class AutoresHasLibroAppService : AppService, IAutoresHasLibroAppService
    {
        #region Fields
        private readonly IAutoresHasLibroDomainService _autorLibroService;
        private readonly IMapper _mapper;
        private readonly IRepository<AutoresHasLibro> _repository;
        #endregion

        #region C'tor
        public AutoresHasLibroAppService(DbContext context, IMapper mapper) : base(context)
        {
            _autorLibroService = context.GetDomainService<IAutoresHasLibroDomainService>();
            _repository = context.GetRepository<IRepository<AutoresHasLibro>>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public int DeleteAutoresHasLibro(int id)
        {
            try
            {
                int result = _autorLibroService.DeleteAutoresHasLibro(id);
                Context.SaveChanges();
                return result;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<AutoresHasLibroDto> GetAllAutoresHasLibro()
        {
            try
            {
                IEnumerable<AutoresHasLibro> autors = _repository.
                    Entity
                    .Include(nameof(AutoresHasLibro.Autores))
                    .Include(nameof(AutoresHasLibro.LibrosIsbnNavigation));
                return _mapper.Map<IEnumerable<AutoresHasLibroDto>>(autors);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public AutoresHasLibroDto GetAutoresHasLibroById(int id)
        {
            try
            {
                AutoresHasLibro autorLibro = _autorLibroService.GetAutoresHasLibroById(id);
                if (autorLibro.AutoresId > 0 && autorLibro.LibrosIsbn > 0)
                {
                    return _mapper.Map<AutoresHasLibroDto>(autorLibro);
                }
                return new AutoresHasLibroDto { };
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public AutoresHasLibroDto Save(AutoresHasLibroDto autoresHasLibro)
        {
            try
            {
                AutoresHasLibro entity = _mapper.Map<AutoresHasLibro>(autoresHasLibro);
                entity = _autorLibroService.Save(entity);
                Context.SaveChanges();
                return _mapper.Map<AutoresHasLibroDto>(entity);
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
