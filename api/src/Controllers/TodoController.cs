using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Todolist.Controllers {
    [Route("api/[controller]")]
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
        public TodoItem Post(TodoItem todoItem) {
           
            
            var a = modelContext.Items.Add(todoItem);
            modelContext.SaveChanges();
     
            return a.Entity;
        }

        [HttpDelete]
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
        [HttpPut]
        public async Task<IActionResult> Update(TodoItem item)
        {
            modelContext.Items.Add(item);
            await modelContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), item);
        }
    }
}
