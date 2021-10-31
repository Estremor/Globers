using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class AutoresHasLibroDto
    {
        public string Autor { get; set; }
        public string Libro { get; set; }
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }
    }
}
