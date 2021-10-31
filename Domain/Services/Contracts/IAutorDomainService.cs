using Domain.Common.Base.Contract;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services.Contracts
{
    public interface IAutorDomainService : IDomainService
    {
        #region Method
        Autor Save(Autor autor);
        Autor GetAutorById(int id);
        Autor UpdateAutor(Autor autor);
        int DeleteAutor(int id);
        #endregion
    }
}
