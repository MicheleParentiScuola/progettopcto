using Microsoft.AspNetCore.Mvc;
using progettopcto.Data;
using progettopcto.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace progetto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
            var result = _ctx.Users.ToList()
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

            var existingUser = _ctx.Users.FirstOrDefault(u => u.Address == userDto.Address);
            if (existingUser != null)
            {
                return Conflict("User with this address already exists.");
            }

            // Aggiungi un nuovo utente
            var user = new User
            {
                CF = userDto.CF,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Address = userDto.Address,
                Password = userDto.Password // Aggiungi logica di hashing della password
            };

            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return CreatedAtAction(nameof(GetByCF), new { cf = user.CF }, userDto);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] JsonElement loginData)
        {
            string email = loginData.GetProperty("email").GetString();
            string password = loginData.GetProperty("password").GetString();

            var user = _ctx.Users.FirstOrDefault(u => u.Address == email);
            if (user == null)
            {
                return Unauthorized("Utente non trovato.");
            }

            if (user.Password != password) // Verifica la password (si consiglia di usare hashing)
            {
                return Unauthorized("Password errata.");
            }
            HttpContext.Session.SetString("UserCF", user.CF);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserSurname", user.Surname);
            return Ok(new { message = "Login effettuato con successo!" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Rimuovi le informazioni di sessione relative all'utente
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("UserSurname");
            HttpContext.Session.Remove("UserCF");

            // Reindirizza alla pagina di login (SignUp)
            return Redirect("/SignUp");
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
            user.Password = userDto.Password;
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
