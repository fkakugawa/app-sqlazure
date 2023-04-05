using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app_sqlazure.Pages;

public class IndexModel : PageModel
{

    public readonly IClienteRepository _repository;
    public IndexModel(IClienteRepository repository)
    {
        this._repository = repository;
        this.Cliente = new Cliente();
    }

    public void OnGet()
    {

    }
    [BindProperty]
    public Cliente Cliente {get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _repository.Add(Cliente);
            return RedirectToPage("./Index");
        }    
}
