using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace progettopcto.Data
{
    [PrimaryKey(nameof(ISBN))]
    class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string AuthorCF { get; set; }

        [ForeignKey(nameof(AuthorCF))]
        public Author? Author { get; set; }



    }
}
