using Microsoft.AspNetCore.Mvc;
using progettopcto.Data;
using progettopcto.DTO;
using System.Collections.Generic;
using System.Linq;

namespace progetto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class BookController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;
        private readonly Mapper _mapper;

        public BookController(LibraryDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BookDTO> result = _ctx.Books.ToList()
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
    }
}
