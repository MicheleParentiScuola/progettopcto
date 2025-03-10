﻿using Microsoft.EntityFrameworkCore;

namespace progettopcto.Data
{
    [PrimaryKey(nameof(CF))]
    public class User
    {
        public required string CF { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Address { get; set; }
        public required string Password { get; set; } // Aggiunta della proprietà Password
        public List<Loan>? Loans { get; set; }
    }
}
