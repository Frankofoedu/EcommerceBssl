using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcommerceBssl.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EcommerceBssl.Pages.Admin.SubCat
{
    public class CreateModel : PageModel
    {
        private readonly EcommerceBssl.Data.ApplicationDbContext _context;
        
        [BindProperty]
        public IFormFile BannerImage { get; set; }

        public CreateModel(EcommerceBssl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MainCategoryList"] = new SelectList(_context.MainCategories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SubCategory SubCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (BannerImage!=null && BannerImage.Length>0)
            {
                var fileName = DateTime.Now.Ticks.ToString() + BannerImage.FileName;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\productimages", fileName);
                await BannerImage.CopyToAsync(new FileStream(filepath, FileMode.Create));
                
                SubCategory.BannerImage = fileName;
                _context.SubCategories.Add(SubCategory);
                await _context.SaveChangesAsync();

            }

            return RedirectToPage("./Index");
        }
    }
}