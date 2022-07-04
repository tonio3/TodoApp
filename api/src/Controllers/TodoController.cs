using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Todolist.Controllers {
    [Route("api/todoItems")]
    [ApiController]
    public class TodoController : ControllerBase {

        ModelDbContext modelContext { get; set; }

        public TodoController(ModelDbContext db)
        { 
            modelContext = db;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get() {
            return await modelContext.Items.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoItem todoItem) {
           
            if(todoItem.Name == "")
            {
                return NotFound();
            }
            modelContext.Items.Add(todoItem);
            await modelContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var item = await modelContext.Items.FindAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            modelContext.Items.Remove(item);
            await modelContext.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TodoItem name)
        {
            var id = name.Id;

            var item = await modelContext.Items.FindAsync(id);
            if (name.Name == "")
            {
                return NotFound();
            }
            item.Name = name.Name;
            await modelContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), item);
        }
    }
}
