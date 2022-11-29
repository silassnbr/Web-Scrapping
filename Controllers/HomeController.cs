using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationwithScrapping.DataModels;
using WebApplicationwithScrapping.Models;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplicationwithScrapping.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;
      
        Context context = new Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
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