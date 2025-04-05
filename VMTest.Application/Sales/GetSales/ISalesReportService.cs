using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTest.Application.Sales.GetSales
{
    public interface ISalesReportService
    {
        Task<IEnumerable<SaleRecord>> GetAllSales();
    }
}
