using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Libro
    {
        public Libro()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Isbn { get; set; }
        public int EditorialesId { get; set; }
        public string Titulo { get; set; }
        public string Sipnosis { get; set; }
        public string NPaginas { get; set; }

        public virtual Editorial Editoriales { get; set; }
        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
