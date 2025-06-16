using Microsoft.AspNetCore.Mvc;

namespace SmartHostelManagementSystem.API.Controllers
{
    public class FesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
