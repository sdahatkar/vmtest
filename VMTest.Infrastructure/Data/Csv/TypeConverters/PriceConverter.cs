using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTest.Infrastructure.Data.Csv.TypeConverters
{
    internal class PriceConverter : DefaultTypeConverter
    {
        private static readonly CultureInfo Culture = new CultureInfo("en-GB");
        private static readonly NumberStyles NumberStyle = NumberStyles.Currency;

        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (decimal.TryParse(text, NumberStyle, Culture, out var price))
            {
                return price;
            }

            throw new FormatException($"Invalid Price: {text}");
        }
    }
}
