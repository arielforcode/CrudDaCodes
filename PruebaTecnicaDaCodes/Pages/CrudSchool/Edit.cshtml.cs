﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDaCodes.DAL;
using PruebaTecnicaDaCodes.Models;

namespace PruebaTecnicaDaCodes.Pages.CrudSchool
{
    public class EditModel : PageModel
    {
        private readonly PruebaTecnicaDaCodes.DAL.AppDbContext _context;

        public EditModel(PruebaTecnicaDaCodes.DAL.AppDbContext context)
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

            var school =  await _context.Schools.FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }
            School = school;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(School).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(School.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SchoolExists(int id)
        {
            return _context.Schools.Any(e => e.Id == id);
        }
    }
}
