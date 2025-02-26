using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace progetto.Pages;

public class SignINModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public SignINModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
