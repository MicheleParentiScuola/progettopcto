using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progettopcto.DTO
{
    class BookDTO
    {

        public int ISBN { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required string AuthorCF { get; set; }

       

    }
}
