using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers.Ocr
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inbox()
        {
            return View("~/Views/Ocr/Sales/Inbox.cshtml");
        }

        public IActionResult InProcessing()
        {
            return View("~/Views/Ocr/Sales/InProcessing.cshtml");

        }

        public IActionResult ToReview()
        {
            return View("~/Views/Ocr/Sales/ToReview.cshtml");

        }

        public IActionResult Ready()
        {
            return View("~/Views/Ocr/Sales/Ready.cshtml");
        }

        public IActionResult Archive()
        {
            return View("~/Views/Ocr/Sales/Archive.cshtml");
        }


    }
}
