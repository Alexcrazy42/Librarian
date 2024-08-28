using Microsoft.AspNetCore.Mvc;
using Store.Db;

namespace Web.Controllers;

[ApiController]
[Route("api")]
public class Controller : ControllerBase
{
    private readonly LibraryDbContext libraryDbContext;

    public Controller(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok();
    }
}
