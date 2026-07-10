using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Text;
using backend.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;

namespace backend.Service
{
    public class CsvExportService : ICsvExportService
    {
        public byte[] ExportToCsv<T>(IEnumerable<T> dados)
        {
            using (var memoryStream = new MemoryStream())
            {
                var config = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR"))
                {
                    Delimiter = ";" 
                };

                using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
                using (var csvWriter = new CsvWriter(streamWriter, config))
                {
                    csvWriter.WriteRecords(dados);
                    streamWriter.Flush();
                    
                    return memoryStream.ToArray();
                }
            }
        }
    }
}