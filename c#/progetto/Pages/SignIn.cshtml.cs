using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using progettopcto.Data;
using System.ComponentModel.DataAnnotations;

namespace progetto.Pages;

class SignINModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly LibraryDbContext _context;

    public SignINModel(ILogger<IndexModel> logger, LibraryDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [BindProperty]
    public required InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        [EmailAddress]
        public required string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = new User
        {
            CF = Guid.NewGuid().ToString(), // Genera un nuovo CF univoco
            Name = Input.Name,
            Surname = Input.Surname,
            Address = Input.Address,
            Password = Input.Password // Assicurati di gestire la password in modo sicuro
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}
/*
 * using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YourNamespace.Data; // Assicurati di sostituire con il namespace corretto
using YourNamespace.Models; // Assicurati di sostituire con il namespace corretto

public class SignInModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public SignInModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = new User
        {
            Nome = Input.Nome,
            Cognome = Input.Cognome,
            Email = Input.Email,
            Password = Input.Password // Assicurati di gestire la password in modo sicuro
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}
*/