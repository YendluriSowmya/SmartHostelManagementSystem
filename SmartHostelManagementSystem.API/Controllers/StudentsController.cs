using Microsoft.AspNetCore.Mvc;

namespace SmartHostelManagementSystem.API.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
