using Domain.Common.Base.Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Contracts
{
    public interface IAutoresHasLibroDomainService : IDomainService
    {
        #region Method
        AutoresHasLibro Save(AutoresHasLibro autoresHas);
        AutoresHasLibro GetAutoresHasLibroById(int id);
        int DeleteAutoresHasLibro(int id);
        #endregion
    }
}
