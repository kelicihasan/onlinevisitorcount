using BRC.Derya.Business.Abstract;
using BRC.Derya.DataAccsess.Abstract;
using BRC.Derya.Entities;
using BRC.Derya.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRC.Derya.WebUI.Controllers
{
        // GET: Tr
        public ActionResult Index()
        {
            ViewBag.OnlineVisitor = HttpContext.Application["OnlineVisitor"];
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
    }
}
