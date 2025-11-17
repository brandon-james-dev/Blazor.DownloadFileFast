using Blazor.DownloadFileFast.Example_NET10_Subdirectory.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blazor.DownloadFileFast.Example_NET10_Subdirectory.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
