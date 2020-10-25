using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Shop.Models;
namespace Shop.Controllers
{
    [Authorize]
    public class TreatsController : Controller
    {
        private readonly TreatContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public TreatsController ( UserManager<ApplicationUser> userManager, TreatContext db) 
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            List<Treat> model = _db.Treats.Where(x => x.User.Id == currentUser.Id).OrderBy(x => x.Name).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Treat treat)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            treat.User = currentUser;
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Treat model = _db.Treats.FirstOrDefault(e => e.TreatId == id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(x => x.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(x => x.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {                    
            Treat thisMachine = _db.Treats.FirstOrDefault(x => x.TreatId == id);
            return View(thisMachine);
        }
        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddFlavor(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(s => s.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            return View(thisTreat);
        }
        [HttpPost]
        public ActionResult AddFlavor(TreatFlavor treatFlavor)
        {
            if (treatFlavor.FlavorId != 0)
            {
                if (_db.TreatFlavors.Where(x => x.TreatId == treatFlavor.TreatId && x.FlavorId == treatFlavor.FlavorId).ToHashSet().Count == 0)
                {
                _db.TreatFlavors.Add(treatFlavor);
                }
            }
            _db.SaveChanges();
            return RedirectToAction("details", new {id = treatFlavor.TreatId});
        }
        
        public ActionResult RemoveFlavor (int id)
        {
            TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(x => x.TreatFlavorId == id);
            int treatId = joinEntry.TreatId;

            _db.TreatFlavors.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("details", "treats",new {id =  treatId});
        }
    }
}