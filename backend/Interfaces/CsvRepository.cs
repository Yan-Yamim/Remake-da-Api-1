namespace backend.Interfaces
{
    public interface ICsvExportService
    {
        byte[] ExportToCsv<T>(IEnumerable<T> dados);
    }
}