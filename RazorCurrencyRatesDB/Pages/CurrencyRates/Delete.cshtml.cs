using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCurrencyRatesDB.Data;
using RazorCurrencyRatesDB.Models;

namespace RazorCurrencyRatesDB.Pages.CurrencyRates
{
    public class DeleteModel : PageModel
    {
        private readonly RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext _context;

        public DeleteModel(RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.CurrencyRatesDbModel CurrencyRates { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrencyRates = await _context.CurrencyRates.FirstOrDefaultAsync(m => m.ID == id);

            if (CurrencyRates == null)
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

            CurrencyRates = await _context.CurrencyRates.FindAsync(id);

            if (CurrencyRates != null)
            {
                _context.CurrencyRates.Remove(CurrencyRates);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
