using Domain.Common.Base;
using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class AutorDomainService : DomainService, IAutorDomainService
    {
        #region Fields
        private readonly IRepository<Autor> _autorRepo;
        #endregion

        #region C'tor
        public AutorDomainService(IRepository<Autor> autorRepo)
        {
            _autorRepo = autorRepo;
        }
        #endregion

        #region Methods
        public int DeleteAutor(int id)
        {
            if (id > 0)
            {
                Autor resultEntity = _autorRepo.Entity.Find(id);
                if (resultEntity is not null)
                {
                    _autorRepo.Delete(resultEntity);
                }
            }
            return id;
        }

        public Autor GetAutorById(int id)
        {
            if (id > 0)
            {
                return _autorRepo.List(x => x.Id == id).FirstOrDefault();
            }
            return new Autor();
        }
        public Autor Save(Autor autor)
        {
            if (autor is not null && !string.IsNullOrWhiteSpace(autor.Nombre))
            {
                Autor resultAutor = _autorRepo.Insert(autor);
                return resultAutor;
            }
            return new Autor();
        }

        public Autor UpdateAutor(Autor autor)
        {
            if (autor is not null && autor.Id > 0)
            {
                Autor autorDb = _autorRepo.Entity.Find(autor.Id);
                if (autorDb != null)
                {
                    autorDb.Nombre = autor.Nombre;
                    autorDb.Apellido = autor.Apellido;
                    return _autorRepo.Update(autorDb);
                }
            }
            return new Autor();
        }
        #endregion
    }
}
