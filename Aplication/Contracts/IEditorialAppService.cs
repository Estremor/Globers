using Aplication.Dtos;
using Domain.Common.Base.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Contracts
{
    public interface IEditorialAppService : IAppService
    {
        #region Method
        EditorialDto Save(EditorialDto editorial);
        EditorialDto GetEditorialById(int id);
        EditorialDto UpdateEditorial(EditorialDto editorial);
        int DeleteEditorial(int id);
        IEnumerable<EditorialDto> GetAllEditorial();
        #endregion
    }
}
