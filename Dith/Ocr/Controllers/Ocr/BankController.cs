using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers.Ocr
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View("~/Views/Ocr/Bank/Overview.cshtml");
        }

        public IActionResult CollectedStatements()
        {
            return View("~/Views/Ocr/Bank/CollectedStatements.cshtml");
        }

        public IActionResult ProcessedStatements()
        {
            return View("~/Views/Ocr/Bank/ProcessedStatements.cshtml");
        }

        public IActionResult Transactions()
        {
            return View("~/Views/Ocr/Bank/Transactions.cshtml");
        }
    }
}
