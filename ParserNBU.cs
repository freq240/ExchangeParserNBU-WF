using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace ExchangeParserNBU
{
    class ParserNBU
    {

        // Parsing API and getting list of [units, amount] for some currency and date
        public static List<object> Parse(string ID, string date)
        {
            // date format [day.month.year]
            string data = "";

            using (WebClient wc = new WebClient())
                data = wc.DownloadString(@"https://bank.gov.ua/NBU_Exchange/exchange?date=" + date);

            Match match = Regex.Match(data, $"<CurrencyCodeL>{ID}</CurrencyCodeL>.*?<Units>(.*?)</Units>.*?<Amount>(.*?)</Amount>", RegexOptions.Singleline);
            List<object> templist = new List<object>() {match.Groups[1].Value, match.Groups[2].Value };

            return templist;
        }
 

        // Write all names of currency into file currency.txt
        public static void WriteInFileAllCurrency()
        {
            string data = "";
            using (WebClient wc = new WebClient())
                data = wc.DownloadString(@"https://bank.gov.ua/NBU_Exchange/exchange?date=05.07.2021");

            var arr = Regex.Matches(data, "<CurrencyCodeL>(.*?)</CurrencyCodeL>")
            .Cast<Match>()
            .Select(m => m.Groups[1].Value)
            .ToArray();

            string allCurrency = "";
            for (int i = 0; i < arr.Length; i++)
            {
                allCurrency += arr[i] + "\n";
            }

            string writePath = @"C:\Users\user\source\repos\ExchangeParserNBU\ExchangeParserNBU\currency.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(allCurrency);
            }
        }

        // parsing from api USD course only 
        public static double GetUSDcourse(string date)
        {
            string data = "";

            using (WebClient wc = new WebClient())
                data = wc.DownloadString(@"https://bank.gov.ua/NBU_Exchange/exchange?date=" + date);

            Match match = Regex.Match(data, $"<CurrencyCodeL>USD</CurrencyCodeL>.*?<Amount>(.*?)</Amount>", RegexOptions.Singleline);

            var amount = Convert.ToDouble(match.Groups[1].Value.ToString().Replace(".", ","));

            return amount;
        }

    }
}
