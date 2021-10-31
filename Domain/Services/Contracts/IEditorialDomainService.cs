using Domain.Common.Base.Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Contracts
{
    public interface IEditorialDomainService : IDomainService
    {
        #region Method
        Editorial Save(Editorial editorial);
        Editorial GetEditorialById(int id);
        Editorial UpdateEditorial(Editorial editorial);
        int DeleteEditorial(int id);
        #endregion
    }
}
