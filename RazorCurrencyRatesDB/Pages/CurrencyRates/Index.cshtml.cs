using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorCurrencyRatesDB.Pages.CurrencyRates
{
    public class IndexModel : PageModel
    {
        private readonly RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext _context;

        public IndexModel(RazorCurrencyRatesDB.Data.RazorCurrencyRatesDBContext context)
        {
            _context = context;
        }

        public IList<Models.CurrencyRatesDbModel> CurrencyRates { get;set; }

        public async Task OnGetAsync()
        {
            CurrencyRates = await _context.CurrencyRates.ToListAsync();
        }
    }
}
