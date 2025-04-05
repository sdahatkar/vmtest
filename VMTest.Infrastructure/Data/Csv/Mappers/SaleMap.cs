using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTest.Domain.Sales;
using VMTest.Infrastructure.Data.Csv.TypeConverters;

namespace VMTest.Infrastructure.Data.Csv.Mappers
{
    internal class SaleMap : ClassMap<Sale>
    {
        public SaleMap()
        {
            Map(x => x.Segment).Name("Segment");
            Map(x => x.Country).Name("Country");
            Map(x => x.Product).Name("Product");
            Map(x => x.DiscountBand).Name("Discount Band");
            Map(x => x.UnitsSold).Name("Units Sold");
            Map(x => x.ManufacturingPrice).Name("Manufacturing Price").TypeConverter<PriceConverter>();
            Map(x => x.ManufacturingPriceCurrency).Name("Manufacturing Price").TypeConverter<CurrencyConverter>();
            Map(x => x.SalePrice).Name("Sale Price").TypeConverter<PriceConverter>();
            Map(x => x.SalePriceCurrency).Name("Sale Price").TypeConverter<CurrencyConverter>();
            Map(x => x.Date).Name("Date").TypeConverter<DateConverter>();
        }
    }
}
