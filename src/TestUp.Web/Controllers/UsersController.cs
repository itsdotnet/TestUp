using Microsoft.AspNetCore.Mvc;
using TestUp.Web.Models;

namespace TestUp.Web.Controllers;

public class UsersController : Controller
{
    public IActionResult Login()
    {
        var model = new LoginView();
        return View(model);
    }

    [HttpPost]
    public IActionResult Login(LoginView loginModel)
    {
        //login with auth
        return View();
    }
}
