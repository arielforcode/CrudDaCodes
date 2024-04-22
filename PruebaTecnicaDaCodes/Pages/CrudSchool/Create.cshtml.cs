using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaTecnicaDaCodes.DAL;
using PruebaTecnicaDaCodes.Models;

namespace PruebaTecnicaDaCodes.Pages.CrudSchool
{
    public class CreateModel : PageModel
    {
        private readonly PruebaTecnicaDaCodes.DAL.AppDbContext _context;

        public CreateModel(PruebaTecnicaDaCodes.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public School School { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Schools.Add(School);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
