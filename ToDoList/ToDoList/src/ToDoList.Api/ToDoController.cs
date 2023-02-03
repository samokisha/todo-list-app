using Microsoft.AspNetCore.Mvc;

namespace ToDoList.src.ToDoList.Api
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
