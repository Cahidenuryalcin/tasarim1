using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSiparis.Entity;
using System.Web.Security; //kullanicivarminull


namespace OnlineSiparis.Controllers
{

    public class LoginController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Alogin(Admin adminformu)
        {
           
                var kullaniciVarmi = _context.Adminler.FirstOrDefault(
                    x => x.Name == adminformu.Name && x.Password == adminformu.Password);

                if (kullaniciVarmi != null)
                {
                    FormsAuthentication.SetAuthCookie(kullaniciVarmi.Name, false);
                    //true=hatirla, false=bir sonraki girişte tekrar kullanıcı girişi isteyecek

                    //1. alan hangi sayfa 2.alan hangi controller
                    return RedirectToAction("/Index", "Admin");
                }

                ViewBag.Hata = "KULLANICI SİFRE HATALI!";

                return View("index"); //hata varsa indexe gitesin tekrar şşifre ad girebilsin

        }


    }
}