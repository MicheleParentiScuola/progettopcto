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
    public class Book
    {
        public int ISBN { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required string AuthorCF { get; set; }



        [ForeignKey(nameof(AuthorCF))]
        public Author? Author { get; set; }
        public List<Loan>? Loans { get; set; }

    }
}
