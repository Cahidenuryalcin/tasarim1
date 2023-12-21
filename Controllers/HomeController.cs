using OnlineSiparis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineSiparis.Controllers
{
    public class HomeController : Controller
    {

        DataContext _context = new DataContext();

        // GET: Home //action metotladı, isteklerimizi karşılar
        public ActionResult Index()
        {
            return View();
        }


    public ActionResult Menu()
        {
            return View(_context.Yemekler.ToList());
        }



        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Subeler()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }

    }
}