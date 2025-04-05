using VMTest.Application.Sales.GetSales;

namespace VMTest.Api
{
    public static class EndpointExtensions
    {
        public static IApplicationBuilder MapEndpoints(this WebApplication app)
        {
            app.MapGet("sales", async (ISalesReportService salesReportService) =>
            {
                var sales = await salesReportService.GetAllSales();

                return Results.Ok(sales);
            })
            .WithTags(Tags.Sales);

            return app;
        }
    }
}
