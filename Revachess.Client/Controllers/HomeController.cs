using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Revachess.Client.Models;

namespace Revachess.Client.Controllers
{
  [Route("[controller]")]
  public class HomeController : Controller
  {
    public IConfiguration _configuration;
    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Login()
    {
      UserViewModel user = new UserViewModel();
      return View("index", user);
    }

    [Route("/register")]
    public IActionResult Register()
    {
      UserViewModel user = new UserViewModel();
      return View("register", user);
    }
  }
}