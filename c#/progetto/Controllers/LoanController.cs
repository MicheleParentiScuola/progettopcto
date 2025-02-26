using Microsoft.AspNetCore.Mvc;
using progettopcto.Data;
using progettopcto.DTO;
using System.Collections.Generic;
using System.Linq;

namespace progetto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class LoanController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;
        private readonly Mapper _mapper;

        public LoanController(LibraryDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<LoanDTO> result = _ctx.Loans.ToList()
                .ConvertAll(_mapper.MapEntityToDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loan = _ctx.Loans.FirstOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            var loanDto = _mapper.MapEntityToDto(loan);
            return Ok(loanDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LoanDTO loanDto)
        {
            if (loanDto == null)
            {
                return BadRequest();
            }
            var loan = _mapper.MapDtoToEntity(loanDto);
            _ctx.Loans.Add(loan);
            _ctx.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loanDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LoanDTO loanDto)
        {
            if (loanDto == null || loanDto.Id != id)
            {
                return BadRequest();
            }
            var loan = _ctx.Loans.FirstOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            loan.BookISBN = loanDto.BookISBN;
            loan.UserCF = loanDto.UserCF;
            loan.StartDate = loanDto.StartDate;
            loan.EndDate = loanDto.EndDate;
            _ctx.Loans.Update(loan);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var loan = _ctx.Loans.FirstOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            _ctx.Loans.Remove(loan);
            _ctx.SaveChanges();
            return NoContent();
        }
    }
}
