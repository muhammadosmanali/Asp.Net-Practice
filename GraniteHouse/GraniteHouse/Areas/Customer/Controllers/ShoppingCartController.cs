using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models.ViewModel;
using GraniteHouse.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraniteHouse.Models;

namespace GraniteHouse.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Models.Products>()
            };
        }

        //Get Index Shopping Cart
        public async Task<IActionResult> Index()
        {
            List<int> listShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(listShoppingCart != null)
            {
                foreach (int cartItem in listShoppingCart)
                {
                    Products product = await _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).Where(p => p.Id == cartItem).FirstOrDefaultAsync();
                    ShoppingCartVM.Products.Add(product);
                }
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> ListCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            ShoppingCartVM.Appointments.AppointmentDate = ShoppingCartVM.Appointments.AppointmentDate
                .AddHours(ShoppingCartVM.Appointments.AppointmentTime.Hour)
                .AddMinutes(ShoppingCartVM.Appointments.AppointmentTime.Minute);

            Appointment appointments = ShoppingCartVM.Appointments;
            _db.Appointments.Add(appointments);
            _db.SaveChanges();

            int appointmentId = appointments.Id;

            foreach(int productId in ListCartItems)
            {
                ProductsSelectedForAppointment productsSelectedForAppointment = new ProductsSelectedForAppointment()
                {
                    AppointmentId = appointmentId,
                    ProductId = productId
                };
                _db.ProductsSelectedForAppointments.Add(productsSelectedForAppointment);
            }
            _db.SaveChanges();
            ListCartItems = new List<int>();
            HttpContext.Session.Set("ssShoppingCart", ListCartItems);

            return RedirectToAction(nameof(AppointmentConfirmation), "ShoppingCart", new { Id = appointmentId });
        }

        public IActionResult Remove(int id)
        {
            List<int> ListCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(ListCartItems.Count > 0)
            {
                if(ListCartItems.Contains(id))
                {
                    ListCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", ListCartItems);
            return RedirectToAction(nameof(Index));
        }

        //Get Action Method
        public IActionResult AppointmentConfirmation(int id)
        {
            ShoppingCartVM.Appointments = _db.Appointments.Where(a => a.Id == id).FirstOrDefault();
            List<ProductsSelectedForAppointment> objProdList = _db.ProductsSelectedForAppointments.Where(p => p.AppointmentId == id).ToList();

            foreach(ProductsSelectedForAppointment prodAptObj in objProdList)
            {
                ShoppingCartVM.Products.Add(_db.Products.Include(p => p.ProductTypes).Include(p => p.SpecialTags).Where(p => p.Id == prodAptObj.ProductId).FirstOrDefault());
            }

            return View(ShoppingCartVM);
        }
    }
}