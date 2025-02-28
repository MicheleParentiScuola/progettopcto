using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new Author { CF = "A1", Name = "Author1", Surname = "Surname1" },
                new Author { CF = "A2", Name = "Author2", Surname = "Surname2" },
                new Author { CF = "A3", Name = "Author3", Surname = "Surname3" },
                new Author { CF = "A4", Name = "Author4", Surname = "Surname4" },
                new Author { CF = "A5", Name = "Author5", Surname = "Surname5" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { ISBN = 1, Title = "Book1", Genre = "Genre1", AuthorCF = "A1" },
                new Book { ISBN = 2, Title = "Book2", Genre = "Genre2", AuthorCF = "A2" },
                new Book { ISBN = 3, Title = "Book3", Genre = "Genre3", AuthorCF = "A3" },
                new Book { ISBN = 4, Title = "Book4", Genre = "Genre4", AuthorCF = "A4" },
                new Book { ISBN = 5, Title = "Book5", Genre = "Genre5", AuthorCF = "A5" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { CF = "U1", Name = "User1", Password = "Password01!", Surname = "Surname1", Address = "Address1" },
                new User { CF = "U2", Name = "User2", Password = "Password01!", Surname = "Surname2", Address = "Address2" },
                new User { CF = "U3", Name = "User3", Password = "Password01!", Surname = "Surname3", Address = "Address3" },
                new User { CF = "U4", Name = "User4", Password = "Password01!", Surname = "Surname4", Address = "Address4" },
                new User { CF = "U5", Name = "User5", Password = "Password01!", Surname = "Surname5", Address = "Address5" }
            );
            DateTime start = new DateTime(2025, 1, 1, 12, 0, 0);
            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, BookISBN = 1, UserCF = "U1", StartDate = start.AddDays(-10), EndDate = start.AddDays(10) },
                new Loan { Id = 2, BookISBN = 2, UserCF = "U2", StartDate = start.AddDays(-9), EndDate = start.AddDays(11) },
                new Loan { Id = 3, BookISBN = 3, UserCF = "U3", StartDate = start.AddDays(-8), EndDate = start.AddDays(12) },
                new Loan { Id = 4, BookISBN = 4, UserCF = "U4", StartDate = start.AddDays(-7), EndDate = start.AddDays(13) },
                new Loan { Id = 5, BookISBN = 5, UserCF = "U5", StartDate = start.AddDays(-6), EndDate = start.AddDays(14) }
            );
        }

    }
}
