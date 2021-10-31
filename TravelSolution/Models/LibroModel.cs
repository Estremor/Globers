using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globers.Models
{
    public class LibroModel
    {
        public int isbn { get; set; }
        public int editorial { get; set; }
        public string titulo { get; set; }
        public string sipnosis { get; set; }
        public string nPaginas { get; set; }
    }
}
