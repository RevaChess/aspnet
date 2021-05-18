using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Medialab.Client.Controllers
{
  [Route("[controller]")]
  public class HomeController : Controller
  {
    public IConfiguration _configuration;
    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public async Task<IActionResult> Index()
    {
      var client = new HttpClient();
      var response = await client.GetAsync($"{_configuration["Services:webapi"]}/game");
      List<string> result = null;

      if (response.IsSuccessStatusCode)
      {
        result = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
        ViewBag.Games = result;
      }
      return View("index");
    }
  }
}