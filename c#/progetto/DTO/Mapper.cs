using progettopcto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progettopcto.DTO
{
    internal class Mapper
    {
        public AuthorDTO MapEntityToDto(Author entity)
        {
            return new AuthorDTO()
            {
                CF = entity.CF,
                Name = entity.Name,
                Surname = entity.Surname
            };
        }

        public Author MapDtoToEntity(AuthorDTO author)
        {
            return new Author()
            {
                CF = author.CF,
                Name = author.Name,
                Surname = author.Surname
            };
        }

        public BookDTO MapEntityToDto(Book entity)
        {
            return new BookDTO()
            {
                ISBN = entity.ISBN,
                Title = entity.Title,
                Genre = entity.Genre,
                AuthorCF = entity.AuthorCF
            };
        }

        public Book MapDtoToEntity(BookDTO bookDto)
        {
            return new Book
            {
                ISBN = bookDto.ISBN,
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                AuthorCF = bookDto.AuthorCF
            };
        }

        public LoanDTO MapEntityToDto(Loan entity)
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

        public Loan MapDtoToEntity(LoanDTO loanDto)
        {
            return new Loan
            {
                Id = loanDto.Id,
                BookISBN = loanDto.BookISBN,
                UserCF = loanDto.UserCF,
                StartDate = loanDto.StartDate,
                EndDate = loanDto.EndDate
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

        public User MapDtoToEntity(UserDTO userDto)
        {
            return new User
            {
                CF = userDto.CF,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Address = userDto.Address
            };
        }
    }
}
