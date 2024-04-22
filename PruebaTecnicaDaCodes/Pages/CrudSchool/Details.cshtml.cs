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
    public class DetailsModel : PageModel
    {
        private readonly PruebaTecnicaDaCodes.DAL.AppDbContext _context;

        public DetailsModel(PruebaTecnicaDaCodes.DAL.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
