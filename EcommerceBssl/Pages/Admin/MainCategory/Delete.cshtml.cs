using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceBssl.Data;

namespace EcommerceBssl.Pages.Admin.MainCategory
{
    public class DeleteModel : PageModel
    {
        private readonly EcommerceBssl.Data.ApplicationDbContext _context;

        public DeleteModel(EcommerceBssl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Data.MainCategory MainCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainCategory = await _context.MainCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (MainCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainCategory = await _context.MainCategories.FindAsync(id);

            if (MainCategory != null)
            {
                _context.MainCategories.Remove(MainCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
