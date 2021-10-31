using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Autor
    {
        public Autor()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
