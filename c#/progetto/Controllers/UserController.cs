using Microsoft.AspNetCore.Mvc;
using progettopcto.Data;
using progettopcto.DTO;
using System.Collections.Generic;
using System.Linq;

namespace progetto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class UserController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;
        private readonly Mapper _mapper;

        public UserController(LibraryDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserDTO> result = _ctx.Users.ToList()
                .ConvertAll(_mapper.MapEntityToDto);
            return Ok(result);
        }

        [HttpGet("{cf}")]
        public IActionResult GetByCF(string cf)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.CF == cf);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.MapEntityToDto(user);
            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }
            var user = _mapper.MapDtoToEntity(userDto);
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return CreatedAtAction(nameof(GetByCF), new { cf = user.CF }, userDto);
        }

        [HttpPut("{cf}")]
        public IActionResult Update(string cf, [FromBody] UserDTO userDto)
        {
            if (userDto == null || userDto.CF != cf)
            {
                return BadRequest();
            }
            var user = _ctx.Users.FirstOrDefault(u => u.CF == cf);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Address = userDto.Address;
            user.Password = userDto.Password; // Aggiunta della gestione della password
            _ctx.Users.Update(user);
            _ctx.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{cf}")]
        public IActionResult Delete(string cf)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.CF == cf);
            if (user == null)
            {
                return NotFound();
            }
            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
            return NoContent();
        }
    }
}
