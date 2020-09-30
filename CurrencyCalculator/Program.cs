using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Controllers;
using CurrencyCalculator.CurrencyCalculator.Fixer;
using CurrencyCalculator.CurrencyCalculator.Models.Response;
using CurrencyCalculator.CurrencyCalculator.Services;
using CurrencyCalculator.CurrencyCalculator.Validators;

namespace CurrencyCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
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

            var conversionController = new CurrencyConversionController(new CurrencyConversionService());

            var result = await conversionController.ConvertCurrencyFromAmountTo(fromCurrency, toCurrency, amount);

            var printAmount = (decimal)System.Math.Round(result.ToConversion.Amount, 2);

            Console.WriteLine(amount + " " + fromCurrency + " equals " + printAmount + " " + toCurrency + " today.");

            Console.ReadLine();

            Console.WriteLine("Add date to get historical conversion. Dateformat YYYY-MM-DD");


            ConversionResultModel historicalResult;
            var historicalPrintAmount = 0m;
            var date = "";
            var historicalSuccess = false;


            do
            {
                date = Console.ReadLine();
                historicalResult = await conversionController.ConvertCurrencyFromHistoricalRates(fromCurrency, toCurrency, amount, date);
                if (historicalResult == null)
                    Console.WriteLine("Date not valid!");
                else
                    historicalSuccess = true;

            } while (!historicalSuccess);


            
            historicalPrintAmount = (decimal) System.Math.Round(historicalResult.ToConversion.Amount, 2);


            Console.WriteLine(historicalPrintAmount + " " + fromCurrency + " equals " + printAmount + " " + toCurrency + " in " + date);

        }
    }
}
