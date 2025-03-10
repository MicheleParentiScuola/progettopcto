﻿using Microsoft.AspNetCore.Mvc;
using progettopcto.Data;
using progettopcto.DTO;


namespace progetto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;
        private readonly Mapper _mapper;

        public BookController(LibraryDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        /*
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Il controller funziona!");
        }
        */

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Books.ToList()
                .ConvertAll(_mapper.MapEntityToDto);
            return Ok(result);
        }

        [HttpGet("{isbn}")]
        public IActionResult GetByISBN(int isbn)
        {
            var book = _ctx.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.MapEntityToDto(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDTO bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest();
            }
            var existingBook = _ctx.Books.FirstOrDefault(b => b.ISBN == bookDto.ISBN);
            if (existingBook != null)
            {
                return Conflict("Book with this ISBN already exists.");
            }
            var book = _mapper.MapDtoToEntity(bookDto);
            _ctx.Books.Add(book);
            _ctx.SaveChanges();
            return CreatedAtAction(nameof(GetByISBN), new { isbn = book.ISBN }, bookDto);
        }

        [HttpPut("{isbn}")]
        public IActionResult Update(int isbn, [FromBody] BookDTO bookDto)
        {
            if (bookDto == null || bookDto.ISBN != isbn)
            {
                return BadRequest();
            }
            var book = _ctx.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = bookDto.Title;
            book.Genre = bookDto.Genre;
            book.AuthorCF = bookDto.AuthorCF;
            book.IsBooked = bookDto.IsBooked;
            _ctx.Books.Update(book);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpPut("return/{isbn}")]
        public IActionResult ReturnBook(int isbn)
        {
            var book = _ctx.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                return NotFound();
            }
            book.IsBooked = false;
            _ctx.Books.Update(book);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{isbn}")]
        public IActionResult Delete(int isbn)
        {
            var book = _ctx.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                return NotFound();
            }
            _ctx.Books.Remove(book);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpPut("borrow/{isbn}")]
        public IActionResult BorrowBook(int isbn)
        {
            var book = _ctx.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                return NotFound();
            }
            book.IsBooked = true;
            _ctx.Books.Update(book);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string title, [FromQuery] string author, [FromQuery] string genre)
        {
            var query = _ctx.Books.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(b => b.AuthorCF.Contains(author));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(b => b.Genre.Contains(genre));
            }

            var result = query.ToList().ConvertAll(_mapper.MapEntityToDto);
            return Ok(result);
        }

        [HttpGet("genre/{genre}")]
        public IActionResult GetByGenre(string genre)
        {
            var books = _ctx.Books.Where(b => b.Genre == genre).ToList();
            var bookDtos = books.ConvertAll(_mapper.MapEntityToDto);
            return Ok(bookDtos);
        }

        [HttpGet("all")]
        public IActionResult GetAllBooks()
        {
            var books = _ctx.Books.ToList().ConvertAll(_mapper.MapEntityToDto);
            return Ok(books);
        }
    }
}
