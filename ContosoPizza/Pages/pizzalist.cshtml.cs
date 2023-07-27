using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContosoPizza.Pages
{
    public class pizzalistmodel : PageModel
    {
        [BindProperty]
        public Pizza newPizza { get; set; } = default!;
        private readonly PizzaService _service;
        public IList<Pizza> pizzalist { get; set; } = default!;

        public pizzalistmodel(PizzaService service)

        {
            _service = service;
        }
        

        public void OnGet()
        {
            pizzalist = _service.GetPizzas();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || newPizza == null)
            {
                return Page();
            }

            _service.AddPizza(newPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);

            return RedirectToAction("Get");
        }
    }
}
