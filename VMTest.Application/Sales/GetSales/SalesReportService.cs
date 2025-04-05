using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTest.Application.Mappers;
using VMTest.Domain.Sales;

namespace VMTest.Application.Sales.GetSales
{
    internal class SalesReportService(ISaleRepository saleRepository) 
        : ISalesReportService
    {
        public async Task<IEnumerable<SaleRecord>> GetAllSales()
        {
            var sales = await saleRepository.GetAllSales();
            return sales.Select(x => x.ToSaleRecord()).ToList();
        }
    }
}
