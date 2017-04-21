using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gummi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Gummi.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        private GummiDbContext db = new GummiDbContext();
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisItem);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisItem);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisItem);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == id);
            db.Products.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

