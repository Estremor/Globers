using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globers.Models
{
    public class AutoresHasLibroModel
    {
        public string Autor { get; set; }
        public string Libro { get; set; }
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }
    }
}
