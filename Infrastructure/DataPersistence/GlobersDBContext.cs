using Infrastructure.Base;
using Infrastructure.DataPersistence.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataPersistence
{
    public partial class GlobersDBContext : DbContextBase
    {
        #region C'tor
        /// <summary>
        /// Inicia el contexto de Datos
        /// </summary>
        /// <param name="dbSettings"></param>
        public GlobersDBContext(DbSettings dbSettings) : base(dbSettings)
        {
            DbSettings.ConnectionString = dbSettings.ConnectionString;
            Database.EnsureCreated();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Se usa la configuracion 
        /// </summary>
        /// <param name="dbContextOptionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
            }
        }

        /// <summary>
        /// Aplica la configuracion
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new AutoresConfiguration());
            modelBuilder.ApplyConfiguration(new AutoresHasLibroConfiguration());
            modelBuilder.ApplyConfiguration(new EditorialConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
