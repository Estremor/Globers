using Aplication.Dtos;
using Domain.Common.Base.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Contracts
{
    public interface ILibroAppService : IAppService
    {
        #region Method
        LibroDto Save(LibroDto libro);
        LibroDto GetLibroById(int id);
        LibroDto UpdateLibro(LibroDto libro);
        int DeleteLibro(int id);
        IEnumerable<LibroDto> GetAllLibros();
        #endregion
    }
}
