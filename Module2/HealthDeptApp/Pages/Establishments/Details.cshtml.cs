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
    public class DetailsModel : PageModel
    {
        private readonly HealthDeptApp.Models.AppDbContext _context;

        public DetailsModel(HealthDeptApp.Models.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
