using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FMVCP.Models;
using FMVCP.Util;

namespace FMVCP.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            Session["name"] = "Tom";
            return View();
        }

        public async Task<ActionResult> BookList()
        {
            IEnumerable<Book> books = await db.Books.ToListAsync();
            ViewBag.Books = books;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            if (id > 3)
            {
                return Redirect("Home/Index");
            }
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }

        private DateTime GetToday()
        {
            return DateTime.Today;
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult GetImage()
        {
            const string path = "../Images/image1.png";
            return new ImageResult(path);
        }

        public ViewResult HelloWorldByViewData()
        {
            ViewData["Head"] = "Привет мир!";
            return View("SomeViewByViewData");
        }

        public ViewResult HelloWorldByViewBag()
        {
            ViewBag.Head = "Мир привет";
            return View("ViewByViewBag");
        }

        public RedirectResult SomeMethod()
        {
            return Redirect("/Home/Index");
        }

        public ActionResult CheckAge(int age)
        {
            return age < 666 ? new HttpStatusCodeResult(HttpStatusCode.Forbidden) : HttpNotFound();
        }

        public FileResult GetFile()
        {
            var filePath = Server.MapPath("~/Files/doc1.pdf");
            const string fileType = "application/pdf";
            const string fileName = "doc1.pdf";
            return File(filePath, fileType, fileName);
        }

        public FileResult GetBytes()
        {
            var path = Server.MapPath("~/Files/doc1.pdf");
            var mas = System.IO.File.ReadAllBytes(path);
            const string fileType = "application/pdf";
            const string fileName = "doc1.pdf";
            return File(mas, fileType, fileName);
        }

        public string GetRequestData()
        {
            var browser = HttpContext.Request.Browser.Browser;
            var userAgent = HttpContext.Request.UserAgent;
            var url = HttpContext.Request.RawUrl;
            var ip = HttpContext.Request.UserHostAddress;
            var referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + userAgent + "</p><p>Url запроса: " + url +
                   "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }

        public string GetContextData()
        {
            HttpContext.Response.Write("<h1>Hello World</h1>");

            var userAgent = HttpContext.Request.UserAgent;
            var url = HttpContext.Request.RawUrl;
            var ip = HttpContext.Request.UserHostAddress;
            var referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>User-Agent: " + userAgent + "</p><p>Url запроса: " + url +
                   "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }

        public string GetName()
        {
            var val = Session["name"];
            return val.ToString();
        }
    }
}