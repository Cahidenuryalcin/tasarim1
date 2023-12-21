using OnlineSiparis.Entity;
using OnlineSiparis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineSiparis.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {

            var yemek = db.Yemekler.FirstOrDefault(i => i.Id == Id);
            if(yemek != null)
            {
                GetCart().AddYemek(yemek , 1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var yemek = db.Yemekler.FirstOrDefault(i => i.Id == Id);
            if (yemek != null)
            {
                GetCart().DeleteYemek(yemek);
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;

        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Chechout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Chechout(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }


        }


        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var Masa = db.Orders.FirstOrDefault(i=>i.Id == entity.No);

            Masa.OrderLines = new List<OrderLine>();
            foreach(var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Yemek.Price;
                orderline.Yemek_Id = pr.Yemek.Id;
                orderline.Name = entity.Name;
                orderline.Service = entity.Service;
                orderline.OrderDate = DateTime.Now;

                Masa.OrderLines.Add(orderline);

            }

            db.SaveChanges(); 
            
        }
    }
}