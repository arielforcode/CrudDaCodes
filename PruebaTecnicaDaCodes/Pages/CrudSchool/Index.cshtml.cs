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
    public class IndexModel : PageModel
    {
        private readonly PruebaTecnicaDaCodes.DAL.AppDbContext _context;

        public IndexModel(PruebaTecnicaDaCodes.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<School> School { get;set; } = default!;

        public async Task OnGetAsync()
        {
            School = await _context.Schools.ToListAsync();
        }
    }
}
