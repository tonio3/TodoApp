using Microsoft.AspNetCore.Mvc;

namespace Todolist.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase {

        ModelDbContext modelContext { get; set; }

        public TodoController(ModelDbContext db)
        { 
            modelContext = db;
        }


        [HttpGet]
        public IEnumerable<TodoItem> Get() {
            return modelContext.Items;
        }

        [HttpPost]
        public TodoItem Post(TodoItem todoItem) {
           
            
            var a = modelContext.Items.Add(todoItem);
            modelContext.SaveChanges();
     
            return a.Entity;
        }

        [HttpDelete]
        public IEnumerable<TodoItem> Delete() {
            return null;
        }
    }
}
