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
    public class SayfaBir : Controller
    { public List<Deneme> infolist = new List<Deneme>();
        private readonly ILogger<SayfaBir> _logger;
        public SayfaBir(ILogger<SayfaBir> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()

        {

            Context context = new Context();
            var model1 = context.Databases.ToList();

            var model2 = context.Databases.GroupBy(a => a.modelno).Distinct();
            Deneme deneme = new Deneme();
           

            return View(model1);
        }
 
        
        public class Deneme
        {
            public string marka;
            public string modelno;
        }
        public class Databases : DbContext
        {
            public DbSet<Deneme>? Deneme { get; set; }
        }
	}
       
}
