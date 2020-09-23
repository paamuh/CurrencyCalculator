using System.Text;
using System.Threading.Tasks;

namespace CurrencyCalculator.Fixer
{
    public interface IFixerController
    {
        Task<decimal> GetCurrentCurrencyFromTo(string fromCurrencyCode, string toCurrencyCode);

    }
}