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

        public required Boolean IsBooked {  get; set; }

        [ForeignKey(nameof(AuthorCF))]
        public Author? Author { get; set; }
        public List<Loan>? Loans { get; set; }

    }
}
