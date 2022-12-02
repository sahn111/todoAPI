using ToDoApi.Models;
using ToDoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly TodoService _todosService;

    public ToDoController(TodoService todosService) =>
        _todosService = todosService;

    [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<List<Todo>> Get() =>
        await _todosService.GetAsync();

    [HttpGet("{id:length(24)}"), Authorize]
    public async Task<ActionResult<Todo>> Get(string id)
    {
        var book = await _todosService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost, Authorize, Authorize]
    public async Task<IActionResult> Post(Todo newBook)
    {
        await _todosService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:length(24)}"), Authorize]
    public async Task<IActionResult> Update(string id, Todo updatedBook)
    {
        var book = await _todosService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _todosService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}"), Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _todosService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _todosService.RemoveAsync(id);

        return NoContent();
    }

}