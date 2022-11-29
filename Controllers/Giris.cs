using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;


namespace admin.Controllers
{
    public class Giris : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult loginform(IFormCollection collection)
        {
            string email = collection["email"];
            string Password = collection["Password"];
            if (email == "sila@gmail.com" && Password == "1234")
            {
                //               var routeValue = new RouteValueDictionary
                //(new { action = "View", controller = "UrunEkle" });
                //return RedirectToRoute(routeValue);
                return Redirect("/UrunEkle/Index");
            }
            else
            {
                ViewBag.Message = "Giriş Yapılamadı Kullanıcı Adı Veya Şifre Hatalı";

            }
            return View("Index");
        }

        private ActionResult RedirectToRoute()
        {
            throw new NotImplementedException();
        }
    }
}
