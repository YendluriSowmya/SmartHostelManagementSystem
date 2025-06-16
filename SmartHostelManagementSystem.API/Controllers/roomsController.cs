using Microsoft.AspNetCore.Mvc;

namespace SmartHostelManagementSystem.API.Controllers
{
    public class roomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
