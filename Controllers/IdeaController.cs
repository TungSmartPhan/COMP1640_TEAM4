using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP1640_TEAM4.Models;

namespace COMP1640_TEAM4.Controllers
{
    public class IdeaController : Controller

    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Idea
        public ActionResult Index()
        {
            var Idea = db.Ideas.Include(i => i.Category);
            return View(Idea.ToList());
        }
    }
}