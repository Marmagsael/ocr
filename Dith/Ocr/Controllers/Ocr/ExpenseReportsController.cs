using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers.Ocr
{
    public class ExpenseReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inbox()
        {
            return View("~/Views/Ocr/ExpenseReports/Inbox.cshtml");

        }
        public IActionResult Archive()
        {
            return View("~/Views/Ocr/ExpenseReports/Archive.cshtml");

        }
    }
}
