using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly ServiceTodo _context;
    public TodoController(ServiceTodo context)
    {
        _context = context;
    }


    // GET: api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        // Get items
        var todos = _context.Todos;
        return await todos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetItem(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    // POST: api/item
    [HttpPost]
    public async Task<ActionResult<Todo>> PostItem(Todo item)
    {
        _context.Todos.Add(item);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    // PUT: api/item/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutItem(int id, Todo item)
    {
        if (id != item.Id)
            return BadRequest();


        _context.Entry(item).State = EntityState.Modified;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Todos.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // DELETE: api/item/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await _context.Todos.FindAsync(id);

        if (item == null)
            return NotFound();

        _context.Todos.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
