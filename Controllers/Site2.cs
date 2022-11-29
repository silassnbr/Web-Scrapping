using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationwithScrapping.DataModels;

namespace WebApplicationwithScrapping.Controllers
{
    public class Site2 : Controller
    {
        // GET: Site2
        public ActionResult Index()
        {
            Context context = new Context();
            var model1 = context.Databases.ToList();

            var model2 = context.Databases.Where(a=>a.marka!="trendyol").Distinct().ToList();
            Deneme deneme = new Deneme();


            return View(model2);
           
        }
        public class Deneme
        {
            public string marka;
            public string modelno;
        }
        // GET: Site2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Site2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Site2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Site2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Site2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Site2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Site2/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
