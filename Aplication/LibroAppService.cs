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
    public class LibroAppService : AppService, ILibroAppService
    {
        #region Fields
        private readonly ILibroDomainService _libroService;
        private readonly IMapper _mapper;
        private readonly IRepository<Libro> _repository;
        #endregion

        #region C'tor
        public LibroAppService(DbContext context, IMapper mapper) : base(context)
        {
            _libroService = context.GetDomainService<ILibroDomainService>();
            _repository = context.GetRepository<IRepository<Libro>>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public int DeleteLibro(int id)
        {
            try
            {
                _libroService.DeleteLibro(id);
                return Context.SaveChanges();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<LibroDto> GetAllLibros()
        {
            try
            {
                IEnumerable<Libro> autors = _repository.List();
                return _mapper.Map<IEnumerable<LibroDto>>(autors);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public LibroDto GetLibroById(int id)
        {
            try
            {
                Libro libro = _libroService.GetLibroById(id);
                if (libro.Isbn > 0)
                {
                    var e = _mapper.Map<LibroDto>(libro);
                    return e;
                }
                return new LibroDto { };
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public LibroDto Save(LibroDto libro)
        {
            try
            {
                Libro entity = _mapper.Map<Libro>(libro);
                entity = _libroService.Save(entity);
                Context.SaveChanges();
                return _mapper.Map<LibroDto>(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public LibroDto UpdateLibro(LibroDto libro)
        {
            try
            {
                Libro entity = _mapper.Map<Libro>(libro);
                entity = _libroService.UpdateLibro(entity);
                Context.SaveChanges();
                return _mapper.Map<LibroDto>(entity);
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
