namespace DownloadDocs.Models
{
    public record GetManualRequest(string TemplatePath, Manual manual);
    public record HtmlPageRequest(string html);
    public record ExcelExportRequest(List<ExportColumn> Columns, List<Dictionary<string, object?>> Data);
    public record ExportColumn(string Header, string Field);
}
