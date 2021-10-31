using Aplication.Dtos;
using Domain.Common.Base.Contract;
using System.Collections.Generic;

namespace Aplication.Contracts
{
    public interface IAutorAppService : IAppService
    {
        #region Method
        AutorDto Save(AutorDto autor);
        AutorDto GetAutorById(int id);
        AutorDto UpdateAutor(AutorDto autor);
        int DeleteAutor(int id);
        IEnumerable<AutorDto> GetAllAutor();
        #endregion
    }
}
