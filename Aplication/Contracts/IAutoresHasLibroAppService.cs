using Aplication.Dtos;
using Domain.Common.Base.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Contracts
{
    public interface IAutoresHasLibroAppService : IAppService
    {
        #region Method
        AutoresHasLibroDto Save(AutoresHasLibroDto autor);
        AutoresHasLibroDto GetAutoresHasLibroById(int id);
        int DeleteAutoresHasLibro(int id);
        IEnumerable<AutoresHasLibroDto> GetAllAutoresHasLibro();
        #endregion
    }
}
