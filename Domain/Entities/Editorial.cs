using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Editorial
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
