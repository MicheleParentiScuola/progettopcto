using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace progetto.Pages;

public class SignUpModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public SignUpModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
