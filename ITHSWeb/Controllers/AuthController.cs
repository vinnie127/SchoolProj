using ITHSWeb.Models;
using ITHSWeb.Models.DTO.LogIn;
using ITHSWeb.Models.Repository.Services.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ITHSWeb.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        



        [HttpGet]
        public  IActionResult Login()
        {
            LoginRequestDto obj = new();

            return View(obj);



        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDto obj )
        {

            APIResponse response = await _authService.LoginAsync<APIResponse>(obj);

            if (response != null&& response.IsSuccess)
            {

                LoginResponseDTO model = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, model.User.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, model.User.Role));
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString(SDApi.SessionToken, model.Token);
                return RedirectToAction("Index","Home");

            }

            else
            {
                ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                return View(obj);
            }

        }


        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterationRequestDto obj)
        {

            APIResponse result = await _authService.RegisterAsync<APIResponse>(obj);

            if (result !=null&&result.IsSuccess)
            {

                return RedirectToAction("Login");


            }

            return View();


        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SDApi.SessionToken, "");

            return RedirectToAction("Index","Home");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }





    }
}
