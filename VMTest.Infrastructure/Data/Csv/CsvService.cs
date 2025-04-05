using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTest.Infrastructure.Data.Csv
{

    internal class CsvService<TRecord>(ClassMap<TRecord> classMap, ILogger<CsvService<TRecord>> logger) : ICsvService<TRecord>
        where TRecord : class
    {
        private static readonly CultureInfo Culture = new CultureInfo("en-GB");
        private static readonly Encoding encoding = Encoding.GetEncoding(1252);// Need to use this encoding because the file uses this encoding which does not read the £ symbol correctly

        public Task<IEnumerable<TRecord>> GetRecords(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            var config = GetCsvReaderConfig();
            List<TRecord> records = new List<TRecord>();

            using var reader = new StreamReader(filePath, encoding);
            using (var csvReader = new CsvReader(reader, config))
            {
                csvReader.Context.RegisterClassMap(classMap);

                csvReader.Read();
                csvReader.ReadHeader();

                while (csvReader.Read())
                {
                    try
                    {
                        var record = csvReader.GetRecord<TRecord>();
                        if (record != null)
                        {
                            records.Add(record);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log errors for invalid data
                        logger.LogError(ex.Message);
                    }
                }
                //records = csvReader.GetRecords<TRecord>().ToList();
            }

            return Task.FromResult(records.AsEnumerable());
        }

        private IReaderConfiguration GetCsvReaderConfig()
        {
            var csvConfig = new CsvConfiguration(Culture)
            {
                TrimOptions = TrimOptions.Trim,
                HasHeaderRecord = true,
                Encoding = encoding
            };

            return csvConfig;
        }
    }

    
}
