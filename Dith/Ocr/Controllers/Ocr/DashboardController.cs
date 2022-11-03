using Microsoft.AspNetCore.Mvc;
namespace Ocr.Controllers.Ocr
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Ocr/Dashboard/Index.cshtml");
        }
    }
}
