using Microsoft.AspNetCore.Mvc;

namespace Medialab.Client.Controllers
{
  [Route("[controller]")]
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View("index");
    }
  }
}