using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers.Ocr
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Suppliers()
        {
            return View("~/Views/Ocr/Main/Suppliers.cshtml");
        }

        public IActionResult Customers()
        {
            return View("~/Views/Ocr/Main/Customers.cshtml");
        }

        public IActionResult Categories()
        {
            return View("~/Views/Ocr/Main/Categories.cshtml");

        }

        public IActionResult Projects()
        {
            return View("~/Views/Ocr/Main/Projects.cshtml");
        }

        public IActionResult BankAccounts()
        {
            return View("~/Views/Ocr/Main/BankAccounts.cshtml");
        }

        public IActionResult PaymentMethods()
        {
            return View("~/Views/Ocr/Main/PaymentMethods.cshtml");
        }
    }
}
