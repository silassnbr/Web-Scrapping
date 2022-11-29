using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using static System.Collections.Specialized.BitVector32;
using System.Security.Claims;
using System.Reflection.Metadata;
using OpenQA.Selenium.Firefox;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Interactions;

using OpenQA.Selenium.DevTools;
using System.Xml.Linq;
using OpenQA.Selenium.Support.UI;
using System.Text;
using WebApplicationwithScrapping.Models;
using WebApplicationwithScrapping.DataModels;

namespace WebApplicationwithScrapping.Controllers
{
    public class Hburada : Controller
    {
        public IActionResult Index()
        {

            List<Database> DataListT = new List<Database>();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            WebDriver driver = new ChromeDriver(options);
            using Context context = new Context();
            int donme = 1;

            while (donme < 10)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string url = "https://www.vatanbilgisayar.com/lenovo-dell-asus-apple-hp/notebook/?page=" + donme.ToString();
                driver.Navigate().GoToUrl(url);
                System.Threading.Thread.Sleep(3000);

                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight/2);");
                System.Threading.Thread.Sleep(1000);

                var acıklama = driver.FindElements(By.XPath("//a[@class='product-list__link']"));
                var fiyatlar = driver.FindElements(By.XPath("//span[@class='product-list__price']"));
                var resim = driver.FindElements(By.XPath("//img[@class='lazy cardImage']"));
                var puan = driver.FindElements(By.XPath("//span[@class='score']"));
                System.Threading.Thread.Sleep(1000);
                int i = 0;
                string gelen;
                string p;
                string[] parse;
                string[] parse2;
                string marka;
                string modell;
                string işletim;
                string win;
                string ssd;
                string ram;
                for (i = 0; i < acıklama.Count; i++)
                {

                    gelen = acıklama[i].GetAttribute("href").ToString();
                    p = puan[i].GetAttribute("style").ToString();
                    parse = gelen.Split('/');
                    //parse[4] = parse[4].Remove(parse[4].IndexOf("-p-"), (parse[4].Length-1));
                    parse2 = gelen.Split('-');

                    bool i3 = parse[3].Contains("i3");
                    bool i5 = parse[3].Contains("i5");
                    bool i7 = parse[3].Contains("i7");
                    bool i9 = parse[3].Contains("i9");
                    bool reyzen = parse[3].Contains("ryzen");
                    bool m1 = parse[3].Contains("m1");
                    if (i3)
                    {
                        işletim = "i3";
                    }
                    else if (i5)
                    {
                        işletim = "i5";
                    }
                    else if (i7)
                    {
                        işletim = "i7";
                    }
                    else if (i9)
                    {
                        işletim = "i9";
                    }
                    else if (reyzen)
                    {
                        işletim = "ryzen";
                    }
                    else if (m1)
                    {
                        işletim = "m1";
                    }
                    else
                    {
                        işletim = "diğer";
                    }

                    bool freedos = parse[3].Contains("dos");
                    bool freedos2 = parse[3].Contains("freedos");
                    bool windows = parse[3].Contains("w11");
                    bool macos = parse[3].Contains("mac");
                    if (windows)
                    { win = "windows"; }
                    else if (freedos && freedos2)
                    { win = "freedos"; }
                    else if (macos)
                    { win = "macos"; }
                    else
                    {
                        win = "diğer";
                    }
                    bool ssd1 = parse[3].Contains("256gb-ssd");
                    bool ssd2 = parse[3].Contains("512gb-ssd");
                    bool ssd3 = parse[3].Contains("1tb-ssd");
                    bool ssd4 = parse[3].Contains("2tb-ssd");
                    if (ssd1)
                    { ssd = "256gb"; }
                    else if (ssd2)
                    { ssd = "512gb"; }
                    else if (ssd3)
                    {
                        ssd = "1tb";
                    }
                    else if (ssd4)
                    { ssd = "2tb"; }
                    else { ssd = "diğer"; }
                    bool ram1 = parse[3].Contains("4gb");
                    bool ram2 = parse[3].Contains("8gb");
                    bool ram3 = parse[3].Contains("16gb");
                    bool ram4 = parse[3].Contains("32gb");
                    if (ram1)
                    { ram = "4gb"; }
                    else if (ram2)
                    { ram = "8gb"; }
                    else if (ram3)
                    {
                        ram = "16gb";
                    }
                    else if (ram4)
                    { ram = "32gb"; }
                    else { ram = "diğer"; }
                    var model = new Database()
                    {
                        link = acıklama[i].GetAttribute("href").ToString(),
                        site = parse[2].Substring(4, 15),
                        marka = parse[3].Substring(0, parse[3].IndexOf('-')),
                        işletimsist = işletim,
                        wind = win,
                        ssd = ssd,
                        ram = ram,
                        model = parse2[1],
                        modelno = String.Concat(parse2[2], ' ', parse2[3]),
                        fiyat = fiyatlar[i].Text,
                        //resim = resim[i].GetAttribute("src").ToString(),
                        
                        puan=p.ToString().Substring(2,p.ToString().IndexOf('%')),
                    };
                     context.Databases.Add(model);
                    DataListT.Add(model);
                }
                System.Threading.Thread.Sleep(500);

                donme++;

            }
             context.SaveChanges(); 
            driver.Close();

            return View(DataListT);


        }
    }
}