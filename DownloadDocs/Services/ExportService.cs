using DownloadDocs.Helpers;
using DownloadDocs.Interfaces;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace DownloadDocs.Services
{
    public class ExportService : IExportService
    {
        // Tijdelijke placeholder
        #region Helper
        private static string EscapeXml(string? value)
        {
            return System.Security.SecurityElement.Escape(value ?? "") ?? "";
        }
        #endregion

        public async Task<Result<byte[]>> GeneratePdf(string html)
        {
            // Download Chromium de eerste keer
            await new BrowserFetcher().DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            await using var page = await browser.NewPageAsync();

            await page.SetContentAsync(html);



            var pdfBytes = await page.PdfDataAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true
            });

            return Result<byte[]>.Success(pdfBytes, "SUCCESS", "PDF Succesfully generated");
        }

    }
}
