using Aplication;
using Aplication.Contracts;
using Domain.Common;
using Domain.IRepository;
using Domain.Services;
using Domain.Services.Contracts;
using Infrastructure.DataPersistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI
{
    /// <summary>
    /// Contiene la Configuracion de la injeccion de dependencias
    /// </summary>
    public static class DependencyInjectionProfile
    {
        /// <summary>
        /// Registra Las dependencias, como se resuelven
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterProfile(IServiceCollection services)
        {
            #region Context
            DBExtensions.services = services;
            /*Registramos el contexto*/
            services.AddTransient<Microsoft.EntityFrameworkCore.DbContext, DataPersistence.GlobersDBContext>(s =>
            {
                Base.DbSettings settings = s.GetService<Base.DbSettings>();
                return new DataPersistence.GlobersDBContext(settings);
            });
            #endregion


            #region Repositories
            /*Resolvemos los repositorios Genericos*/
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region Application

            services.AddTransient<IAutorAppService, AutorAppService>();
            services.AddTransient<IAutoresHasLibroAppService, AutoresHasLibroAppService>();
            services.AddTransient<ILibroAppService, LibroAppService>();
            services.AddTransient<IEditorialAppService, EditorialAppService>();
            #endregion

            #region Domain
            services.AddTransient<IAutorDomainService, AutorDomainService>();
            services.AddTransient<IAutoresHasLibroDomainService, AutoresHasLibroDomainService>();
            services.AddTransient<ILibroDomainService, LibroDomainService>();
            services.AddTransient<IEditorialDomainService, EditorialDomainService>();

            #endregion
        }
    }
}
