using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using System.Xml.Linq;

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


        private string GetUserName()
        {
            var claims = User.Claims;
            var nameIdentifier  = ClaimTypes.Name;
            var name = claims.FirstOrDefault(c => c.Type == nameIdentifier).Value;

            return name;
        }


        public IActionResult _8Suppliers()
        {
            return View();
        }

        public IActionResult _9Customers()
        {
            return View();
        }

        public IActionResult _10Categories()
        {
            return View();
        }

        public IActionResult _11Projects()
        {
            return View();
        }

        public IActionResult _12BankAccounts()
        {
            return View();
        }

        public IActionResult _13PaymentMethods()
        {
            return View();
        }

        // ------- Cost --------------
        public IActionResult _14Inbox()
        {
            return View("~/Views/MenuOcr/Costs/_14Inbox.cshtml");
        }

        public IActionResult _15InProcessing()
        {
            return View("~/Views/MenuOcr/Costs/_15InProcessing.cshtml");
        }

        public IActionResult _16ToReview()
        {
            return View("~/Views/MenuOcr/Costs/_16ToReview.cshtml");
        }

        public IActionResult _17Ready()
        {
            return View("~/Views/MenuOcr/Costs/_17Ready.cshtml");

        }

        public IActionResult _18Archive()
        {
            return View("~/Views/MenuOcr/Costs/_18Archive.cshtml");

        }

        // ------- Sales --------------
        public IActionResult _19Inbox()
        {
            return View("~/Views/MenuOcr/Sales/_19Inbox.cshtml");
        }

        public IActionResult _20InProcessing()
        {
            return View("~/Views/MenuOcr/Sales/_20InProcessing.cshtml");

        }

        public IActionResult _21ToReview()
        {
            return View("~/Views/MenuOcr/Sales/_21ToReview.cshtml");
        }

        public IActionResult _22Ready()
        {
            return View("~/Views/MenuOcr/Sales/_22Ready.cshtml");
        }

        public IActionResult _23Archive()
        {
            return View("~/Views/MenuOcr/Sales/_23Archive.cshtml");
        }

        // ------- Expense Reports --------------
        public IActionResult _24Inbox()
        {
            return View("~/Views/MenuOcr/ExpenseReports/_24Inbox.cshtml");

        }

        public IActionResult _25Archive()
        {
            return View("~/Views/MenuOcr/ExpenseReports/_25Archive.cshtml");


        }
        // ------- Bank --------------
        public IActionResult _26Overview()
        {
            return View("~/Views/MenuOcr/Bank/_26Overview.cshtml");

        }
        public IActionResult _27CollectedStatements()
        {
            return View("~/Views/MenuOcr/Bank/_27CollectedStatements.cshtml");

        }

        public IActionResult _28ProcessedStatements()
        {
            return View("~/Views/MenuOcr/Bank/_28ProcessedStatements.cshtml");

        }

        public IActionResult _29Transactions()
        {
            return View("~/Views/MenuOcr/Bank/_29Transactions.cshtml");

        }


    }
}
