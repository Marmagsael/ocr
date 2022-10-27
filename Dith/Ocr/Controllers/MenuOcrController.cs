using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers
{
    public class MenuOcrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MenusOcr()
        {
            return View();
        }


    }
}
