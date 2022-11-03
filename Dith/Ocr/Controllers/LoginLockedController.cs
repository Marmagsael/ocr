using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OcrLibrary.DataAccess;
using OcrLibrary.Models;
using System.Security.Claims;

namespace Ocr.Controllers
{
    public class LoginLockedController : Controller
    {
        private readonly IUsersData _data;
        private readonly IConfiguration _config;
        public LoginLockedController(IUsersData data, IConfiguration config)
        {
            _data = data;
            _config = config;

        }

        public IActionResult Index()
        {
            return View();
        }
        private string GetCoName()
        {
            var CoName = _config["CompanyInfo:CompanyName"];
            return CoName;
        }
        public async Task<IActionResult> SignInWithGoogle()
        {
            var claims = User.Claims;
            var emailIdentifier = ClaimTypes.Email;
            var nameIdentifier = ClaimTypes.Name;

            var email = claims.FirstOrDefault(c => c.Type == emailIdentifier).Value;
            var name = claims.FirstOrDefault(c => c.Type == nameIdentifier).Value;
            var user = await _data.FetchUserByEmailQS(email);

            if (user is null)
            {
                UsersModel userModel = new UsersModel();
                userModel.Email = email;

                await _data.CreateUserLogin(userModel);
            }
            ViewBag.Title = GetCoName();
            
            //ViewBag.UserName = name;
            return Redirect("/Dashboard");

        }

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            //return Redirect("https://mail.google.com/mail/u/0/?logout&hl=en");
            return Redirect("/");
        }
    }
}
