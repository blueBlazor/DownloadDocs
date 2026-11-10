namespace DownloadDocs.Models
{
    public class ExcelExportRequest
    {
        public List<ExportColumn> Columns { get; set; } = [];
        public List<Dictionary<string, object?>> Data { get; set; } = [];
    }

    public class ExportColumn
    {
        public string Header { get; set; } = "";
        public string Field { get; set; } = "";
    }
}
