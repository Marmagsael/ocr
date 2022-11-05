using LibraryMySql;
using LibraryMySql.DataAccess.Login;
using LibraryMySql.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers.Pis
{
    public class LoginpisController : Controller
    {
        public readonly ILoginAccess _login;

        public LoginpisController(ILoginAccess login)
        {
            _login = login;
        }

        public async Task<IActionResult> Index()
        {

            LoginOutputModel? o  = await _login.LoginEmployee("secpis", "06857", "");
            ViewBag.o = o ; 

            return View();
        }
    }
}
