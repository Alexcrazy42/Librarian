using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Reports;

[ApiController]
[Route("api/reports")]
public class ReportController : ControllerBase
{
    [HttpGet]
    public ActionResult DownloadReport()
    {
        Console.WriteLine(Directory.GetCurrentDirectory());

        return Ok();       
        //var filePath = Server.MapPath("~/Reports/report.xlsx");

        
        //if (!System.IO.File.Exists(filePath))
        //{
        //    return NotFound();
        //}

        
        //var fileName = Path.GetFileName(filePath);
        //var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // MIME-тип для Excel

        //return File(filePath, contentType, fileName);
    }
}
