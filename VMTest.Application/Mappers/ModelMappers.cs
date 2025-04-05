using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VMTest.Application.Sales.GetSales;
using VMTest.Domain.Sales;

namespace VMTest.Application.Mappers
{
    internal static class ModelMappers
    {
        internal static SaleRecord ToSaleRecord(this Sale sale)
        {
            return new SaleRecord
            {
                Segment = sale.Segment,
                Country = sale.Country,
                Product = sale.Product,
                DiscountBand = sale.DiscountBand,
                UnitsSold = sale.UnitsSold,
                ManufacturingPrice = sale.ManufacturingPrice,
                SalePrice = sale.SalePrice,
                Date = sale.Date
            };
        }
    }
}
