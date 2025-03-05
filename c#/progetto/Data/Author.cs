using Microsoft.EntityFrameworkCore;

namespace progettopcto.Data
{
    [PrimaryKey(nameof(CF))]
    public class Author
    {
        public required string CF { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public List<Book>? Books { get; set; }

    }
}
