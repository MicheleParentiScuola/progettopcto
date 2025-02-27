using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progettopcto.Data
{
    [PrimaryKey(nameof(CF))]
    class User
    {
        public required string CF { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Address { get; set; }
        public required string Password { get; set; } // Aggiunta della proprietà Password
        public List<Loan>? Loans { get; set; }
    }
}
