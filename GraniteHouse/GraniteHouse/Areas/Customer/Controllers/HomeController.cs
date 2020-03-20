using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Models;
using GraniteHouse.Data;
using GraniteHouse.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var productsList = await _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).ToListAsync();

            return View(productsList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).Where(m => m.Id == id).SingleOrDefaultAsync();
            return View(product);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(int id)
        {
            List<int> ListShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(ListShoppingCart == null)
            {
                ListShoppingCart = new List<int>();
            }
            ListShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", ListShoppingCart);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

        public IActionResult Remove(int id)
        {
            List<int> ListShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(ListShoppingCart.Count > 0)
            {
                if(ListShoppingCart.Contains(id))
                {
                    ListShoppingCart.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", ListShoppingCart);
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
