using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ToDoController : Controller
    {
        private readonly List<ToDoItem> Tasks = new List<ToDoItem>
        {
            new ToDoItem(1, "Buy milk", "Buy eggs", "Buy bread"),
            new ToDoItem(2, "Pick up kids", "Take kids to school"),
            new ToDoItem(3),
            new ToDoItem(4, "Get fuel", "Check oil", "Check Tyre pressure"),
        };

        public IActionResult Index()
        {
            return View(Tasks);
        }

        public IActionResult View(int id)
        {
            var item = Tasks.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return RedirectToAction("List");
            }
            if (item.IsComplete)
            {
                return View("Complete", item);
            }
            return View(item);
        }

        public IActionResult SimpleView(int id)
        {
            var item = Tasks.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return RedirectToAction("List");
            }
            return View(item);
        }
    }
}
