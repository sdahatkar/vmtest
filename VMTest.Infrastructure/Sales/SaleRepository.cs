using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTest.Domain.Sales;
using VMTest.Infrastructure.Data;
using VMTest.Infrastructure.Data.Csv;

namespace VMTest.Infrastructure.Sales
{
    internal class SaleRepository(ICsvService<Sale> csvService, IOptions<DataFiles> options) : ISaleRepository
    {
        private readonly DataFiles _dataFiles = options.Value;
        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            var sales = await csvService.GetRecords(_dataFiles.Sales);

            return sales.ToList();
        }
    }
}
