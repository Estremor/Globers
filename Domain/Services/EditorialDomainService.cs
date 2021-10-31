using Domain.Common.Base;
using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EditorialDomainService : DomainService, IEditorialDomainService
    {
        #region Fields
        private readonly IRepository<Editorial> _editorialRepo;
        #endregion

        #region C'tor
        public EditorialDomainService(IRepository<Editorial> editorialRepo)
        {
            _editorialRepo = editorialRepo;
        }
        #endregion

        #region Methods
        public int DeleteEditorial(int id)
        {
            if (id > 0)
            {
                Editorial resultEntity = _editorialRepo.Entity.Find(id);
                if (resultEntity is not null)
                {
                    _editorialRepo.Delete(resultEntity);
                }
            }
            return id;
        }

        public Editorial GetEditorialById(int id)
        {
            if (id > 0)
            {
                return _editorialRepo.List(x => x.Id == id).FirstOrDefault();
            }
            return new Editorial();
        }
        public Editorial Save(Editorial editorial)
        {
            if (editorial is not null && !string.IsNullOrWhiteSpace(editorial.Nombre))
            {
                Editorial resultEditorial = _editorialRepo.Insert(editorial);
                return resultEditorial;
            }
            return new Editorial();
        }

        public Editorial UpdateEditorial(Editorial editorial)
        {
            if (editorial is not null && editorial.Id > 0)
            {
                Editorial editorialDb = _editorialRepo.Entity.Find(editorial.Id);
                if (editorialDb != null)
                {
                    editorialDb.Nombre = editorial.Nombre;
                    editorialDb.Sede = editorial.Sede;
                    return _editorialRepo.Update(editorialDb);
                }
            }
            return new Editorial();
        }
        #endregion
    }
}
