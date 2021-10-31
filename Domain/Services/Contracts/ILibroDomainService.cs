using Domain.Common.Base.Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Contracts
{
    public interface ILibroDomainService : IDomainService
    {
        #region Method
        Libro Save(Libro libro);
        Libro GetLibroById(int id);
        Libro UpdateLibro(Libro libro);
        int DeleteLibro(int id);
        #endregion
    }
}
