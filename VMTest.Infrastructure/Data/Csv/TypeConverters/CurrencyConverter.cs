using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VMTest.Infrastructure.Data.Csv.TypeConverters
{
    internal class CurrencyConverter : DefaultTypeConverter
    {
        private static readonly Dictionary<string, string> CurrencySymbolPairs = new Dictionary<string, string> {
            { "£", "GBP" },
            { "$", "USD" }
        };

        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            var match = Regex.Match(text, @"[^\d.,]");

            if (match.Success)
            {
                return CurrencySymbolPairs[match.Value];
            }

            throw new FormatException($"Invalid Currency: {text}");
        }
    }
}
