using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gummi.Models;

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
    }
}

