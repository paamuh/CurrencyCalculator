using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCurrencyRatesDB.Data;
using RazorCurrencyRatesDB.Models;

namespace RazorCurrencyRatesDB.Pages.CurrencyRates
{
    public class CreateModel : PageModel
    {
        private readonly RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext _context;

        public CreateModel(RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.CurrencyRatesDbModel CurrencyRates { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CurrencyRates.Add(CurrencyRates);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
