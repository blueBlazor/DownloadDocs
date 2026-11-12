using DownloadDocs.Helpers;

namespace DownloadDocs.Interfaces
{
    public interface IExportService
    {
        Task<Result<byte[]>> GeneratePdf(string html);
    }
}
