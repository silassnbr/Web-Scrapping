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
using WebApplicationwithScrapping.DataModels;
using WebApplicationwithScrapping.Models;
using Database = WebApplicationwithScrapping.Models.Database;

namespace WebApplicationwithScrapping.Controllers
{
    public class Teknosa : Controller
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
                string url = "https://www.teknosa.com/laptop-notebook-c-116004?s=%3Arelevance%3Abrand%3A230%3Abrand%3A2385%3Abrand%3A2152%3Abrand%3A2267%3Abrand%3A240%3Abrand%3A2328&page=" + donme.ToString();
                driver.Navigate().GoToUrl(url);
                System.Threading.Thread.Sleep(3000);
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight/2);");
                System.Threading.Thread.Sleep(1000);

                var acıklama = driver.FindElements(By.XPath("//a[@class='prd-link']"));
                var fiyatlar = driver.FindElements(By.XPath("//div[@class='prd-prc2']/span"));
                var resim = driver.FindElements(By.XPath("//figure[@class='responsive']/img"));
                var puan = driver.FindElements(By.XPath("//div[@class='prd ']"));
                System.Threading.Thread.Sleep(1000);
                int i = 0;
                string gelen;
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


                    bool freedos2 = parse[3].Contains("free-dos");
                    bool windows = parse[3].Contains("windows");
                    bool macos = parse[3].Contains("mac");
                    if (windows)
                    { win = "windows"; }
                    else if (freedos2)
                    { win = "freedos"; }
                    else if (macos)
                    { win = "macos"; }
                    else
                    {
                        win = "diğer";
                    }
                    bool ssd1 = parse[3].Contains("256-gb-ssd");
                    bool ssd2 = parse[3].Contains("512-gb-ssd");
                    bool ssd3 = parse[3].Contains("1-tb-ssd");
                    bool ssd4 = parse[3].Contains("2-tb-ssd");
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
                    bool ram1 = parse[3].Contains("4-gb");
                    bool ram2 = parse[3].Contains("8-gb");
                    bool ram3 = parse[3].Contains("16-gb");
                    bool ram4 = parse[3].Contains("32-gb");
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
                        site = parse[2].Substring(4, 8),
                        marka = parse[3].Substring(0, parse[3].IndexOf('-')),
                        işletimsist = işletim,
                       wind = win,
                        ssd = ssd,
                        ram = ram,
                        model = parse2[1],
                        modelno = String.Concat(parse2[2], ' ', parse2[3]),
                        fiyat = fiyatlar[i].Text,
                        //resim = resim[i].GetAttribute("src").ToString(),
                        puan = puan[i].GetAttribute("data-product-rating-score").ToString(),
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