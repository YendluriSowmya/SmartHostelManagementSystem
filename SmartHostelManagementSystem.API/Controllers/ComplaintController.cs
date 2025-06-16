using Microsoft.AspNetCore.Mvc;

namespace SmartHostelManagementSystem.API.Controllers
{
    public class ComplaintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
