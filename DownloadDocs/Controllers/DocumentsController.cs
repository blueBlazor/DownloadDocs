using DownloadDocs.Helpers;
using DownloadDocs.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly IHandlerDispatch _handlerDispatch;

    public DocumentsController(IWebHostEnvironment environment, IHandlerDispatch handlerDispatch)
    {
        _environment = environment;
        _handlerDispatch = handlerDispatch;
    }

    [HttpPost("manual")]
    public async Task<IActionResult> DownloadManual([FromBody] Manual manual, string culture = "en-GB", CancellationToken ct = default)
    {
        var templatePath = Path.Combine(
            _environment.ContentRootPath, "Documents", "Manuals", $"Manual_[{culture}].html");

        if (!System.IO.File.Exists(templatePath))
            return NotFound("Manual template not found.");


        var request = new Request<GetManualRequest>(new GetManualRequest(templatePath, manual));
        //HTML converting to PDF
        var response = _handlerDispatch.DispatchAsync<GetManualRequest, byte[]>(request, ct).Result;

        if (response.isSuccess == false)
            return BadRequest(response);
        var pdf = response.value;
        return File(pdf!, "application/pdf", $"Manual[{culture}].pdf");

    }






}