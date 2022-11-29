using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplicationwithScrapping.DataModels;

namespace WebApplicationwithScrapping.Controllers
{
    public class UrunEkle : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
           return View();   
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index1([Bind("Id,link,marka,model,modelno,fiyat,işletimsist,wind,ssd,ram,resim,puan")] Database database)
        {
            Context _context = new Context();

            try
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(database);
                         _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch 
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
                return View(database);
            
           
        }
    }
}
