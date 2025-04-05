namespace VMTest.Infrastructure.Data.Csv
{
    public interface ICsvService<TRecord> where TRecord : class
    {
        Task<IEnumerable<TRecord>> GetRecords(string filePath);
    }
}
