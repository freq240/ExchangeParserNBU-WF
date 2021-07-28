using System;
using System.Collections.Generic;

namespace ExchangeParserNBU
{
    class Exchange
    {
        // For 1 UAH to 1 SomeCurrency
        public static double ParsedExchangeCourse(List<object> list)
        {
            int units = Convert.ToInt32(list[0]);
            var amount = Convert.ToDouble(list[1].ToString().Replace(".", ","));
            var exchangeCourse = units == 1 ? amount : amount / units;

            return exchangeCourse;
        }
    }
}
