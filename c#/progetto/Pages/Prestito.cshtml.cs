using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using progettopcto.Data;
using progettopcto.DTO;

namespace progetto.Pages;

class PrestitoModel : PageModel
{
    private readonly LibraryDbContext _context;
    public PrestitoModel(LibraryDbContext context)
    {
        _context = context;
        Books = new List<BookDTO>();
    }

    public List<BookDTO> Books { get; set; }

    public void OnGet()
    {
        Books = _context.Books
            .Select(book => new BookDTO
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Genre = book.Genre,
                AuthorCF = book.AuthorCF
            })
            .ToList();

        foreach (var book in Books)
        {
            Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Genre: {book.Genre}, AuthorCF: {book.AuthorCF}");
            
        }
    }
}
