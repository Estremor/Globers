using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class AutoresHasLibro
    {
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }

        public virtual Autor Autores { get; set; }
        public virtual Libro LibrosIsbnNavigation { get; set; }
    }
}
