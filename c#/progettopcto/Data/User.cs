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
        public string CF { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }
    }
}
