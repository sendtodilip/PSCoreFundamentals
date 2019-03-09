using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PSCoreFundamentals.Core;
using PSCoreFundamentals.Data;

namespace PSCoreFundamentals.Pages.R2
{
    public class CreateModel : PageModel
    {
        private readonly PSCoreFundamentals.Data.CoreFundaDbContext _context;

        public CreateModel(PSCoreFundamentals.Data.CoreFundaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}