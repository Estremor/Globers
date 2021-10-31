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
    public class AutoresHasLibroDomainService : DomainService, IAutoresHasLibroDomainService
    {
        #region Fields
        private readonly IRepository<AutoresHasLibro> _AutoresHasLibroRepo;
        private readonly IRepository<Autor> _autoresRepo;
        private readonly IRepository<Libro> _libroRepo;
        #endregion

        #region C'tor
        public AutoresHasLibroDomainService(IRepository<AutoresHasLibro> AutoresHasLibroRepo, IRepository<Autor> autoresRepo, IRepository<Libro> libroRepo)
        {
            _AutoresHasLibroRepo = AutoresHasLibroRepo;
            _autoresRepo = autoresRepo;
            _libroRepo = libroRepo;
        }
        #endregion

        #region Methods
        public int DeleteAutoresHasLibro(int id)
        {
            if (id > 0)
            {
                AutoresHasLibro resultEntity = _AutoresHasLibroRepo.Entity.Find(id);
                if (resultEntity is not null)
                {
                    _AutoresHasLibroRepo.Delete(resultEntity);
                }
            }
            return id;
        }

        public AutoresHasLibro GetAutoresHasLibroById(int id)
        {
            if (id > 0)
            {
                return _AutoresHasLibroRepo.ListInclude(x => x.AutoresId == id, nameof(AutoresHasLibro.Autores), nameof(AutoresHasLibro.LibrosIsbnNavigation)).FirstOrDefault();
            }
            return new AutoresHasLibro();
        }
        public AutoresHasLibro Save(AutoresHasLibro AutoresHasLibro)
        {
            if (AutoresHasLibro is not null && AutoresHasLibro.AutoresId > 0 && AutoresHasLibro.LibrosIsbn > 0)
            {
                if (_autoresRepo.Entity.Find(AutoresHasLibro.AutoresId) is not null && _libroRepo.Entity.Find(AutoresHasLibro.LibrosIsbn) is not null)
                {
                    AutoresHasLibro resultAutoresHasLibro = _AutoresHasLibroRepo.Insert(AutoresHasLibro);
                    return resultAutoresHasLibro;
                }
            }
            return new AutoresHasLibro();
        }
        #endregion
    }
}
