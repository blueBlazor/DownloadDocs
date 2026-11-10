using DownloadDocs.Helpers;
using DownloadDocs.Models;
using DownloadDocs.Services;

namespace DownloadDocs.Handlers
{
    public class GetPDFHandler : IRequestHandler<GetManualRequest, byte[]>
    {
        private readonly ExportService _exportService;
        public GetPDFHandler(ExportService exportService)
        {
            _exportService = exportService;
        }

        public async Task<Response<byte[]>> HandleAsync(Request<GetManualRequest> request, CancellationToken ct = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            else
            {

                var html = await System.IO.File.ReadAllTextAsync(request.Data.TemplatePath);
                if (!string.IsNullOrWhiteSpace(html))
                {
                    html = html
               .Replace("{{Title}}", request.Data.manual.Title)
               .Replace("{{Version}}", request.Data.manual.Version)
               .Replace("{{RevisionDate}}", request.Data.manual.RevisionDate.ToString("dd-MM-yyyy"))
               .Replace("{{SerialNumber}}", request.Data.manual.SerialNumber)
               .Replace("{{Company}}", request.Data.manual.Company)
               .Replace("{{Year}}", request.Data.manual.Year)

               .Replace("{{Introduction}}", request.Data.manual.Introduction)
               .Replace("{{Operation}}", request.Data.manual.OperationProcedure)
               .Replace("{{Safety}}", request.Data.manual.SafetyInstructions)
               .Replace("{{Maintenance}}", request.Data.manual.MaintenanceInstructions);
                }

                var result = await _exportService.GeneratePdf(html);
                if (result.data != null)
                {
                    return Response<byte[]>.Success(result.data, "Success", "PDF succesfully generated", 200);
                }
                else
                {
                    return Response<byte[]>.Failure("Error", "Something went wrong when generating pdf", 404);
                }
            }

        }

    }
}
