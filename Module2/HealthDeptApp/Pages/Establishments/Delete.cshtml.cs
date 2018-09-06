using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthDeptApp.Models;

namespace HealthDeptApp.Pages.Establishments
{
    public class DeleteModel : PageModel
    {
        private readonly HealthDeptApp.Models.AppDbContext _context;

        public DeleteModel(HealthDeptApp.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Establishment Establishment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Establishment = await _context.Establishment
                .Include(e => e.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Establishment == null)
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

            Establishment = await _context.Establishment.FindAsync(id);

            if (Establishment != null)
            {
                _context.Establishment.Remove(Establishment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
