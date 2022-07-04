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

        [HttpGet("simple")]
        public async Task<IActionResult> GetSimple()
        {
            var data = await modelContext.Items.ToListAsync();

            var result = new List<TodoItemDTO>();

            foreach(var item in data)
            {
                result.Add( new TodoItemDTO
                {
                    IsDone = item.IsDone,
                    Name = item.Name
                });
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get() {
            return await modelContext.Items.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TodoItem todoItem) {
           
            if(todoItem.Name == "")
            {
                return BadRequest(); 
            }
            modelContext.Items.Add(todoItem);
            await modelContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]int id) 
        {
            var item = await modelContext.Items.FindAsync(id);
            if(item == null)
            {
                return BadRequest();
            }
            modelContext.Items.Remove(item);
            await modelContext.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]TodoItem name)
        {
            if(id != name.Id)
            {
                return BadRequest();
            }

            var item = await modelContext.Items.FindAsync(id);
            if (name.Name == "")
            {
                return BadRequest();
            }
            item.Name = name.Name;
            item.IsDone = name.IsDone;
            await modelContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), item);
        }
    }
}
