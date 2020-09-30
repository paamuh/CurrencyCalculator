using CurrencyCalculator.CurrencyCalculator.Models.Response;
using RazorCurrencyRatesDB.Models;

namespace RazorCurrencyRatesDB.Mappers
{
    public static class FixerResponseToDbCurrencyRatesMapper
    {
        public static CurrencyRatesDbModel MapFixerResponseModelToDbCurrencyModel(RatesResponseModel fixerRatesModel)
        {
            var currencyRatesDb = new CurrencyRatesDbModel();
            if (fixerRatesModel == null)
                return currencyRatesDb;

            currencyRatesDb.Date = fixerRatesModel.Date;
            currencyRatesDb.Base = fixerRatesModel.Base;
            currencyRatesDb.AED = fixerRatesModel.Rates.AED;
            currencyRatesDb.AFN = fixerRatesModel.Rates.AFN;
            currencyRatesDb.ALL = fixerRatesModel.Rates.ALL;
            currencyRatesDb.AMD = fixerRatesModel.Rates.AMD;
            currencyRatesDb.ANG = fixerRatesModel.Rates.ANG;
            currencyRatesDb.AOA = fixerRatesModel.Rates.AOA;
            currencyRatesDb.ARS = fixerRatesModel.Rates.ARS;
            currencyRatesDb.AUD = fixerRatesModel.Rates.AUD;
            currencyRatesDb.AWG = fixerRatesModel.Rates.AWG;
            currencyRatesDb.AZN = fixerRatesModel.Rates.AZN;
            currencyRatesDb.BAM = fixerRatesModel.Rates.BAM;
            currencyRatesDb.BBD = fixerRatesModel.Rates.BBD;
            currencyRatesDb.BDT = fixerRatesModel.Rates.BDT;
            currencyRatesDb.BGN = fixerRatesModel.Rates.BGN;
            currencyRatesDb.BDT = fixerRatesModel.Rates.BDT;
            currencyRatesDb.BHD = fixerRatesModel.Rates.BHD;
            currencyRatesDb.BIF = fixerRatesModel.Rates.BIF;
            currencyRatesDb.BMD = fixerRatesModel.Rates.BMD;

            currencyRatesDb.BND = fixerRatesModel.Rates.BND;
            currencyRatesDb.BOB = fixerRatesModel.Rates.BOB;
            currencyRatesDb.BRL = fixerRatesModel.Rates.BRL;
            currencyRatesDb.BSD = fixerRatesModel.Rates.BSD;
            currencyRatesDb.BTC = fixerRatesModel.Rates.BTC;
            currencyRatesDb.BTN = fixerRatesModel.Rates.BTN;

            currencyRatesDb.BWP = fixerRatesModel.Rates.BWP;
            currencyRatesDb.BYN = fixerRatesModel.Rates.BYN;
            currencyRatesDb.BYR = fixerRatesModel.Rates.BYR;
            currencyRatesDb.BZD = fixerRatesModel.Rates.BZD;
            currencyRatesDb.CAD = fixerRatesModel.Rates.CAD;
            currencyRatesDb.CDF = fixerRatesModel.Rates.CDF;

            currencyRatesDb.CHF = fixerRatesModel.Rates.CHF;
            currencyRatesDb.CLF = fixerRatesModel.Rates.CLF;
            currencyRatesDb.CLP = fixerRatesModel.Rates.CLP;
            currencyRatesDb.CNY = fixerRatesModel.Rates.CNY;
            currencyRatesDb.COP = fixerRatesModel.Rates.COP;

            currencyRatesDb.CRC = fixerRatesModel.Rates.CRC;
            currencyRatesDb.CUC = fixerRatesModel.Rates.CUC;
            currencyRatesDb.CUP = fixerRatesModel.Rates.CUP;
            currencyRatesDb.CVE = fixerRatesModel.Rates.CVE;
            currencyRatesDb.CZK = fixerRatesModel.Rates.CZK;

            currencyRatesDb.DJF = fixerRatesModel.Rates.DJF;
            currencyRatesDb.DKK = fixerRatesModel.Rates.DKK;
            currencyRatesDb.DOP = fixerRatesModel.Rates.DOP;
            currencyRatesDb.DZD = fixerRatesModel.Rates.DZD;
            currencyRatesDb.EGP = fixerRatesModel.Rates.EGP;

            currencyRatesDb.ERN = fixerRatesModel.Rates.ERN;
            currencyRatesDb.ETB = fixerRatesModel.Rates.ETB;
            currencyRatesDb.EUR = fixerRatesModel.Rates.EUR;
            currencyRatesDb.FKP = fixerRatesModel.Rates.FKP;
            currencyRatesDb.GBP = fixerRatesModel.Rates.GBP;

            currencyRatesDb.ERN = fixerRatesModel.Rates.ERN;
            currencyRatesDb.ETB = fixerRatesModel.Rates.ETB;
            currencyRatesDb.EUR = fixerRatesModel.Rates.EUR;
            currencyRatesDb.FKP = fixerRatesModel.Rates.FKP;
            currencyRatesDb.GBP = fixerRatesModel.Rates.GBP;

            currencyRatesDb.GEL = fixerRatesModel.Rates.GEL;
            currencyRatesDb.GGP = fixerRatesModel.Rates.GGP;
            currencyRatesDb.GHS = fixerRatesModel.Rates.GHS;
            currencyRatesDb.GIP = fixerRatesModel.Rates.GIP;
            currencyRatesDb.GMD = fixerRatesModel.Rates.GMD;

            currencyRatesDb.GNF = fixerRatesModel.Rates.GNF;
            currencyRatesDb.GTQ = fixerRatesModel.Rates.GTQ;
            currencyRatesDb.GYD = fixerRatesModel.Rates.GYD;
            currencyRatesDb.HKD = fixerRatesModel.Rates.HKD;
            currencyRatesDb.HNL = fixerRatesModel.Rates.HNL;

            return currencyRatesDb;
        }
        
    }
}