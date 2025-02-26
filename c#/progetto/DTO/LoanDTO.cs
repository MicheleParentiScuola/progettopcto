using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progettopcto.DTO
{
    class LoanDTO
    {
        public int Id { get; set; }
        public int BookISBN { get; set; }
        public string UserCF { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
