using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers.Ocr
{
    public class CostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inbox()
        {
            return View("~/Views/Ocr/Costs/Inbox.cshtml");
        }

        public IActionResult InProcessing()
        {
            return View("~/Views/Ocr/Costs/InProcessing.cshtml");
        }

        public IActionResult ToReview()
        {
            return View("~/Views/Ocr/Costs/ToReview.cshtml");

        }

        public IActionResult Ready()
        {
            return View("~/Views/Ocr/Costs/Ready.cshtml");

        }

        public IActionResult Archive()
        {
            return View("~/Views/Ocr/Costs/Archive.cshtml");

        }
    }
}
