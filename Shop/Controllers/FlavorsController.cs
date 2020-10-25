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
    public class FlavorsController : Controller
    {
        private readonly TreatContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public FlavorsController( UserManager<ApplicationUser> userManager, TreatContext db)
        {
            _db = db;
            _userManager = userManager;
        }
        public  ActionResult Index()
        {
            List<Flavor> model = _db.Flavors.OrderBy(x => x.Name).ToList();
            return View(model);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            flavor.User = currentUser;
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Flavor model = _db.Flavors.FirstOrDefault(e => e.FlavorId == id);
            return View(model);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(x => x.FlavorId == id);
            return View(thisFlavor);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(x => x.FlavorId == id);
            _db.Flavors.Remove(thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {                    
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(x => x.FlavorId == id);
            return View(thisFlavor);
        }
        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult AddTreat(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(s => s.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisFlavor);
        }
        [HttpPost]
        public ActionResult AddTreat(TreatFlavor treatFlavor)
        {
            if (treatFlavor.TreatId != 0)
            {
                if (_db.TreatFlavors.Where(x => x.TreatId == treatFlavor.TreatId && x.FlavorId == treatFlavor.FlavorId).ToHashSet().Count == 0)
                {
                _db.TreatFlavors.Add(treatFlavor);
                }
            }
            _db.SaveChanges();
            return RedirectToAction("details",new {id = treatFlavor.FlavorId});
        }
        [Authorize]
        public ActionResult RemoveTreat (int id)
        {
            TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(x => x.TreatFlavorId == id);
            int flavorId = joinEntry.FlavorId;
            _db.TreatFlavors.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("details", "flavors", new {id = flavorId});
        }
    }
}