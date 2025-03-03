using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using progettopcto.Data;
using progettopcto.DTO;
using System.Collections.Generic;
using System.Linq;

namespace progetto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;
        private readonly Mapper _mapper;

        public AuthorController(LibraryDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        [HttpGet("api/author/{cf}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(string cf)
        {
            var author = await _ctx.Authors
                .Where(a => a.CF == cf)
                .Select(a => new AuthorDTO
                {
                    CF = a.CF,
                    Name = a.Name,
                    Surname = a.Surname
                })
                .FirstOrDefaultAsync();

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Authors.ToList()
                .ConvertAll(_mapper.MapEntityToDto);
            return Ok(result);
        }

        [HttpGet("{cf}")]
        public IActionResult GetByCF(string cf)
        {
            var author = _ctx.Authors.FirstOrDefault(a => a.CF == cf);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = _mapper.MapEntityToDto(author);
            return Ok(authorDto);
        }


        [HttpPost]
        public IActionResult Create([FromBody] AuthorDTO authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest();
            }
            var existingAuthor = _ctx.Authors.FirstOrDefault(a => a.CF == authorDto.CF);
            if (existingAuthor != null)
            {
                return Conflict("Author with this CF already exists.");
            }
            var author = _mapper.MapDtoToEntity(authorDto);
            _ctx.Authors.Add(author);
            _ctx.SaveChanges();
            return CreatedAtAction(nameof(GetByCF), new { cf = author.CF }, authorDto);
        }

        [HttpPut("{cf}")]
        public IActionResult Update(string cf, [FromBody] AuthorDTO authorDto)
        {
            if (authorDto == null || authorDto.CF != cf)
            {
                return BadRequest();
            }
            var author = _ctx.Authors.FirstOrDefault(a => a.CF == cf);
            if (author == null)
            {
                return NotFound();
            }
            author.Name = authorDto.Name;
            author.Surname = authorDto.Surname;
            _ctx.Authors.Update(author);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{cf}")]
        public IActionResult Delete(string cf)
        {
            var author = _ctx.Authors.FirstOrDefault(a => a.CF == cf);
            if (author == null)
            {
                return NotFound();
            }
            _ctx.Authors.Remove(author);
            _ctx.SaveChanges();
            return NoContent();
        }
    }
}
