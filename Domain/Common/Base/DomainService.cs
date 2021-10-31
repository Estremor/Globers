using Domain.Common.Base.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Base
{
    public abstract class DomainService : IDomainService
    {
        #region Methods

        /// <summary>
        /// Asigna el contexto de datos a todos los repositorios del servicio
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public void SetContext(DbContext context)
        {
            //Recorremos todos los miembros privados para reasignar la unidad de trabajo a los repositorios
            var members = GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => typeof(IRepository.IRepository).IsAssignableFrom(f.FieldType) || typeof(IDomainService).IsAssignableFrom(f.FieldType)).ToList();
            for (int i = 0; i < members.Count; i++)
            {
                var val = members[i].GetValue(this);
                if (val != null)
                {
                    if (val is IRepository.IRepository)
                        (val as IRepository.IRepository).Initialize(context);
                    if (val is IDomainService)
                        (val as IDomainService).SetContext(context);
                }
            }
        }

        /// <summary>
        /// Destruye la instancia
        /// </summary>
        public void Dispose()
        {
            //Recorremos cada miembro privado para destruir su instancia
            var members = GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => typeof(IDisposable).IsAssignableFrom(f.FieldType)).ToList();
            for (int i = 0; i < members.Count; i++)
            {
                var val = members[i].GetValue(this);
                if (val != null)
                    (val as IDisposable).Dispose();
            }
        }

        #endregion
    }
}
