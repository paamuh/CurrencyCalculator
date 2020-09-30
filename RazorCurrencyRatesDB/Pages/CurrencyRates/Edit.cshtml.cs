using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorCurrencyRatesDB.Data;
using RazorCurrencyRatesDB.Models;

namespace RazorCurrencyRatesDB.Pages.CurrencyRates
{
    public class EditModel : PageModel
    {
        private readonly RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext _context;

        public EditModel(RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CurrencyRates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyRatesExists(CurrencyRates.ID))
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

        private bool CurrencyRatesExists(int id)
        {
            return _context.CurrencyRates.Any(e => e.ID == id);
        }
    }
}
