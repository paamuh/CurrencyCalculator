using System;
using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Controllers;
using CurrencyCalculator.CurrencyCalculator.Fixer;
using CurrencyCalculator.CurrencyCalculator.Services;
using CurrencyCalculator.CurrencyCalculator.Validators;

namespace CurrencyCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var conversionController = new CurrencyConversionController(new CurrencyConversionService());

            await conversionController.GetAllCurrentRates();
            
            Console.WriteLine("This is an currency calculator, who takes currencyCodes and Amount as input.");

            Console.WriteLine("Currency code to convert from?");

            bool fromCurrencyValidation;
            string fromCurrency;

            do
            {
                fromCurrency = Console.ReadLine()?.ToUpper();
                fromCurrencyValidation = CurrencyCodeValidator.ValidateCurrencyCode(fromCurrency);
                if (!fromCurrencyValidation)
                    Console.WriteLine("Currency code invalid!");

            } while (!fromCurrencyValidation);

            Console.WriteLine("Currency code to convert to?");

            bool toCurrencyValidation;
            string toCurrency;

            do
            {
                toCurrency = Console.ReadLine()?.ToUpper();
                toCurrencyValidation = CurrencyCodeValidator.ValidateCurrencyCode(toCurrency);
                if(!toCurrencyValidation)
                    Console.WriteLine("Currency code invalid!");

            } while (!toCurrencyValidation);

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


            
            

            //var returnAmount = await fixerController.ConvertCurrencyFromAmountTo(fromCurrency, toCurrency, amount);

            //var printAmount = (decimal) System.Math.Round(returnAmount, 2);

            //Console.WriteLine(amount + " " + fromCurrency + " equals " + printAmount + " " + toCurrency);

            var date = "2019-04-04";

            var result = await conversionController.ConvertCurrencyFromHistoricalRates(fromCurrency, toCurrency, amount, date);

            var printAmount = (decimal) System.Math.Round(result.ToConversion.Amount, 2);

            Console.WriteLine(amount + " " + fromCurrency + " equals " + printAmount + " " + toCurrency + " in " + date);

        }
    }
}
