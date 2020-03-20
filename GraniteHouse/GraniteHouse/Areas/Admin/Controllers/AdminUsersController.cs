using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class AdminUsersController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AdminUsersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ApplicationUser.ToList()); ;
        }

        //Get: Edit
        public async Task<IActionResult> Edit(string id)
        {
            if(id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }

            var userFromDB = await _db.ApplicationUser.FindAsync(id);
            if(userFromDB == null)
            {
                return NotFound();
            }
            return View(userFromDB);
        }

        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser applicationUser)
        {
            if(id != applicationUser.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                ApplicationUser userFromDB = await _db.ApplicationUser.Where(u => u.Id == id).FirstOrDefaultAsync();
                userFromDB.Name = applicationUser.Name;
                userFromDB.PhoneNumber = applicationUser.PhoneNumber;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser); 
        }

        //Get: Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }

            var userFromDB = await _db.ApplicationUser.FindAsync(id);
            if (userFromDB == null)
            {
                return NotFound();
            }
            return View(userFromDB);
        }

        //Post : Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(string id)
        {
            ApplicationUser userFromDB = await _db.ApplicationUser.Where(u => u.Id == id).FirstOrDefaultAsync();
            userFromDB.LockoutEnd = DateTime.Now.AddYears(1000);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}