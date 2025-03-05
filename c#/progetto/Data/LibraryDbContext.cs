using Microsoft.EntityFrameworkCore;

namespace progettopcto.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        protected LibraryDbContext() : base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { CF = "CF001", Name = "Mario", Surname = "Rossi" },
                new Author { CF = "CF002", Name = "Luigi", Surname = "Verdi" },
                new Author { CF = "CF003", Name = "Giovanni", Surname = "Bianchi" },
                new Author { CF = "CF004", Name = "Paolo", Surname = "Neri" },
                new Author { CF = "CF005", Name = "Francesca", Surname = "Gialli" },
                new Author { CF = "CF006", Name = "Anna", Surname = "Blu" },
                new Author { CF = "CF007", Name = "Marco", Surname = "Giallo" },
                new Author { CF = "CF008", Name = "Luca", Surname = "Viola" },
                new Author { CF = "CF009", Name = "Sara", Surname = "Rosa" },
                new Author { CF = "CF010", Name = "Elena", Surname = "Marrone" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { ISBN = 1001, Title = "Il Signore degli Anelli", Genre = "Fantasy", AuthorCF = "CF001", IsBooked = false },
                new Book { ISBN = 1002, Title = "Harry Potter", Genre = "Fantasy", AuthorCF = "CF002", IsBooked = false },
                new Book { ISBN = 1003, Title = "Il Codice Da Vinci", Genre = "Thriller", AuthorCF = "CF003", IsBooked = false },
                new Book { ISBN = 1004, Title = "Il Nome della Rosa", Genre = "Storico", AuthorCF = "CF004", IsBooked = false },
                new Book { ISBN = 1005, Title = "La Divina Commedia", Genre = "Classico", AuthorCF = "CF005", IsBooked = false },
                new Book { ISBN = 1006, Title = "1984", Genre = "Distopico", AuthorCF = "CF006", IsBooked = false },
                new Book { ISBN = 1007, Title = "Il Piccolo Principe", Genre = "Fiaba", AuthorCF = "CF007", IsBooked = false },
                new Book { ISBN = 1008, Title = "Moby Dick", Genre = "Avventura", AuthorCF = "CF008", IsBooked = false },
                new Book { ISBN = 1009, Title = "Orgoglio e Pregiudizio", Genre = "Romantico", AuthorCF = "CF009", IsBooked = false },
                new Book { ISBN = 1010, Title = "Guerra e Pace", Genre = "Storico", AuthorCF = "CF010", IsBooked = false }
            );

            modelBuilder.Entity<User>().HasData(
                new User { CF = "USER001", Name = "Anna", Password = "Password01!", Surname = "Rossi", Address = "anna.rossi@example.com" },
                new User { CF = "USER002", Name = "Marco", Password = "Password01!", Surname = "Verdi", Address = "marco.verdi@example.com" },
                new User { CF = "USER003", Name = "Luca", Password = "Password01!", Surname = "Bianchi", Address = "luca.bianchi@example.com" },
                new User { CF = "USER004", Name = "Sara", Password = "Password01!", Surname = "Neri", Address = "sara.neri@example.com" },
                new User { CF = "USER005", Name = "Elena", Password = "Password01!", Surname = "Gialli", Address = "elena.gialli@example.com" },
                new User { CF = "USER006", Name = "Giulia", Password = "Password01!", Surname = "Blu", Address = "giulia.blu@example.com" },
                new User { CF = "USER007", Name = "Davide", Password = "Password01!", Surname = "Giallo", Address = "davide.giallo@example.com" },
                new User { CF = "USER008", Name = "Matteo", Password = "Password01!", Surname = "Viola", Address = "matteo.viola@example.com" },
                new User { CF = "USER009", Name = "Chiara", Password = "Password01!", Surname = "Rosa", Address = "chiara.rosa@example.com" },
                new User { CF = "USER010", Name = "Federico", Password = "Password01!", Surname = "Marrone", Address = "federico.marrone@example.com" }
            );

            DateTime start = new DateTime(2025, 1, 1, 12, 0, 0);
            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, BookISBN = 1001, UserCF = "USER001", StartDate = start.AddDays(-10), EndDate = start.AddDays(10) },
                new Loan { Id = 2, BookISBN = 1002, UserCF = "USER002", StartDate = start.AddDays(-9), EndDate = start.AddDays(11) },
                new Loan { Id = 3, BookISBN = 1003, UserCF = "USER003", StartDate = start.AddDays(-8), EndDate = start.AddDays(12) },
                new Loan { Id = 4, BookISBN = 1004, UserCF = "USER004", StartDate = start.AddDays(-7), EndDate = start.AddDays(13) },
                new Loan { Id = 5, BookISBN = 1005, UserCF = "USER005", StartDate = start.AddDays(-6), EndDate = start.AddDays(14) },
                new Loan { Id = 6, BookISBN = 1006, UserCF = "USER006", StartDate = start.AddDays(-5), EndDate = start.AddDays(15) },
                new Loan { Id = 7, BookISBN = 1007, UserCF = "USER007", StartDate = start.AddDays(-4), EndDate = start.AddDays(16) },
                new Loan { Id = 8, BookISBN = 1008, UserCF = "USER008", StartDate = start.AddDays(-3), EndDate = start.AddDays(17) },
                new Loan { Id = 9, BookISBN = 1009, UserCF = "USER009", StartDate = start.AddDays(-2), EndDate = start.AddDays(18) },
                new Loan { Id = 10, BookISBN = 1010, UserCF = "USER010", StartDate = start.AddDays(-1), EndDate = start.AddDays(19) }
            );
        }
    }
}
