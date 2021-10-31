using Domain.Common.Base;
using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class LibroDomainService : DomainService, ILibroDomainService
    {
        #region Fields
        private readonly IRepository<Libro> _libroRepo;
        private readonly IRepository<Editorial> _editorialRepo;
        #endregion

        #region C'tor
        public LibroDomainService(IRepository<Libro> libroRepo, IRepository<Editorial> editorialRepo)
        {
            _libroRepo = libroRepo;
            _editorialRepo = editorialRepo;
        }
        #endregion
        #region Methods
        public int DeleteLibro(int id)
        {
            if (id > 0)
            {
                Libro result = _libroRepo.Entity.Find(id);
                if (result != null)
                {
                    result = _libroRepo.Delete(result);
                    return result.Isbn;
                }
            }
            return 0;
        }

        public Libro GetLibroById(int isbn)
        {
            if (isbn > 0)
            {
                return _libroRepo.ListInclude(x => x.Isbn == isbn, nameof(Libro.Editoriales)).FirstOrDefault();
            }
            return new Libro();
        }
        public Libro Save(Libro libro)
        {
            if (libro is not null && !string.IsNullOrWhiteSpace(libro.Sipnosis) && !string.IsNullOrWhiteSpace(libro.NPaginas) && libro.EditorialesId > 0)
            {
                Editorial editorial = _editorialRepo.Entity.Find(libro.EditorialesId);
                if (editorial != null)
                {
                    Libro resultLibro = _libroRepo.List(x => x.EditorialesId == editorial.Id && x.Isbn == libro.Isbn).FirstOrDefault();
                    if (resultLibro == null)
                    {
                        libro.EditorialesId = editorial.Id;
                        return _libroRepo.Insert(libro);
                    }
                }
            }
            return new Libro();
        }

        public Libro UpdateLibro(Libro libro)
        {
            if (libro is not null && !string.IsNullOrWhiteSpace(libro.Sipnosis) && !string.IsNullOrWhiteSpace(libro.NPaginas) && libro.EditorialesId > 0)
            {
                Editorial editorial = _editorialRepo.Entity.Find(libro.EditorialesId);
                if (editorial != null)
                {
                    List<Libro> resultLibros = _libroRepo.List(x => x.EditorialesId == editorial.Id).ToList();
                    if (resultLibros.Count == 1)
                    {
                        Libro libroDb = resultLibros[0];
                        libroDb.NPaginas = libro.NPaginas;
                        libroDb.Sipnosis = libro.Sipnosis;
                        libroDb.Titulo = libro.Titulo;

                        return _libroRepo.Update(libroDb);
                    }
                }
            }
            return new Libro();
        }
        #endregion
    }
}
