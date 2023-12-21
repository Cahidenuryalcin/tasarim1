using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using OnlineSiparis.Entity;
using OnlineSiparis.Models;

public class AdminController : Controller
{

    DataContext _context = new DataContext();
    

    public ActionResult Index()
    {
        var model = _context.Orders.ToList();
        return View(model);


    }
    public ActionResult Siparisler()
    {
        var model = _context.Orders.ToList();
        return View(model);
    }

    public ActionResult Guncelle()
    {
            var model = _context.Yemekler.ToList();
            return View(model);
    }

    public ActionResult AnaSayfaGetir(int Id)
    {
        var ag = _context.Yemekler.Find(Id);
        return View("AnasayfaGetir", ag);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Yemek product = _context.Yemekler.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        ViewBag.Id = new SelectList(_context.Yemekler, "Id", "Name", product.Id);
        return View("AnasayfaGetir", product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Name,Image,Price")] Yemek product)
    {
        if (ModelState.IsValid)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Guncelle");
        }
        ViewBag.Id = new SelectList(_context.Yemekler, "Id", "Name", product.Id);
        return View(product);
    }


    public ActionResult Ekle()
    {
        return View("Ekle");
    }


    public ActionResult Create(Yemek Model, HttpPostedFileBase File)
    {
        string path = Path.Combine("~/projefoto" + File.FileName);
        File.SaveAs(Server.MapPath(path));
        Model.Image = File.FileName.ToString();

        _context.Yemekler.Add(Model);
        _context.SaveChanges();
        return RedirectToAction("Guncelle");
    }


    public ActionResult Sil(int id)
    {
        Yemek yemek = _context.Yemekler.Find(id);
        _context.Yemekler.Remove(yemek);
        _context.SaveChanges();
        return RedirectToAction("Guncelle");
    }

    public ActionResult OdemeAlindi(int id)
    { 

        OrderLine order = _context.OrderLines.Find(id);
        _context.OrderLines.Remove(order);
        _context.SaveChanges();

        //OrderLine order = _context.OrderLines.Find(id);
        //_context.OrderLines.Remove(order);
        //_context.SaveChanges();
        //return RedirectToAction("Index");
        return RedirectToAction("Index");
    }


}
