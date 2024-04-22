using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDaCodes.DAL;
using PruebaTecnicaDaCodes.Models;

namespace PruebaTecnicaDaCodes.Pages.CrudSchool
{
    public class DeleteModel : PageModel
    {
        private readonly PruebaTecnicaDaCodes.DAL.AppDbContext _context;

        public DeleteModel(PruebaTecnicaDaCodes.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public School School { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools.FirstOrDefaultAsync(m => m.Id == id);

            if (school == null)
            {
                return NotFound();
            }
            else
            {
                School = school;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools.FindAsync(id);
            if (school != null)
            {
                School = school;
                _context.Schools.Remove(School);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
