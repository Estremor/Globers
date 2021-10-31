using Domain.Common.Base.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Base
{
    /// <summary>
    /// Clase base de los servicios de aplicación
    /// </summary>
    public abstract class AppService : IAppService
    {
        #region Properties

        /// <summary>
        /// Contexto de datos
        /// </summary>
        public DbContext Context { get; private set; }
        /// <summary>
        /// Contexto Http
        /// </summary>
        public IHttpContextAccessor HttpAppContext { get; private set; }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public AppService(DbContext context) => Context = context;

        #endregion
    }
}
