using System;
using System.Collections.Generic;
using System.Linq;
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

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
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

    }
}