using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcommerceBssl.Data;

namespace EcommerceBssl.Pages.Admin.MainCategory
{
    public class CreateModel : PageModel
    {
        private readonly EcommerceBssl.Data.ApplicationDbContext _context;

        public CreateModel(EcommerceBssl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Data.MainCategory MainCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MainCategories.Add(MainCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}