using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HealthDeptApp.Models;

namespace HealthDeptApp.Pages.Establishments
{
    public class CreateModel : PageModel
    {
        private readonly HealthDeptApp.Models.AppDbContext _context;

        public CreateModel(HealthDeptApp.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Establishment Establishment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Establishment.Add(Establishment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}