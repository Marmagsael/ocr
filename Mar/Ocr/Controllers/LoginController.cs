using OcrLibrary.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using OcrLibrary.Models;

namespace Ocr.Controllers
{
    public class LoginController : Controller
    {

        private readonly IConfiguration _config;
        private readonly IUsersData _data;


        public LoginController(IConfiguration config, IUsersData data)
        {
            _config = config;
            _data = data;

        }
        public IActionResult RegistrationTest()
        {

            return View();
        }


        public IActionResult LoginTest()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Index(string returnUrl)
        {
            //ViewData["returnUrl"] = returnUrl;
            ViewBag.Title = GetCoName();
            return View();
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> ValidateUser(string Email, string Password)
        {
            var output = await _data.GetUserByEmailQS(Email, Password);
            if (output is not null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Email));
                claims.Add(new Claim(ClaimTypes.Email, Email));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimPrincipal);

                //if (returnUrl is null)  return Redirect("/");
                return Redirect("/LoginLocked/SignInWithGoogle");
            }
            ViewData["errormsg"] = "Invalid Username or Password";
            return View("login");
        }

        private string GetCoName()
        {
            var CoName = _config["CompanyInfo:CompanyName"];
            return CoName;
        }

        [AllowAnonymous]
        [HttpGet("login/Register")]
        public IActionResult Register()
        {
            ViewBag.Title = GetCoName();
            return View();
        }

        [AllowAnonymous]
        [HttpPost("login/Register")]
        public async Task<IActionResult> RegisterUser(string UserName, string Email, string Password)
        {
            var userExist = await _data.FetchUserByEmailQS(Email);
            if (userExist is null)
            {
                DateTime created = DateTime.Now;
                UsersModel userModel = new UsersModel();
                userModel.UserName = UserName;
                userModel.Email = Email;
                userModel.Password = null;
                userModel.EmailVerifiedAt = null;
                userModel.Domain = null;
                userModel.RememberToken = null;
                userModel.Created = created;
                userModel.IdUserCompany = null;

                await _data.CreateUserRegister(userModel);
                return Redirect("/LoginLocked/SignInWithGoogle");
            }
            ViewData["errormsg"] = "Email already in use";
            return View("login/Register");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
