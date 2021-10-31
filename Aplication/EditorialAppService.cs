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
    public class EditorialAppService : AppService, IEditorialAppService
    {
        #region Fields
        private readonly IEditorialDomainService _editorialService;
        private readonly IMapper _mapper;
        private readonly IRepository<Editorial> _repository;
        #endregion

        #region C'tor
        public EditorialAppService(DbContext context, IMapper mapper) : base(context)
        {
            _editorialService = context.GetDomainService<IEditorialDomainService>();
            _repository = context.GetRepository<IRepository<Editorial>>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public int DeleteEditorial(int id)
        {
            try
            {
                int result = _editorialService.DeleteEditorial(id);
                Context.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<EditorialDto> GetAllEditorial()
        {
            try
            {
                IEnumerable<Editorial> autors = _repository.List();
                return _mapper.Map<IEnumerable<EditorialDto>>(autors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public EditorialDto GetEditorialById(int id)
        {
            try
            {
                Editorial editorial = _editorialService.GetEditorialById(id);
                if (!string.IsNullOrWhiteSpace(editorial.Nombre))
                {
                    return _mapper.Map<EditorialDto>(editorial);
                }
                return new EditorialDto { };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public EditorialDto Save(EditorialDto autor)
        {
            try
            {
                Editorial entity = _mapper.Map<Editorial>(autor);
                entity = _editorialService.Save(entity);
                Context.SaveChanges();
                return _mapper.Map<EditorialDto>(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public EditorialDto UpdateEditorial(EditorialDto autor)
        {
            try
            {
                Editorial entity = _mapper.Map<Editorial>(autor);
                entity = _editorialService.UpdateEditorial(entity);
                Context.SaveChanges();
                return _mapper.Map<EditorialDto>(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        #endregion
    }
}
