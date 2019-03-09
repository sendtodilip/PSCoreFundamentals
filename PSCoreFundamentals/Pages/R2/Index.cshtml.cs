using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PSCoreFundamentals.Core;
using PSCoreFundamentals.Data;

namespace PSCoreFundamentals.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly PSCoreFundamentals.Data.CoreFundaDbContext _context;

        public IndexModel(PSCoreFundamentals.Data.CoreFundaDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
