using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Treats.Models;
namespace Treats.Controllers
{
    public class TreatsController : Controller
    {
        private readonly TreatContext _db;
        public TreatsController ( TreatContext db) 
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Treat> model = _db.Treats.OrderBy(x => x.Name).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}