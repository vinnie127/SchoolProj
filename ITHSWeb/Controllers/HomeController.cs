using Microsoft.AspNetCore.Mvc;
using ITHSWeb.Models;
using ITHSWeb.Models.Repository.IRepository;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ITHSWeb.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IAccountRepository _accountRepo;


        public HomeController(ILogger<HomeController> logger/*, IAccountRepository accountRepo*/)
        {
            _logger = logger;
            //_accountRepo = accountRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //[HttpGet]
        //public IActionResult Login()
        //{

        //    User obj = new User();
        //    return View(obj);


        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(User obj)
        //{

        //    User objUser = await _accountRepo.LoginAsync(SD.AccountAPIPath + "login/", obj);
        //    if (objUser.Token == null)
        //    {


        //        return View();

        //    }

        //    HttpContext.Session.SetString("JWToken", objUser.Token);
        //    return RedirectToAction("Index");




        //}



        //[HttpGet]
        //public IActionResult Register()
        //{


        //    return View();


        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(User obj)
        //{

        //    bool result = await _accountRepo.RegisterAsync(SD.AccountAPIPath + "register/", obj);
        //    if (result == false)
        //    {


        //        return View();

        //    }


        //    return RedirectToAction("Login");




        //}



        //public IActionResult Logout()
        //{

        //    HttpContext.Session.SetString("JWToken", "");
        //    return RedirectToAction("/Index");




        //}


    }
}