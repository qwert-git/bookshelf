using Bookshelf.Application.BookAdvertFeature;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookAdvertController : ControllerBase
{
    private readonly IBookAdvertReader _bookAdvertReader;

    public BookAdvertController(IBookAdvertReader bookAdvertReader)
    {
        _bookAdvertReader = bookAdvertReader;
    }

    [HttpGet("/bookAdvert")]
    public async Task<IActionResult> GetAllBookAdvertsAsync()
    {
        var bookAdvert = await _bookAdvertReader.GetAllAsync();
        return Ok(bookAdvert);
    }

    [HttpGet("/bookAdvert/{id:int}")]
    public async Task<IActionResult> GetBookAdvertAsync(int id)
    {
        var bookAdvert = await _bookAdvertReader.GetAsync(id);

        // TODO: Research what is the best approach to desing API and handle not found entity?
        if(bookAdvert is null) 
            return BadRequest("The enity has not been found");
        return Ok(bookAdvert);
    }
}