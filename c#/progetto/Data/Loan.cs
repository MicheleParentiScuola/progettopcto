using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace progettopcto.Data
{
    [PrimaryKey(nameof(Id))]
    public class Loan
    {
        public int Id { get; set; }
        public int BookISBN { get; set; }
        public required string UserCF { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey(nameof(BookISBN))]
        public Book? Book { get; set; }

        [ForeignKey(nameof(UserCF))]
        public User? User { get; set; }
    }
}
