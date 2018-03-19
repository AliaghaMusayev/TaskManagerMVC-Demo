using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Models.DBModel;

namespace TaskManager.Controllers
{
    
    public class AuthorizeController : Controller
    {
        private MyMainDBModel dbConnections = new MyMainDBModel();
        // GET: Authorize
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users loginUser)
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users signUpUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbConnections.Users.Add(signUpUser);
            dbConnections.SaveChanges();
            ViewBag.success = "You are signed up successfully";
            return RedirectToAction("Login");
        }
    }
}