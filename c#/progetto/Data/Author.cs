using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace progettopcto.Data
{
    [PrimaryKey(nameof(CF))]
    class Author
    {
        public required string CF { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public List<Book>? Books { get; set; }

    }
}
