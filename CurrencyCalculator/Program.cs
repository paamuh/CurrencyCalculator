using System;
using System.Threading.Tasks;
using CurrencyCalculator.Fixer;

namespace CurrencyCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("This is an currency calculator, who takes currencyCodes and Amount as input.");

            //Console.WriteLine("Currency code to convert from?");
            //var fromCurrency = Console.ReadLine();

            //Console.WriteLine("Currency code to convert to?");
            //var toCurrency = Console.ReadLine();

            Console.WriteLine("Amount to convert?");
            bool amountValidation;
            decimal amount;
            do
            {
                var consoleAmount = Console.ReadLine();
                amountValidation = decimal.TryParse(consoleAmount, out decimal dec);
                amount = dec;
                if(!amountValidation)
                    Console.WriteLine("Amount not valid! Amount can only be numeric values");

            } while (!amountValidation);



            var fixerController = new FixerController();
            var fromCurrency = "EUR";
            var toCurrency = "NOK";
            //var amount = 100m;

            //var returnAmount = await fixerController.ConvertCurrencyFromAmountTo(fromCurrency, toCurrency, amount);

            //var printAmount = (decimal) System.Math.Round(returnAmount, 2);

            //Console.WriteLine(amount + " " + fromCurrency + " equals " + printAmount + " " + toCurrency);

            var date = "2015-04-25";

            var returnAmount = await fixerController.ConvertCurrencyFromHistoricalRates(fromCurrency, toCurrency, amount, date);

            var printAmount = (decimal) System.Math.Round(returnAmount, 2);

            Console.WriteLine(amount + " " + fromCurrency + " equals " + printAmount + " " + toCurrency + " in " + date);

        }
    }
}
