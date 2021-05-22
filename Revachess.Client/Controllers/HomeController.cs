using Microsoft.AspNetCore.Mvc;

namespace Medialab.Client.Controllers
{
  [Route("[controller]")]
  public class HomeController : Controller
  {
    [Route("")]
    [Route("Home")]
    [Route("Home/Index")]
    public IActionResult Index()
    {
      return View("index");
    }

    [Route("/register")]
    public IActionResult Register()
    {
      return View("register");
    }
  }
}