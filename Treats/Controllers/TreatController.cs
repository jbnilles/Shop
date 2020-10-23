using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Treats.Models;
namespace Treats.Controllers
{
    public class TreatController
    {
        private readonly TreatContext _db;
        public TreatController ( TreatContext db) 
        {
            _db = db;
        }
    }
}