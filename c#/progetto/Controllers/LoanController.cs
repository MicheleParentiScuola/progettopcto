using Microsoft.AspNetCore.Mvc;
using progettopcto.Data;
using progettopcto.DTO;

namespace progetto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
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
            var result = _ctx.Loans.ToList()
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

            var user = _ctx.Users.FirstOrDefault(u => u.CF == loanDto.UserCF);
            if (user == null)
            {
                return BadRequest("User does not exist.");
            }

            var book = _ctx.Books.FirstOrDefault(b => b.ISBN == loanDto.BookISBN);
            if (book == null)
            {
                return BadRequest("Book does not exist.");
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

            var book = _ctx.Books.FirstOrDefault(b => b.ISBN == loan.BookISBN);
            if (book != null)
            {
                book.IsBooked = false; 
            }

            _ctx.Loans.Remove(loan);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string userCF, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var query = _ctx.Loans.AsQueryable();

            if (!string.IsNullOrEmpty(userCF))
            {
                query = query.Where(l => l.UserCF == userCF);
            }

            if (startDate.HasValue)
            {
                query = query.Where(l => l.StartDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(l => l.EndDate <= endDate.Value);
            }

            var result = query.ToList().ConvertAll(_mapper.MapEntityToDto);
            return Ok(result);
        }

        [HttpGet("myloans")]
        public IActionResult GetMyLoans()
        {
            var userCF = HttpContext.Session.GetString("UserCF");
            if (string.IsNullOrEmpty(userCF))
            {
                return Unauthorized("User is not logged in.");
            }

            var loans = _ctx.Loans
                .Where(l => l.UserCF == userCF)
                .Select(l => new
                {
                    l.BookISBN,
                    l.StartDate,
                    l.EndDate
                })
                .ToList();

            return Ok(loans);
        }
    }
}
