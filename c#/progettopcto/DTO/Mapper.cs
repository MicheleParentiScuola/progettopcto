using progettopcto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progettopcto.DTO
{
    class Mapper
    {
        public AuthorDTO MapEntityToDto(Author entity)
        {
            return new AuthorDTO
            {
                CF = entity.CF,
                Name = entity.Name,
                Surname = entity.Surname
            };
        }
        public Author MapDtoToEntity(AuthorDTO author)
        {
            return new Author
            {
                CF = author.CF,
                Name = author.Name,
                Surname = author.Surname
            };
        }
        
        public Book MapDtoToEntity(Book book)
        {
            return new Book
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Genre = book.Genre,
                AuthorCF = book.AuthorCF
            };
        }
        public BookDTO MapEntityToDto(Book entity)
        {
            return new BookDTO
            {
                ISBN = entity.ISBN,
                Title = entity.Title,
                Genre = entity.Genre,
                AuthorCF = entity.AuthorCF
            };
        }

        public Loan MapEntityToDto(Loan loan)
        {
            return new Loan
            {
                Id = loan.Id,
                BookISBN = loan.BookISBN,
                UserCF = loan.UserCF,
                StartDate = loan.StartDate,
                EndDate = loan.EndDate
            };
        }
        public LoanDTO MapDtoToEntity(LoanDTO entity)
        {
            return new LoanDTO
            {
                Id = entity.Id,
                BookISBN = entity.BookISBN,
                UserCF = entity.UserCF,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }
        public User MapDtoToEntity(User user)
        {
            return new User
            {
                CF = user.CF,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address
            };
        }
        public UserDTO MapEntityToDto(User entity)
        {
            return new UserDTO
            {
                CF = entity.CF,
                Name = entity.Name,
                Surname = entity.Surname,
                Address = entity.Address
            };
        }
        
    }
}
