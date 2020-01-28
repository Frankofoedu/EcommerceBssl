using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceBssl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBssl.Pages.Customer.Products
{
    public class GroupModel : PageModel
    {
        private readonly EcommerceBssl.Data.ApplicationDbContext _context;

        public GroupModel(EcommerceBssl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SubCategory SubCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? sgid)
        {
            if (sgid != null)
            {
                //Get the subcategory that has the id into a property
                SubCategory = await _context.SubCategories.Include(m => m.Products).ThenInclude(l=>l.Images).FirstOrDefaultAsync(n => n.Id == sgid.Value);

                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}