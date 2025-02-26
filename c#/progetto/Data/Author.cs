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
        public string CF { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book>? Books { get; set; }

    }
}
