namespace backend.Service.Interfaces
{
    public interface ICsvExportService
    {
        byte[] ExportToCsv<T>(IEnumerable<T> dados);
    }
}